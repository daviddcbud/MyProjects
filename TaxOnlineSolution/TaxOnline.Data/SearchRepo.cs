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
        public List<TaxNotice> Search(string searchFor,int searchtypeid)
        {
            if (string.IsNullOrEmpty(searchFor)) return new List<TaxNotice>();
            switch (searchtypeid)
            {
                case 0:
                    var taxpayerquery = _context.TaxNotices.Include("Taxpayer").Where(p => p.Taxpayer.Name.StartsWith(searchFor));
                    return taxpayerquery.ToList();
                     
                case 1:
                    var billquery = _context.TaxNotices.Include("Taxpayer").Where(p => p.BillNumber.StartsWith(searchFor));
                    return billquery.ToList();
                     
                case 2:
                    //var addrquery = _context.TaxNotices.Include("Taxpayer").Where(p => p..Name.StartsWith(searchFor));
                    //return addrquery.ToList();
                    return new List<TaxNotice>();
                     
                default:
                    return new List<TaxNotice>();
            }
            
        }
 
    }
}
