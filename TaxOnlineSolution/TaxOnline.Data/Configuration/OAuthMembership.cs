using System.Data.Entity.ModelConfiguration;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            ToTable("webpages_OAuthMembership");
            HasKey(p => new { p.Provider, p.ProviderUserId });
            Property(p => p.ProviderUserId).HasMaxLength(100).HasColumnType("nvarchar");
            Property(p => p.Provider).HasMaxLength(30).HasColumnType("nvarchar");
            Property(p => p.UserId).IsRequired();
        }
    }

}
