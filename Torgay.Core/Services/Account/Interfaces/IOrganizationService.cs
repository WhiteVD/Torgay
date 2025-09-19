using Torgay.Core.Models.Account;
using Torgay.Core.Models.Enums;

namespace Torgay.Core.Services.Account.Interfaces {
    /// <summary>
    /// Сервис для управления организациями
    /// </summary>
    public interface IOrganizationService {
        /// <summary>
        /// Получить организацию по ID
        /// </summary>
        Task<Organization?> GetOrganizationByIdAsync(Guid organizationId);

        /// <summary>
        /// Получить организации пользователя
        /// </summary>
        Task<List<Organization>> GetUserOrganizationsAsync(string userId);

        /// <summary>
        /// Создать новую организацию
        /// </summary>
        Task<Organization> CreateOrganizationAsync(string name, string? description, string ownerId);

        /// <summary>
        /// Обновить организацию
        /// </summary>
        Task<Organization> UpdateOrganizationAsync(Guid organizationId, string name, string? description, string userId);

        /// <summary>
        /// Удалить организацию
        /// </summary>
        Task<bool> DeleteOrganizationAsync(Guid organizationId, string userId);

        /// <summary>
        /// Добавить пользователя в организацию
        /// </summary>
        Task<bool> AddUserToOrganizationAsync(Guid organizationId, string userId, string targetUserId, OrganizationRole role);

        /// <summary>
        /// Удалить пользователя из организации
        /// </summary>
        Task<bool> RemoveUserFromOrganizationAsync(Guid organizationId, string userId, string targetUserId);

        /// <summary>
        /// Изменить роль пользователя в организации
        /// </summary>
        Task<bool> ChangeUserRoleAsync(Guid organizationId, string userId, string targetUserId, OrganizationRole newRole);

        /// <summary>
        /// Получить пользователей организации
        /// </summary>
        Task<List<OrganizationUser>> GetOrganizationUsersAsync(Guid organizationId);

        /// <summary>
        /// Проверить, является ли пользователь владельцем организации
        /// </summary>
        Task<bool> IsOrganizationOwnerAsync(Guid organizationId, string userId);

        /// <summary>
        /// Проверить, имеет ли пользователь доступ к организации
        /// </summary>
        Task<bool> HasOrganizationAccessAsync(Guid organizationId, string userId);
    }
}
