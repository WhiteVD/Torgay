using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Infrastructure.Configuration {
    public class OrganizationUserConfiguration : IEntityTypeConfiguration<OrganizationUser> {
        public void Configure(EntityTypeBuilder<OrganizationUser> builder) {
            builder.HasKey(ou => ou.Id);

            builder.HasOne(ou => ou.Organization)
                .WithMany(o => o.OrganizationUsers)
                .HasForeignKey(ou => ou.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ou => ou.User)
                .WithMany(u => u.OrganizationUsers)
                .HasForeignKey(ou => ou.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ou => new { ou.OrganizationId, ou.UserId })
                .IsUnique();
        }
    }
}
