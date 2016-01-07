using HTML5.ScratchPad.DDD.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HTML5.ScratchPad.DDD.Infra.Data.EntityConfig
{
    public class AddressFluentMap : EntityTypeConfiguration<Address>
    {
        public AddressFluentMap()
        {
            #region PK and FKS

            //HasKey(a => new PKConvention());

            //Primary Key
            HasKey(a => a.AddressId)
                .Property(a => a.AddressId).HasColumnName("AddressId");

            Property(p => p.AddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(1);

            ////Foreign Key - Address has to be ICollection<TEntity>, one-to-one relationship
            HasRequired(ad => ad.Customer)
                .WithRequiredDependent(c => c.Address); //Mark as required dependent
                //.WillCascadeOnDelete(true); //Peforms Cascase Delete

            #endregion

            Property(c => c.AddressLine1)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("AddressLine1")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.AddressLine2)
                .IsOptional()
                .HasMaxLength(150)
                .HasColumnName("AddressLine2")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.AddressLine3)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Town")
                .HasColumnOrder(4)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.AddressLine4)
                .IsOptional()
                .HasMaxLength(150)
                .HasColumnName("County")
                .HasColumnOrder(5)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Postcode)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("Postcode")
                .HasColumnOrder(6)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Email")
                .HasColumnOrder(7)
                .HasColumnType("varchar")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            ToTable("Address");
        }
    }
}
