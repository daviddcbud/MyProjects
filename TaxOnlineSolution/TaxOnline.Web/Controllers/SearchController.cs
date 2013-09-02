using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxOnline.Data;
using TaxOnline.Models;
using TaxOnline.Web.Models;

namespace TaxOnline.Web.Controllers
{
    [Authorize]
    public class SearchController : ApiController
    {
        SearchRepo _repo;
        public SearchController()
        {
            _repo = new SearchRepo(User);
        }
        // GET api/search
        public IEnumerable<TaxNotice> Get(string searchfor, int searchtype)
        {
             
            var results = _repo.Search(searchfor, searchtype);

          
            return results;
        }

        // GET api/search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/search
        public void Post([FromBody]string value)
        {
        }

        // PUT api/search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/search/5
        public void Delete(int id)
        {
        }
    }
}
