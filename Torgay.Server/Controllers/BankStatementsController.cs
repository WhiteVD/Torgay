using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Torgay.Core.DTO;
using Torgay.Core.Models.Account;
using Torgay.Core.Services.Payments;

namespace Torgay.Server.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BankStatementsController : ControllerBase {
        private readonly BankStatementService _bankStatementService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<BankStatementsController> _logger;

        public BankStatementsController(
            BankStatementService bankStatementService,
            UserManager<ApplicationUser> userManager,
            ILogger<BankStatementsController> logger) {
            _bankStatementService = bankStatementService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBankStatement([FromForm] UploadBankStatementDto uploadDto) {
            try {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId)) {
                    _logger.LogWarning("Не удалось идентифицировать пользователя при загрузке выписки");
                    return Unauthorized("Пользователь не идентифицирован");
                }

                var bankStatement = await _bankStatementService.UploadBankStatementAsync(uploadDto, userId);

                return Ok(new {
                    Message = "Выписка успешно загружена",
                    StatementId = bankStatement.Id,
                    TransactionCount = bankStatement.Transactions.Count
                });
            } catch (Exception ex) {
                _logger.LogError(ex, "Ошибка при загрузке банковской выписки для организации {OrganizationId}",
                    uploadDto.OrganizationId);
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<IActionResult> GetBankStatementsByOrganization(Guid organizationId) {
            try {
                var statements = await _bankStatementService.GetBankStatementsByOrganizationAsync(organizationId);
                return Ok(statements);
            } catch (Exception ex) {
                _logger.LogError(ex, "Ошибка при получении выписок для организации {OrganizationId}", organizationId);
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("user/my-statements")]
        public async Task<IActionResult> GetMyBankStatements() {
            try {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId)) {
                    return Unauthorized("Пользователь не идентифицирован");
                }

                var statements = await _bankStatementService.GetBankStatementsByUserAsync(userId);
                return Ok(statements);
            } catch (Exception ex) {
                _logger.LogError(ex, "Ошибка при получении выписок пользователя");
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{statementId}")]
        public async Task<IActionResult> GetBankStatementDetails(Guid statementId) {
            try {
                var statement = await _bankStatementService.GetBankStatementDetailsAsync(statementId);
                if (statement == null) {
                    return NotFound(new { Error = "Выписка не найдена" });
                }

                return Ok(statement);
            } catch (Exception ex) {
                _logger.LogError(ex, "Ошибка при получении деталей выписки {StatementId}", statementId);
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
