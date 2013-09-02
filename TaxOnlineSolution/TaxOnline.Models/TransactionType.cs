using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public bool IsPayment { get; set; }
        public TransactionType()
        {
            Transactions = new List<Transaction>();
        }
    }
}
