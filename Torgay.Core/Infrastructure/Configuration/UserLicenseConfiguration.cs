using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Infrastructure.Configuration {
    public class UserLicenseConfiguration : IEntityTypeConfiguration<UserLicense> {
        public void Configure(EntityTypeBuilder<UserLicense> builder) {
            builder.HasKey(ul => ul.Id);

            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLicenses)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ul => ul.License)
                .WithMany(l => l.UserLicenses)
                .HasForeignKey(ul => ul.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ul => ul.PurchasePrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(ul => ul.TransactionId)
                .HasMaxLength(50);

            builder.HasIndex(ul => new { ul.UserId, ul.IsActive });
        }
    }
}
