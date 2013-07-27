using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxOnline.Models
{
    public class User
    {

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public ICollection<Role> Roles { get; set; }
        //public ICollection<TodoItem> ToDos { get; set; }
        public User()
        {
            //ToDos = new List<TodoItem>();
            Roles = new List<Role>();
        }
    }
}
