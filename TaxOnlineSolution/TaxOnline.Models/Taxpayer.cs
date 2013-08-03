﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class Taxpayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLines { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public bool  InvalidAddress { get; set; }
    }
}