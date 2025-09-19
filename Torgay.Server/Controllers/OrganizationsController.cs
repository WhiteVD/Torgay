using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Enums;
using Torgay.Core.Services.Account;
using Torgay.Core.Services.Account.Interfaces;

namespace Torgay.Server.Controllers {
    /// <summary>
    /// Контроллер для управления организациями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase {
        private readonly IOrganizationService _organizationService;
        private readonly ILogger<OrganizationsController> _logger;
        private readonly IUserIdAccessor _userIdAccessor;

        public OrganizationsController(
            IOrganizationService organizationService,
            ILogger<OrganizationsController> logger,
            IUserIdAccessor userIdAccessor) {
            _organizationService = organizationService;
            _logger = logger;
            _userIdAccessor = userIdAccessor;
        }

        /// <summary>
        /// Получить все организации пользователя
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Organization>>> GetUserOrganizations() {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var organizations = await _organizationService.GetUserOrganizationsAsync(userId);
                return Ok(organizations);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting user organizations");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Получить организацию по ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(Guid id) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();

                // Проверяем доступ пользователя к организации
                if (!await _organizationService.HasOrganizationAccessAsync(id, userId)) {
                    return Forbid();
                }

                var organization = await _organizationService.GetOrganizationByIdAsync(id);
                if (organization == null) {
                    return NotFound();
                }

                return Ok(organization);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Создать новую организацию
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Organization>> CreateOrganization([FromBody] CreateOrganizationRequest request) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var organization = await _organizationService.CreateOrganizationAsync(
                    request.Name, request.Description, userId);

                return CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organization);
            } catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error creating organization");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Обновить организацию
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<Organization>> UpdateOrganization(Guid id, [FromBody] UpdateOrganizationRequest request) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var organization = await _organizationService.UpdateOrganizationAsync(
                    id, request.Name, request.Description, userId);

                return Ok(organization);
            } catch (ArgumentException ex) {
                return NotFound(ex.Message);
            } catch (UnauthorizedAccessException ex) {
                return Forbid(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error updating organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Удалить организацию
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var result = await _organizationService.DeleteOrganizationAsync(id, userId);

                if (!result) {
                    return NotFound();
                }

                return NoContent();
            } catch (UnauthorizedAccessException ex) {
                return Forbid(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error deleting organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Получить пользователей организации
        /// </summary>
        [HttpGet("{id}/users")]
        public async Task<ActionResult<List<OrganizationUser>>> GetOrganizationUsers(Guid id) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();

                // Проверяем доступ пользователя к организации
                if (!await _organizationService.HasOrganizationAccessAsync(id, userId)) {
                    return Forbid();
                }

                var users = await _organizationService.GetOrganizationUsersAsync(id);
                return Ok(users);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting organization users for {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Добавить пользователя в организацию
        /// </summary>
        [HttpPost("{id}/users")]
        public async Task<IActionResult> AddUserToOrganization(Guid id, [FromBody] AddUserToOrganizationRequest request) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var result = await _organizationService.AddUserToOrganizationAsync(
                    id, userId, request.UserId, request.Role);

                if (!result) {
                    return BadRequest("User already in organization");
                }

                return NoContent();
            } catch (UnauthorizedAccessException ex) {
                return Forbid(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error adding user to organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Удалить пользователя из организации
        /// </summary>
        [HttpDelete("{id}/users/{userId}")]
        public async Task<IActionResult> RemoveUserFromOrganization(Guid id, string userId) {
            try {
                var currentUserId = _userIdAccessor.GetCurrentUserId();
                var result = await _organizationService.RemoveUserFromOrganizationAsync(id, currentUserId, userId);

                if (!result) {
                    return NotFound();
                }

                return NoContent();
            } catch (UnauthorizedAccessException ex) {
                return Forbid(ex.Message);
            } catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error removing user from organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Изменить роль пользователя в организации
        /// </summary>
        [HttpPatch("{id}/users/{userId}/role")]
        public async Task<IActionResult> ChangeUserRole(Guid id, string userId, [FromBody] ChangeUserRoleRequest request) {
            try {
                var currentUserId = _userIdAccessor.GetCurrentUserId();
                var result = await _organizationService.ChangeUserRoleAsync(id, currentUserId, userId, request.Role);

                if (!result) {
                    return NotFound();
                }

                return NoContent();
            } catch (UnauthorizedAccessException ex) {
                return Forbid(ex.Message);
            } catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error changing user role in organization {OrganizationId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }

    /// <summary>
    /// Запрос на создание организации
    /// </summary>
    public class CreateOrganizationRequest {
        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание организации
        /// </summary>
        public string? Description { get; set; }
    }

    /// <summary>
    /// Запрос на обновление организации
    /// </summary>
    public class UpdateOrganizationRequest {
        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание организации
        /// </summary>
        public string? Description { get; set; }
    }

    /// <summary>
    /// Запрос на добавление пользователя в организацию
    /// </summary>
    public class AddUserToOrganizationRequest {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Роль пользователя в организации
        /// </summary>
        public OrganizationRole Role { get; set; }
    }

    /// <summary>
    /// Запрос на изменение роли пользователя
    /// </summary>
    public class ChangeUserRoleRequest {
        /// <summary>
        /// Новая роль пользователя
        /// </summary>
        public OrganizationRole Role { get; set; }
    }
}
