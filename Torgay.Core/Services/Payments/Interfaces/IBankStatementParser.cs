using Torgay.Core.Models.Payments;

namespace Torgay.Core.Services.Payments.Interfaces {
    /// <summary>
    /// Интерфейс парсера банковских выписок
    /// </summary>
    public interface IBankStatementParser {
        /// <summary>
        /// Парсит банковскую выписку из потока файла
        /// </summary>
        Task<BankStatement> ParseAsync(Stream fileStream, string fileName, Guid organizationId, string userId);
    }
}
