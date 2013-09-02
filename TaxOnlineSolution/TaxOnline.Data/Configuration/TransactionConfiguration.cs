using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction >
    {
        public TransactionConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
            this.HasRequired<TransactionType>(p => p.TransactionType);
            this.Property((p) => p.Amount).IsRequired();
            this.Property((p) => p.Date).HasColumnType("date").IsRequired();
        }

    }
}
