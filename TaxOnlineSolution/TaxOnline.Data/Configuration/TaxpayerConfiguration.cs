 
using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;
namespace TaxOnline.Data.Configuration
{
   public class TaxpayerConfiguration: EntityTypeConfiguration<Taxpayer>
    {
       public TaxpayerConfiguration()
       {
           this.Property((p) => p.Id).HasColumnOrder(0);
           this.Property((p) => p.Name).HasMaxLength(100).HasColumnType("nvarchar").IsRequired();
           this.Property((p) => p.AddressLines).HasMaxLength(100).HasColumnType("nvarchar").IsRequired();
           this.Property((p) => p.City).HasMaxLength(100).HasColumnType("nvarchar");
           this.Property((p) => p.State).HasMaxLength(20).HasColumnType("nvarchar");
           this.Property((p) => p.Zip).HasMaxLength(20).HasColumnType("nvarchar");
           this.Property((p) => p.PhoneNumber).HasMaxLength(40).HasColumnType("nvarchar");
           this.HasMany(p => p.TaxNotices);
       }
    }
}
