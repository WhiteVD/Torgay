using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torgay.Core.Models.Account;
using Torgay.Core.Services.Account;
using Torgay.Core.Services.Account.Interfaces;

namespace Torgay.Server.Controllers {
    /// <summary>
    /// Контроллер для управления лицензиями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LicensesController : ControllerBase {
        private readonly ILicenseService _licenseService;
        private readonly ILogger<LicensesController> _logger;
        private readonly IUserIdAccessor _userIdAccessor;

        public LicensesController(
            ILicenseService licenseService,
            ILogger<LicensesController> logger,
            IUserIdAccessor userIdAccessor) {
            _licenseService = licenseService;
            _logger = logger;
            _userIdAccessor = userIdAccessor;
        }

        /// <summary>
        /// Получить все доступные лицензии
        /// </summary>
        [HttpGet("available")]
        public async Task<ActionResult<List<License>>> GetAvailableLicenses() {
            try {
                var licenses = await _licenseService.GetAvailableLicensesAsync();
                return Ok(licenses);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting available licenses");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Получить лицензии пользователя
        /// </summary>
        [HttpGet("my")]
        public async Task<ActionResult<List<UserLicense>>> GetUserLicenses() {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var licenses = await _licenseService.GetUserLicensesAsync(userId);
                return Ok(licenses);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting user licenses");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Активировать лицензию для пользователя
        /// </summary>
        [HttpPost("activate/{licenseId}")]
        public async Task<ActionResult<UserLicense>> ActivateLicense(Guid licenseId, [FromBody] ActivateLicenseRequest? request = null) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var userLicense = await _licenseService.ActivateLicenseAsync(
                    userId, licenseId, request?.TransactionId);

                return Ok(userLicense);
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error activating license {LicenseId} for user {UserId}", licenseId, _userIdAccessor.GetCurrentUserId());
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Деактивировать лицензию пользователя
        /// </summary>
        [HttpPost("deactivate/{userLicenseId}")]
        public async Task<IActionResult> DeactivateLicense(Guid userLicenseId) {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var result = await _licenseService.DeactivateLicenseAsync(userLicenseId, userId);

                if (!result) {
                    return NotFound();
                }

                return NoContent();
            } catch (Exception ex) {
                _logger.LogError(ex, "Error deactivating user license {UserLicenseId}", userLicenseId);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Проверить, может ли пользователь создать организацию
        /// </summary>
        [HttpGet("can-create-organization")]
        public async Task<ActionResult<bool>> CanCreateOrganization() {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var canCreate = await _licenseService.CanUserCreateOrganizationAsync(userId);
                return Ok(canCreate);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error checking if user can create organization");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Получить активную лицензию пользователя
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<UserLicense>> GetActiveLicense() {
            try {
                var userId = _userIdAccessor.GetCurrentUserId();
                var activeLicense = await _licenseService.GetActiveUserLicenseAsync(userId);

                if (activeLicense == null) {
                    return NotFound();
                }

                return Ok(activeLicense);
            } catch (Exception ex) {
                _logger.LogError(ex, "Error getting active license for user");
                return StatusCode(500, "Internal server error");
            }
        }
    }

    /// <summary>
    /// Запрос на активацию лицензии
    /// </summary>
    public class ActivateLicenseRequest {
        /// <summary>
        /// ID транзакции (для платных лицензий)
        /// </summary>
        public string? TransactionId { get; set; }
    }
}
