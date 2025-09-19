using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Infrastructure.Configuration {
    public class LicenseConfiguration : IEntityTypeConfiguration<License> {
        public void Configure(EntityTypeBuilder<License> builder) {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Description)
                .HasMaxLength(500);

            builder.Property(l => l.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(l => l.UserLicenses)
                .WithOne(ul => ul.License)
                .HasForeignKey(ul => ul.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.Organizations)
                .WithOne(o => o.License)
                .HasForeignKey(o => o.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
