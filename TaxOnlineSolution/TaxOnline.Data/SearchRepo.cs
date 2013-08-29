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
        public enum SearchType
        {
            Name,
            BillNumber,
            Address
        }
        DataContext _context;
        public SearchRepo(IPrincipal user)
        {
             _context=new DataContext();
            UserId = user.Identity.Name;
        }
        public string UserId { get; private set; }
        public List<TaxNotice> Search(string searchFor,int searchtypeid)
        {
            System.Threading.Thread.Sleep(1000);
            if (string.IsNullOrEmpty(searchFor)) return new List<TaxNotice>();
            var searchType = (SearchType)searchtypeid;
            switch (searchType)
            {
                case SearchType.Name: //name
                    var taxpayerquery = _context.TaxNotices.Include("Taxpayer").Where(p => p.Taxpayer.Name.StartsWith(searchFor));
                    return taxpayerquery.ToList();

                case SearchType.BillNumber: //bill#
                    var billquery = _context.TaxNotices.Include("Taxpayer").Where(p => p.BillNumber.StartsWith(searchFor));
                    return billquery.ToList();

                case SearchType.Address:
                    //var addrquery = _context.TaxNotices.Include("Taxpayer").Where(p => p..Name.StartsWith(searchFor));
                    //return addrquery.ToList();
                    return new List<TaxNotice>();
                     
                default:
                    return new List<TaxNotice>();
            }
            
        }
 
    }
}
