using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;



namespace TaxOnline.Data.Configuration
{
    class RolesConfiguration : EntityTypeConfiguration<Role>
    {
        public RolesConfiguration()
        {
            ToTable("webpages_Roles");
            Property(p => p.RoleName).HasMaxLength(256).IsRequired();
        }
    }
}
