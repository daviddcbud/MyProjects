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
    public class TaxNoticeController : ApiController
    {
        TaxNoticeRepo _repo;
        public TaxNoticeController()
        {
            _repo = new TaxNoticeRepo(User);
        }
        // GET api/taxnotice
        public IEnumerable<TaxNotice>  Get( )
        {
            
            return null;
        }

        // GET api/taxnotice/5
        public TaxNotice Get(int id)
        {
            var taxnotice = _repo.GetTaxNotice(id);
            return taxnotice;
        }

        // POST api/taxnotice
        public void Post([FromBody]string value)
        {
        }

        // PUT api/taxnotice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/taxnotice/5
        public void Delete(int id)
        {
        }
    }
}
