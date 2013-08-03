
using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;
namespace TaxOnline.Data.Configuration
{
    public class ErrorLogConfiguration : EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
             
        }
    }
}
