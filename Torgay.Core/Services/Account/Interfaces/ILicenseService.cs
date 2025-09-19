using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Services.Account.Interfaces {
    /// <summary>
    /// Сервис для управления лицензиями
    /// </summary>
    public interface ILicenseService {
        /// <summary>
        /// Получить все доступные лицензии
        /// </summary>
        Task<List<License>> GetAvailableLicensesAsync();

        /// <summary>
        /// Получить лицензию по ID
        /// </summary>
        Task<License?> GetLicenseByIdAsync(Guid licenseId);

        /// <summary>
        /// Получить активные лицензии пользователя
        /// </summary>
        Task<List<UserLicense>> GetUserLicensesAsync(string userId);

        /// <summary>
        /// Активировать лицензию для пользователя
        /// </summary>
        Task<UserLicense> ActivateLicenseAsync(string userId, Guid licenseId, string? transactionId = null);

        /// <summary>
        /// Деактивировать лицензию пользователя
        /// </summary>
        Task<bool> DeactivateLicenseAsync(Guid userLicenseId, string userId);

        /// <summary>
        /// Проверить, может ли пользователь создать организацию
        /// </summary>
        Task<bool> CanUserCreateOrganizationAsync(string userId);

        /// <summary>
        /// Получить текущую активную лицензию пользователя
        /// </summary>
        Task<UserLicense?> GetActiveUserLicenseAsync(string userId);

        /// <summary>
        /// Создать лицензию (для администрирования)
        /// </summary>
        Task<License> CreateLicenseAsync(License license);

        /// <summary>
        /// Обновить лицензию (для администрирования)
        /// </summary>
        Task<License> UpdateLicenseAsync(License license);
    }
}
