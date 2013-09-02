
using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;
namespace TaxOnline.Data.Configuration
{
    public class TaxNoticeConfiguration : EntityTypeConfiguration<TaxNotice>
    {
        public TaxNoticeConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
            this.HasRequired<Taxpayer>(p => p.Taxpayer);
            this.HasMany(p => p.Transactions);
        }
    }
}
