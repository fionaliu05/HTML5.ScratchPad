using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HTML5.ScratchPad.DDD.Infra.Data.Conventions.Config
{
    public class PKConvention : Convention
    {
        public PKConvention()
        {
            Properties()
                .Where(p => p.Name == p.DeclaringType.Name + "Id")
                .Configure(p => 
                    p.IsKey()
                    .HasColumnOrder(1)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    );
        }
    }
}
