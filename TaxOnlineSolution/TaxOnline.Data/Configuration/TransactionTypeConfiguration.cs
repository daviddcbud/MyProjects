using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class TransactionTypeConfiguration:EntityTypeConfiguration<TransactionType>
    {
        public TransactionTypeConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
            this.Property((p) => p.Description).HasMaxLength(80).HasColumnType("nvarchar").IsRequired();
            this.HasMany(p => p.Transactions);
        }

    }
}
