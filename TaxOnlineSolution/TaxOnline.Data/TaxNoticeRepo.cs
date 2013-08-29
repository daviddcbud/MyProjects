using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data
{
    public class TaxNoticeRepo
    {
        DataContext _context;
        public TaxNoticeRepo(IPrincipal user)
        {
             _context=new DataContext();
            UserId = user.Identity.Name;
        }
        public string UserId { get; private set; }
        public TaxNotice GetTaxNotice(int id)
        {
            return _context.TaxNotices.Include("Taxpayer").Where(x => x.Id == id).Single();
        }
    }
}
