using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Account;
using Torgay.Core.Services.Account.Interfaces;

namespace Torgay.Core.Services.Account {
    public class LicenseService : ILicenseService {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LicenseService> _logger;

        public LicenseService(ApplicationDbContext context, ILogger<LicenseService> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task<List<License>> GetAvailableLicensesAsync() {
            return await _context.Licenses
                .Where(l => l.IsActive)
                .ToListAsync();
        }

        public async Task<License?> GetLicenseByIdAsync(Guid licenseId) {
            return await _context.Licenses
                .FirstOrDefaultAsync(l => l.Id == licenseId);
        }

        public async Task<List<UserLicense>> GetUserLicensesAsync(string userId) {
            return await _context.UserLicenses
                .Where(ul => ul.UserId == userId)
                .Include(ul => ul.License)
                .OrderByDescending(ul => ul.StartDate)
                .ToListAsync();
        }

        public async Task<UserLicense> ActivateLicenseAsync(string userId, Guid licenseId, string? transactionId = null) {
            var license = await _context.Licenses
                .FirstOrDefaultAsync(l => l.Id == licenseId && l.IsActive);

            if (license == null) {
                throw new ArgumentException("License not found or not active");
            }

            // Деактивируем текущие лицензии пользователя
            var activeLicenses = await _context.UserLicenses
                .Where(ul => ul.UserId == userId && ul.IsActive)
                .ToListAsync();

            foreach (var activeLicense in activeLicenses) {
                activeLicense.IsActive = false;
            }

            // Создаем новую лицензию
            var userLicense = new UserLicense {
                UserId = userId,
                LicenseId = licenseId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(license.DurationDays),
                IsActive = true,
                PurchasedAt = DateTime.UtcNow,
                PurchasePrice = license.Price,
                TransactionId = transactionId
            };

            _context.UserLicenses.Add(userLicense);
            await _context.SaveChangesAsync();

            _logger.LogInformation("License {LicenseId} activated for user {UserId}", licenseId, userId);

            return userLicense;
        }

        public async Task<bool> DeactivateLicenseAsync(Guid userLicenseId, string userId) {
            var userLicense = await _context.UserLicenses
                .FirstOrDefaultAsync(ul => ul.Id == userLicenseId && ul.UserId == userId);

            if (userLicense == null) {
                return false;
            }

            userLicense.IsActive = false;
            await _context.SaveChangesAsync();

            _logger.LogInformation("User license {UserLicenseId} deactivated by user {UserId}", userLicenseId, userId);

            return true;
        }

        public async Task<bool> CanUserCreateOrganizationAsync(string userId) {
            var activeLicense = await GetActiveUserLicenseAsync(userId);
            if (activeLicense == null) {
                return false;
            }

            // Получаем количество организаций пользователя
            var organizationCount = await _context.Organizations
                .CountAsync(o => o.OwnerId == userId && o.IsActive);

            return organizationCount < activeLicense.License.MaxOrganizations;
        }

        public async Task<UserLicense?> GetActiveUserLicenseAsync(string userId) {
            return await _context.UserLicenses
                .Include(ul => ul.License)
                .FirstOrDefaultAsync(ul => ul.UserId == userId && ul.IsActive && ul.EndDate > DateTime.UtcNow);
        }

        public async Task<License> CreateLicenseAsync(License license) {
            license.Id = Guid.NewGuid();
            license.CreatedAt = DateTime.UtcNow;
            license.UpdatedAt = null;

            _context.Licenses.Add(license);
            await _context.SaveChangesAsync();

            _logger.LogInformation("License {LicenseName} created", license.Name);

            return license;
        }

        public async Task<License> UpdateLicenseAsync(License license) {
            var existingLicense = await _context.Licenses
                .FirstOrDefaultAsync(l => l.Id == license.Id);

            if (existingLicense == null) {
                throw new ArgumentException("License not found");
            }

            existingLicense.Name = license.Name;
            existingLicense.Description = license.Description;
            existingLicense.Type = license.Type;
            existingLicense.MaxUsers = license.MaxUsers;
            existingLicense.MaxOrganizations = license.MaxOrganizations;
            existingLicense.IsActive = license.IsActive;
            existingLicense.Price = license.Price;
            existingLicense.DurationDays = license.DurationDays;
            existingLicense.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("License {LicenseId} updated", license.Id);

            return existingLicense;
        }
    }
}
