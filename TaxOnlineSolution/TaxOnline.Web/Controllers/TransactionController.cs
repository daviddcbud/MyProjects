using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxOnline.Data;
using TaxOnline.Models;

namespace TaxOnline.Web.Controllers
{
    [Authorize]
    public class TransactionController : ApiController
    {
        TransactionRepo _repo;
        public TransactionController()
        {
            _repo = new TransactionRepo(User);
        }
        // GET api/taxnotice
        public IEnumerable<Transaction>  Get( )
        {
            
            return null;
        }

        // GET api/taxnotice/5
        public Transaction Get(int id)
        {
            var result = _repo.GetItemById(id);
            return result;
        }

        // POST api/transaction
        public void Post([FromBody]string value)
        {
        }

        // PUT api/transaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/transaction/5
        public void Delete(int id)
        {
        }
    }
}
