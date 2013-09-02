using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data
{
    public class TransactionRepo
    {
        
        DataContext _context;
        public TransactionRepo(IPrincipal user)
        {
             _context=new DataContext();
            UserId = user.Identity.Name;
        }
        public string UserId { get; private set; }
        public Transaction GetItemById(int id)
        {
            return _context.Transactions.Include("TransactionType").Where(x => x.Id == id).Single();
        }
    }
}
