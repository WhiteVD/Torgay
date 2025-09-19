using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Infrastructure.Configuration {
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization> {
        public void Configure(EntityTypeBuilder<Organization> builder) {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(o => o.Description)
                .HasMaxLength(500);

            builder.HasOne(o => o.Owner)
                .WithMany(u => u.OwnedOrganizations)
                .HasForeignKey(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.License)
                .WithMany(l => l.Organizations)
                .HasForeignKey(o => o.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.OrganizationUsers)
                .WithOne(ou => ou.Organization)
                .HasForeignKey(ou => ou.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
