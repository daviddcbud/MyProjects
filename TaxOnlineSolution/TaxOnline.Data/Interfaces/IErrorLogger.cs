using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Interfaces
{
    public interface IErrorLogger
    {
        void Save(ErrorLog logEntry);
        string UserID { get; set; }

    }
}
