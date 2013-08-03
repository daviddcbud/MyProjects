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

namespace TaxOnline.Data
{
    public class ErrorLogRepo 
    {
        DataContext _context;
        public ErrorLogRepo(IPrincipal user)
        {
             _context=new DataContext();
            UserId = user.Identity.Name;
        }

        public string UserId { get; private set; }

        public void Save(ErrorLog log)
        {
            log.DateTime = DateTime.Now;
            log.User = UserId;
            _context.ErrorLogs.Add(log);
            _context.SaveChanges();
        }



      
    }
}
