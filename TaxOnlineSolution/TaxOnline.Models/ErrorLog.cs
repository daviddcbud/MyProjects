﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public DateTime DateTime { get; set; }
        public string User { get; set; }
        public ErrorLog()
        {
            DateTime = DateTime.Now;
        }
    }
}
