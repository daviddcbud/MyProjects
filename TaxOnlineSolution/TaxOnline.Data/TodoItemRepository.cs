using TaxOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Security.Principal;
using Breeze.WebApi;
using System.Security;

namespace TaxOnline.Data
{
    public class TodoItemRepository :EFContextProvider<DataContext>
    {
        public TodoItemRepository(IPrincipal user)
        {
            UserId = user.Identity.Name;
        }

        public string UserId { get; private set; }

        public DbQuery<TodoItem> Todos
        {
            get
            {
                return (DbQuery<TodoItem>)Context.TodoItems;
                     
            }
        }

       

        #region Save processing

        // Todo: delegate to helper classes when it gets more complicated

        protected override bool BeforeSaveEntity(EntityInfo entityInfo)
        {
            var entity = entityInfo.Entity;
            if (entity is TodoItem )
            {
                return BeforeSaveTodoList(entity as TodoItem, entityInfo);
            }
            if (entity is TodoItem)
            {
                return BeforeSaveTodoItem(entity as TodoItem, entityInfo);
            }
            throw new InvalidOperationException("Cannot save entity of unknown type");
        }


        private bool BeforeSaveTodoList(TodoItem todoList, EntityInfo info)
        {
            return true;
        }

        private bool BeforeSaveTodoItem(TodoItem todoItem, EntityInfo info)
        {
            var todoList = ValidationContext.TodoItems.Find(todoItem.Id);
            return (null == todoList)
                       ? throwCannotFindParentTodoList()
                       : throwCannotSaveEntityForThisUser(todoItem.Id);
        }

        // "this.Context" is reserved for Breeze save only!
        // A second, lazily instantiated DbContext will be used
        // for db access during custom save validation. 
        // See this stackoverflow question and reply for an explanation:
        // http://stackoverflow.com/questions/14517945/using-this-context-inside-beforesaveentity
        private DataContext ValidationContext
        {
            get { return _validationContext ?? (_validationContext = new DataContext()); }
        }
        private DataContext _validationContext;

        private bool throwCannotSaveEntityForThisUser(int id)
        {
            throw new SecurityException("Can't find item to edit " + id);
        }

        private bool throwCannotFindParentTodoList()
        {
            throw new InvalidOperationException("Invalid TodoItem");
        }

        #endregion
    }
}
