using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using TaxOnline.Models;

namespace TaxOnline.Data
{
   public  class DataContextMigrationConfiguration:DbMigrationsConfiguration<DataContext>
    {
       public DataContextMigrationConfiguration()
       {
           this.AutomaticMigrationDataLossAllowed = true;
           this.AutomaticMigrationsEnabled = true;
       }
       protected override void Seed(DataContext context)
       {

           if (context.Roles.Count() == 0)
           {
               var role = new Role();
               role.RoleName = "Administrator";
               context.Roles.Add(role);
           }

           if (context.TodoItems.Count() == 0)
           {
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
           }
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
