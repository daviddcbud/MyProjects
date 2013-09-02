using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class ParcelConfiguration : EntityTypeConfiguration<Parcel>
    {
        public ParcelConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
            this.HasRequired<TaxNotice>(p => p.TaxNotice);
            this.Property((p) => p.Number).HasMaxLength(20).HasColumnType("nvarchar").IsRequired();
            this.Property((p) => p.PhysicalAddress).HasMaxLength(100).HasColumnType("nvarchar").IsRequired();
        }

    }
}
