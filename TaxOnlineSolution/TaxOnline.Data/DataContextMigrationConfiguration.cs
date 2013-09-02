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




               var transactionType = new TransactionType();
               transactionType.Description = "TAXES";
               context.TransactionTypes.Add(transactionType);
               var taxtype = transactionType;
               transactionType = new TransactionType();
               transactionType.Description = "PAYMENT";
               var paymentType = transactionType;
               context.TransactionTypes.Add(transactionType);
               transactionType = new TransactionType();
               transactionType.Description = "INTEREST";
               context.TransactionTypes.Add(transactionType);

               var taxpayer = new Taxpayer();
               taxpayer.Name = "Freeman, David";
               taxpayer.AddressLines = "3512 Main St";
               taxpayer.TaxYear = 2013;
               taxpayer.City = "Shreveport";
               taxpayer.State = "LA";
               taxpayer.Zip = "71112";
               taxpayer.Email = "dd@dd.com";
               var notice = new TaxNotice();
               notice.TaxYear = 2013;
               notice.BillNumber = "12342";
               taxpayer.TaxNotices.Add(notice);
               context.Taxpayers.Add(taxpayer);

               var transaction = new Transaction();
               transaction.TransactionType = taxtype;
               transaction.Date = DateTime.Parse("10/1/12");
               transaction.Amount = 310.23M;
               notice.Transactions.Add(transaction);
               transaction = new Transaction();
               transaction.TransactionType = paymentType;
               transaction.Date = DateTime.Parse("12/5/12");
               transaction.Amount = -310.23M;
               notice.Transactions.Add(transaction);


               taxpayer = new Taxpayer();
               taxpayer.Name = "Freeman, John";
               taxpayer.AddressLines = "3512 Main St";
               taxpayer.TaxYear = 2013;
               taxpayer.City = "Shreveport";
               taxpayer.State = "LA";
               taxpayer.Zip = "71112";
               taxpayer.Email = "dd@dd.com";
               notice = new TaxNotice();
               notice.TaxYear = 2013;
               notice.BillNumber = "12342";
               taxpayer.TaxNotices.Add(notice);
               context.Taxpayers.Add(taxpayer);
               transaction = new Transaction();
               transaction.TransactionType = taxtype;
               transaction.Date = DateTime.Parse("10/1/12");
               transaction.Amount = 310.23M;
               notice.Transactions.Add(transaction);
               transaction = new Transaction();
               transaction.TransactionType = paymentType;
               transaction.Date = DateTime.Parse("12/5/12");
               transaction.Amount = -310.23M;
               notice.Transactions.Add(transaction);
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
