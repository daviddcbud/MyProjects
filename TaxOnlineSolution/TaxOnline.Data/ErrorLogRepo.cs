using TaxOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Security.Principal;
using System.Security;
using TaxOnline.Data.Interfaces;

namespace TaxOnline.Data
{


    public class ErrorLogRepo :IErrorLogger
    {
        DataContext _context;

        public ErrorLogRepo( )
        {
             _context=new DataContext();
            
        }

         

        public void Save(ErrorLog log)
        {
            log.DateTime = DateTime.Now;
            log.User = UserID;
            _context.ErrorLogs.Add(log);
            _context.SaveChanges();
        }



        public string UserID { get; set; }
    }
}
