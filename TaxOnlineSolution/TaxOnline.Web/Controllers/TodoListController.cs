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
    public class TodoListController : ApiController
    {
         private readonly TodoItemRepository _repository;

         public TodoListController()
        {
            _repository = new TodoItemRepository(User);
        }

        // GET api/todolist
        public IEnumerable<TodoItem> Get()
        {
            return _repository.Todos;
        }

        // GET api/todolist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/todolist
        public void Post([FromBody]string value)
        {
        }

        // PUT api/todolist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/todolist/5
        public void Delete(int id)
        {
        }
    }
}
