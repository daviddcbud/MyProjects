using Newtonsoft.Json;
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
    public class ErrorLogController : ApiController
    {
        ErrorLogRepo _repository;
        public ErrorLogController()
        {
            _repository = new ErrorLogRepo(User);
        }
        // GET api/errorlog
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/errorlog/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/errorlog
        public void Post( ErrorLog log)
        {

            //var errorLog = JsonConvert.DeserializeObject<ErrorLog>(json);
            _repository.Save(log);
        }

        // PUT api/errorlog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/errorlog/5
        public void Delete(int id)
        {
        }
    }
}
