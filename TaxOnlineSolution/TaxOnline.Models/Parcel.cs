using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string PhysicalAddress { get; set; }
        public TaxNotice TaxNotice { get; set; }
        public string Legal { get; set; }

    }
}
