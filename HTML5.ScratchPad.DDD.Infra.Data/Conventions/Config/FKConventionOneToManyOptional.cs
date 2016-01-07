using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HTML5.ScratchPad.DDD.Infra.Data.Conventions.Config
{
    public class FKConventionOneToManyOptional : Convention
    {
        public FKConventionOneToManyOptional()
        {

           //Properties()
           //     .Where(p => p.Name == p.DeclaringType.Name + "Id")
           //     .Configure(p => 
           //         p.Product   ()
           //         .HasColumnOrder(1)
           //         .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
           //         );
           // HasMany(p => p.Product)
           //    .WithOptional(p => p.Customer)
           //    .HasForeignKey(p => p.CustomerId);
        }
    }
}
