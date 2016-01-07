using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.Infra.Data.Conventions.Config;
using HTML5.ScratchPad.DDD.Infra.Data.EntityConfig;
using HTML5.ScratchPad.DDD.Infra.Data.EntityValidation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace HTML5.ScratchPad.DDD.Infra.Data.EFContext
{

    public class ProjectModelContext : System.Data.Entity.DbContext
    {
        //This base constructor overrides the name for the database to be created
        //If ommitted it uses the combo of namespace + context name e.g. "HTML5.ScratchPad.DDD.Infra.Data.DbContext.ProjectModelContext"
        public ProjectModelContext()
            : base("ProductModelDDD")

        //: base(@"data source=.\SQLEXPRESS; 
        //         initial catalog=ProductModel;
        //         integrated security=true")
        {

            //Configuration (Lazy Loading set by default)
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;

            //Validation on Save Enabled
            //this.Configuration.ValidateOnSaveEnabled = true;

            //Database Initialisation Strategy

            //Database.SetInitializer<ProjectModelContext>(null);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectModelContext, Migrations.Configuration>("ProductModelDDD"));

            //Database.SetInitializer(new CustomInitializerExampleDropCreateAlways());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ProjectModelContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectModelContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ProjectModelContext>());

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("dbo");

            //Here we are disabling some of the default model conventions self explanatory really, as not required
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Custom convention for a Primary Key with a Filter on int values
            // Set all fields named "Id" to be the Primary Key by default, but only if they are an int on the entity
            // N.B. IsKey() method is additive so specifying multiples creates "composite" keys, but you
            // must call the HasColumnOrder() method to define the order

            modelBuilder.Properties<int>()
                .Where(p => p.ReflectedType.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Now set on Configurations below
            //modelBuilder.Entity<Customer>().ToTable("Customer");
            //modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Configurations.Add(new CustomerFluentMap());
            modelBuilder.Configurations.Add(new ProductFluentMap());
        }

        //Use this to add server-side validation
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //do the base DataAnnotations/fluent validation mapping
            var result = base.ValidateEntity(entityEntry, items);

            List<DbValidationError> checkedItems;

            if (entityEntry.Entity == Customers)
            {
                checkedItems = ValidateCustomer.Validate(entityEntry, items);
                if (checkedItems != null)
                {
                    foreach (var item in checkedItems)
                    {
                        result.ValidationErrors.Add(item);
                    }
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("InceptionDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("InceptionDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("InceptionDate").IsModified = false;
                    //entry.Property("RowVersion").IsModified = false;
                    //entry.Property("CustomerId").IsModified = false;
                }

            }
            //var selectedEntityList = ChangeTracker.Entries()
            //                         .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);



            //foreach (var entry in ChangeTracker.Entries()
            //    .Where(entry => entry.Entity.GetType().GetProperty("AddressId") != null))
            //{
            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("AddressId").IsModified = false;
            //    }
            //}


            return base.SaveChanges();
        }
    }
}