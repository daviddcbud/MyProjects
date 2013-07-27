
using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class TodoItemConfiguration : EntityTypeConfiguration<TodoItem>
    {
        public TodoItemConfiguration()
        {
            this.Property((p) => p.Id).HasColumnOrder(0);
            //this.Property((p) => p.UserId).IsRequired();
            this.Property((p) => p.Message).IsRequired().HasMaxLength(8000);

             
             
        }
    }
}
