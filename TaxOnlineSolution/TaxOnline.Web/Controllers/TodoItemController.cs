namespace TaxOnline.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Breeze.WebApi;
    using Filters;
    using Models;
    using Newtonsoft.Json.Linq;
using TaxOnline.Data;
    using TaxOnline.Models;
     

  //  [Authorize]
    [BreezeController]
    public class TodoItemController : ApiController
    {
        private readonly TodoItemRepository _repository;

        public TodoItemController()
        {
            _repository = new TodoItemRepository(User);
        }

        // GET ~/api/Todo/Metadata 
        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata();
        }

        // POST ~/api/Todo/SaveChanges
        [HttpPost]
        [ValidateHttpAntiForgeryToken]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        // GET ~/api/Todo/TodoList
        [HttpGet]
        public IQueryable<TodoItem> Todos()
        {
            return _repository.Todos;
            // We do the following on the client
            //.Include("Todos")
            //.OrderByDescending(t => t.TodoListId);
        }
    }
}