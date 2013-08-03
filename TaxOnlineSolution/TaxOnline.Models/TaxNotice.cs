using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class TaxNotice
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public int TaxYear { get; set; }
        public string Type { get; set; }
        public Taxpayer Taxpayer { get; set; }
        
    }
}
