using HTML5.ScratchPad.DDD.Domain.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
namespace HTML5.ScratchPad.DDD.Infra.Data.EntityConfig
{
    public class CustomerFluentMap : EntityTypeConfiguration<Customer>
    {
        public CustomerFluentMap()
        {
            //E.g - Or split entity into multiple tables

            //Map(c => c.ToTable("Customer")).Map(c =>
            //{
            //    c.Properties(p => new { p.CustomerId, p.RowVersion });
            //    c.ToTable("StudentTimestamp");
            //});

            //Action<EntityMappingConfiguration<Customer>> mapping = m =>
            //{
            //    m.Properties(p => new { p.CustomerId, p.RowVersion});
            //    m.ToTable("StudentTimestamp");
            //};
            //Map(mapping);

            #region Primary and Foreign Keys

            //Primary Key
            HasKey(c => c.CustomerId)
                .Property(c => c.CustomerId).HasColumnName("Id");

            Property(p => p.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(1);

            //Foreign Key - Product has to be ICollection<TEntity> to use this approach, one-to-many-optional
            HasMany(p => p.Product)
                .WithOptional(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
 
            //Foreign Key Address one-to-one
            HasRequired(s => s.Address) // Must have an address in the relationship
                .WithRequiredPrincipal(ad => ad.Customer) // Create inverse relationship
                .WillCascadeOnDelete();

            #endregion

            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Firstname")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .IsConcurrencyToken() //now using rowversion for concurrency
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Surname")
                .IsConcurrencyToken() //now using rowversion for concurrency
                .HasColumnOrder(3);                

            //This adds a sql rowversion to the table for -optimistic concurrency
            Property(c => c.RowVersion)
                //.IsConcurrencyToken()
                .IsRequired()
                .IsRowVersion()
                .HasColumnOrder(4);

            Property(c => c.Active)
                .IsOptional()
                .HasColumnOrder(5);

            ToTable("Customer");
        }
    }
}
