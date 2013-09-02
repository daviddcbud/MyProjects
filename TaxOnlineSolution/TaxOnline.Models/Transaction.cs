using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TaxNotice TaxNotice { get; set; }
    }
}
