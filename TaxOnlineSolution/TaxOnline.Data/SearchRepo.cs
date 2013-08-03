using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data
{
    public class SearchRepo
    {
        DataContext _context;
        public SearchRepo(IPrincipal user)
        {
             _context=new DataContext();
            UserId = user.Identity.Name;
        }
        public string UserId { get; private set; }
        public List<TaxNotice> Search(string searchFor)
        {
            var query = _context.TaxNotices.Include("Taxpayer").Where(p => p.Taxpayer.Name.StartsWith(searchFor));
            return query.ToList();
        }
 
    }
}
