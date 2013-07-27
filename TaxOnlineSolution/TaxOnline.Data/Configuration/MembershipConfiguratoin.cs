using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxOnline.Models;

namespace TaxOnline.Data.Configuration
{
    public class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
     public MembershipConfiguration()
       {
           ToTable("webpages_Membership");
           HasKey(p => p.UserId);
           Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
           Property(p => p.ConfirmationToken).HasMaxLength(128).HasColumnType("nvarchar");
           Property(p => p.PasswordFailuresSinceLastSuccess).IsRequired();
           Property(p => p.Password).IsRequired();
           Property(p => p.PasswordSalt).IsRequired().HasMaxLength(128).HasColumnType("nvarchar");
           Property(p => p.PasswordVerificationToken).HasMaxLength(128).HasColumnType("nvarchar");

       }
    }
}
