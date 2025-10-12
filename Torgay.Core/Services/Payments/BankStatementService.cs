using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Torgay.Core.DTO;
using Torgay.Core.Infrastructure;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    /// <summary>
    /// Сервис для работы с банковскими выписками
    /// </summary>
    public class BankStatementService {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<BankStatementService> _logger;
        private readonly Dictionary<string, IBankStatementParser> _parsers;

        public BankStatementService(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ILogger<BankStatementService> logger,
            IEnumerable<IBankStatementParser> parsers) {
            _context = context;
            _userManager = userManager;
            _logger = logger;

            _parsers = new Dictionary<string, IBankStatementParser>(StringComparer.OrdinalIgnoreCase) {
                [".txt"] = parsers.First(p => p is TxtBankStatementParser),
                [".xlsx"] = parsers.First(p => p is XlsxBankStatementParser),
                [".pdf"] = parsers.First(p => p is PdfBankStatementParser)
            };
        }

        /// <summary>
        /// Загружает банковскую выписку
        /// </summary>
        public async Task<BankStatement> UploadBankStatementAsync(UploadBankStatementDto uploadDto, string userId) {
            _logger.LogInformation("Пользователь {UserId} начинает загрузку выписки для организации {OrganizationId}",
                userId, uploadDto.OrganizationId);

            // Проверяем организацию
            var organization = await _context.Organizations
                .FirstOrDefaultAsync(o => o.Id == uploadDto.OrganizationId);

            if (organization == null) {
                _logger.LogWarning("Организация {OrganizationId} не найдена", uploadDto.OrganizationId);
                throw new ArgumentException("Организация не найдена");
            }

            // Определяем парсер по расширению файла
            var fileExtension = Path.GetExtension(uploadDto.File.FileName).ToLower();
            if (!_parsers.ContainsKey(fileExtension)) {
                _logger.LogWarning("Неподдерживаемый формат файла: {FileExtension}", fileExtension);
                throw new NotSupportedException($"Формат файла {fileExtension} не поддерживается");
            }

            var parser = _parsers[fileExtension];

            using var stream = uploadDto.File.OpenReadStream();
            var bankStatement = await parser.ParseAsync(stream, uploadDto.File.FileName, uploadDto.OrganizationId, userId);

            // Сохраняем в базу данных
            await _context.BankStatements.AddAsync(bankStatement);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Выписка {StatementId} успешно загружена пользователем {UserId}",
                bankStatement.Id, userId);

            return bankStatement;
        }

        /// <summary>
        /// Получает выписки по организации
        /// </summary>
        public async Task<List<BankStatementDto>> GetBankStatementsByOrganizationAsync(Guid organizationId) {
            return await _context.BankStatements
                .Where(bs => bs.Organization_id == organizationId)
                .OrderByDescending(bs => bs.CreatedDate)
                .Select(bs => new BankStatementDto {
                    Id = bs.Id,
                    AccountNumber = bs.AccountNumber,
                    Currency = bs.Currency,
                    PeriodFrom = bs.PeriodFrom,
                    PeriodTo = bs.PeriodTo,
                    InitialBalance = bs.InitialBalance,
                    FinalBalance = bs.FinalBalance,
                    OrganizationName = bs.StatementOrganizationName,
                    OrganizationBin = bs.StatementOrganizationBin,
                    CreatedAt = bs.CreatedDate,
                    TransactionCount = bs.Transactions.Count
                })
                .ToListAsync();
        }

        /// <summary>
        /// Получает детали выписки
        /// </summary>
        public async Task<BankStatement?> GetBankStatementDetailsAsync(Guid statementId) {
            return await _context.BankStatements
                .Include(bs => bs.Transactions)
                .Include(bs => bs.Organization_id)
                .Include(bs => bs.CreatedBy)
                .FirstOrDefaultAsync(bs => bs.Id == statementId);
        }

        /// <summary>
        /// Получает выписки по пользователю
        /// </summary>
        public async Task<List<BankStatementDto>> GetBankStatementsByUserAsync(string userId) {
            return await _context.BankStatements
                .Where(bs => bs.CreatedBy == userId)
                .OrderByDescending(bs => bs.CreatedDate)
                .Select(bs => new BankStatementDto {
                    Id = bs.Id,
                    AccountNumber = bs.AccountNumber,
                    Currency = bs.Currency,
                    PeriodFrom = bs.PeriodFrom,
                    PeriodTo = bs.PeriodTo,
                    InitialBalance = bs.InitialBalance,
                    FinalBalance = bs.FinalBalance,
                    OrganizationName = bs.StatementOrganizationName,
                    OrganizationBin = bs.StatementOrganizationBin,
                    CreatedAt = bs.CreatedDate,
                    TransactionCount = bs.Transactions.Count,
                    UploadedByUserName = bs.User.UserName ?? bs.User.Email ?? "Неизвестно"
                })
                .ToListAsync();
        }
    }
}
