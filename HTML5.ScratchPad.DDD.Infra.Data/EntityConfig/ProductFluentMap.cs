using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HTML5.ScratchPad.DDD.Infra.Data.EntityConfig
{
    public class ProductFluentMap : EntityTypeConfiguration<Product>
    {
        public ProductFluentMap()
        {
            #region Primary and Foreign Keys

            //Primary Key
            HasKey(p => p.ProductId);

            Property(p => p.ProductId).HasColumnOrder(1);

            //Foreign Key - Product has to be ICollection<TEntity> to use this approach,
            //One-to-many-optional
            HasOptional(c => c.Customer)
                .WithMany(c => c.Product)
                .HasForeignKey(c => c.CustomerId);

            #endregion

            Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .HasMaxLength(250);

            Property(p => p.Value)
                .IsRequired()
                .HasColumnName("Value")
                .HasColumnType("Decimal")
                .HasColumnOrder(3)
                .HasPrecision(9,2);

            ToTable("Product");
        }
    }
}
