using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

using TaxOnline.Data.Configuration;
using System.Data.Entity;
namespace TaxOnline.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
         
        public DbSet<Role> Roles { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Taxpayer> Taxpayers { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<TaxNotice> TaxNotices { get; set; }
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["connectionstring"] != null)
                {
                    return ConfigurationManager.AppSettings["connectionstring"].ToString();
                }
                return "DefaultConnection";
            }
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(p => p.Entity is IAudit
                && (p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Modified)))
            {
                ((IAudit)entry).ModifiedOn = DateTime.Now;
                if (entry.State == System.Data.EntityState.Added) ((IAudit)entry).CreatedOn = DateTime.Now;

            }

            return base.SaveChanges();
        }
        static DataContext()
        {
            Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, DataContextMigrationConfiguration>());
          //  Database.SetInitializer(new CustomDatabaseInitializer());
        }
        public DataContext()
            : base(nameOrConnectionString: ConnectionStringName) {
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;
                


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new TodoItemConfiguration());
            modelBuilder.Configurations.Add(new TaxpayerConfiguration());
            modelBuilder.Configurations.Add(new ErrorLogConfiguration());
            modelBuilder.Configurations.Add(new TaxNoticeConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
