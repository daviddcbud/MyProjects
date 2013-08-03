using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{

    public class CustomDatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //no need for savechanges
            var role = new Role();
            role.RoleName = "Administrator";
            context.Roles.Add(role);

            CreateIndex(context, "UserName", "Users", true);

            var todo = new TodoItem();
            todo.Message = "test";
            context.TodoItems.Add(todo);
            todo = new TodoItem();
            todo.Message = "test2";

            var taxpayer = new Taxpayer();
            taxpayer.Name = "Freeman, David";
            taxpayer.AddressLines = "3512 Main St";
            taxpayer.TaxYear = 2013;
            var notice = new TaxNotice();
            notice.TaxYear = 2013;
            notice.BillNumber = "12342";
            taxpayer.TaxNotices.Add(notice);
            context.Taxpayers.Add(taxpayer);

            taxpayer = new Taxpayer();
            taxpayer.Name = "Freeman, John";
            taxpayer.AddressLines = "3512 Main St";
            taxpayer.TaxYear = 2013;
             notice = new TaxNotice();
            notice.TaxYear = 2013;
            notice.BillNumber = "12342";
            taxpayer.TaxNotices.Add(notice);
            context.Taxpayers.Add(taxpayer);
            context.TodoItems.Add(todo);
            base.Seed(context);
        }
        private void CreateIndex(DataContext context, string field, string table, bool unique = false)
        {
            context.Database.ExecuteSqlCommand(String.Format("CREATE {0}NONCLUSTERED INDEX IX_{1}_{2} ON {1} ({3})",
                unique ? "UNIQUE " : "",
                table,
                field.Replace(",", "_"),
                field));
        }
    }
}
