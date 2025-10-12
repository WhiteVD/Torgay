using Microsoft.Extensions.Logging;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    /// <summary>
    /// Парсер банковских выписок в формате PDF
    /// </summary>
    public class PdfBankStatementParser : IBankStatementParser {
        private readonly ILogger<PdfBankStatementParser> _logger;

        public PdfBankStatementParser(ILogger<PdfBankStatementParser> logger) {
            _logger = logger;
        }

        public async Task<BankStatement> ParseAsync(Stream fileStream, string fileName, Guid organizationId, string userId) {
            // Для простоты реализации используем базовый парсинг текста PDF
            // В реальном проекте следует использовать специализированные библиотеки (iTextSharp, PdfPig и т.д.)

            _logger.LogInformation("Начало парсинга PDF выписки для организации {OrganizationId}", organizationId);

            // Заглушка для реализации - в реальном проекте нужно добавить парсинг PDF
            throw new NotImplementedException("PDF парсер будет реализован в будущих версиях");

            // return await ParsePdfContent(fileStream, organizationId, userId);
        }
    }
}
