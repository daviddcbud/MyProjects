using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxOnline.Web.Models
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int TaxYear { get; set; }
        public string BillNumber { get; set; }
    }
}