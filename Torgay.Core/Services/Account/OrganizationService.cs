using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Enums;
using Torgay.Core.Services.Account.Interfaces;

namespace Torgay.Core.Services.Account {
    public class OrganizationService : IOrganizationService {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrganizationService> _logger;
        private readonly ILicenseService _licenseService;

        public OrganizationService(
            ApplicationDbContext context,
            ILogger<OrganizationService> logger,
            ILicenseService licenseService) {
            _context = context;
            _logger = logger;
            _licenseService = licenseService;
        }

        public async Task<Organization?> GetOrganizationByIdAsync(Guid organizationId) {
            return await _context.Organizations
                .Include(o => o.Owner)
                .Include(o => o.OrganizationUsers)
                .ThenInclude(ou => ou.User)
                .FirstOrDefaultAsync(o => o.Id == organizationId);
        }

        public async Task<List<Organization>> GetUserOrganizationsAsync(string userId) {
            return await _context.Organizations
                .Where(o => o.OrganizationUsers.Any(ou => ou.UserId == userId))
                .Include(o => o.Owner)
                .ToListAsync();
        }

        public async Task<Organization> CreateOrganizationAsync(string name, string? description, string ownerId) {
            // Проверяем, может ли пользователь создать организацию
            var canCreate = await _licenseService.CanUserCreateOrganizationAsync(ownerId);
            if (!canCreate) {
                throw new InvalidOperationException("User cannot create more organizations with current license");
            }

            // Получаем активную лицензию пользователя
            var activeLicense = await _licenseService.GetActiveUserLicenseAsync(ownerId);
            if (activeLicense == null) {
                throw new InvalidOperationException("User does not have an active license");
            }

            var organization = new Organization {
                Name = name,
                Description = description,
                OwnerId = ownerId,
                LicenseId = activeLicense.LicenseId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Organizations.Add(organization);

            // Добавляем владельца в организацию
            var organizationUser = new OrganizationUser {
                Organization = organization,
                UserId = ownerId,
                Role = OrganizationRole.Owner,
                JoinedAt = DateTime.UtcNow
            };

            _context.OrganizationUsers.Add(organizationUser);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Organization {OrganizationName} created by user {UserId}", name, ownerId);

            return organization;
        }

        public async Task<Organization> UpdateOrganizationAsync(Guid organizationId, string name, string? description, string userId) {
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organization == null) {
                throw new ArgumentException("Organization not found");
            }

            // Проверяем, является ли пользователь владельцем
            if (organization.OwnerId != userId) {
                throw new UnauthorizedAccessException("Only organization owner can update organization");
            }

            organization.Name = name;
            organization.Description = description;
            organization.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Organization {OrganizationId} updated by user {UserId}", organizationId, userId);

            return organization;
        }

        public async Task<bool> DeleteOrganizationAsync(Guid organizationId, string userId) {
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organization == null) {
                return false;
            }

            // Проверяем, является ли пользователь владельцем
            if (organization.OwnerId != userId) {
                throw new UnauthorizedAccessException("Only organization owner can delete organization");
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Organization {OrganizationId} deleted by user {UserId}", organizationId, userId);

            return true;
        }

        public async Task<bool> AddUserToOrganizationAsync(Guid organizationId, string userId, string targetUserId, OrganizationRole role) {
            // Проверяем права пользователя
            if (!await HasOrganizationManagementAccessAsync(organizationId, userId)) {
                throw new UnauthorizedAccessException("User does not have permission to add users to organization");
            }

            // Проверяем, не добавлен ли уже пользователь
            var existingUser = await _context.OrganizationUsers
                .FirstOrDefaultAsync(ou => ou.OrganizationId == organizationId && ou.UserId == targetUserId);

            if (existingUser != null) {
                return false;
            }

            var organizationUser = new OrganizationUser {
                OrganizationId = organizationId,
                UserId = targetUserId,
                Role = role,
                JoinedAt = DateTime.UtcNow
            };

            _context.OrganizationUsers.Add(organizationUser);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User {TargetUserId} added to organization {OrganizationId} by user {UserId}",
                targetUserId, organizationId, userId);

            return true;
        }

        public async Task<bool> RemoveUserFromOrganizationAsync(Guid organizationId, string userId, string targetUserId) {
            // Проверяем права пользователя
            if (!await HasOrganizationManagementAccessAsync(organizationId, userId)) {
                throw new UnauthorizedAccessException("User does not have permission to remove users from organization");
            }

            // Не позволяем удалять владельца
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organization != null && organization.OwnerId == targetUserId) {
                throw new InvalidOperationException("Cannot remove organization owner");
            }

            var organizationUser = await _context.OrganizationUsers
                .FirstOrDefaultAsync(ou => ou.OrganizationId == organizationId && ou.UserId == targetUserId);

            if (organizationUser == null) {
                return false;
            }

            _context.OrganizationUsers.Remove(organizationUser);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User {TargetUserId} removed from organization {OrganizationId} by user {UserId}",
                targetUserId, organizationId, userId);

            return true;
        }

        public async Task<bool> ChangeUserRoleAsync(Guid organizationId, string userId, string targetUserId, OrganizationRole newRole) {
            // Проверяем права пользователя
            if (!await HasOrganizationManagementAccessAsync(organizationId, userId)) {
                throw new UnauthorizedAccessException("User does not have permission to change user roles");
            }

            // Не позволяем изменять роль владельца
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organization != null && organization.OwnerId == targetUserId) {
                throw new InvalidOperationException("Cannot change role of organization owner");
            }

            var organizationUser = await _context.OrganizationUsers
                .FirstOrDefaultAsync(ou => ou.OrganizationId == organizationId && ou.UserId == targetUserId);

            if (organizationUser == null) {
                return false;
            }

            organizationUser.Role = newRole;
            organizationUser.LastModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("User {TargetUserId} role changed to {NewRole} in organization {OrganizationId} by user {UserId}",
                targetUserId, newRole, organizationId, userId);

            return true;
        }

        public async Task<List<OrganizationUser>> GetOrganizationUsersAsync(Guid organizationId) {
            return await _context.OrganizationUsers
                .Where(ou => ou.OrganizationId == organizationId)
                .Include(ou => ou.User)
                .ToListAsync();
        }

        public async Task<bool> IsOrganizationOwnerAsync(Guid organizationId, string userId) {
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            return organization != null && organization.OwnerId == userId;
        }

        public async Task<bool> HasOrganizationAccessAsync(Guid organizationId, string userId) {
            return await _context.OrganizationUsers
                .AnyAsync(ou => ou.OrganizationId == organizationId && ou.UserId == userId);
        }

        private async Task<bool> HasOrganizationManagementAccessAsync(Guid organizationId, string userId) {
            var organizationUser = await _context.OrganizationUsers
                .FirstOrDefaultAsync(ou => ou.OrganizationId == organizationId && ou.UserId == userId);

            return organizationUser != null &&
                   (organizationUser.Role == OrganizationRole.Owner || organizationUser.Role == OrganizationRole.Admin);
        }
    }
}
