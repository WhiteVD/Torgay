using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    /// <summary>
    /// Парсер банковских выписок в формате XLSX
    /// </summary>
    public class XlsxBankStatementParser : IBankStatementParser {
        private readonly ILogger<XlsxBankStatementParser> _logger;

        public XlsxBankStatementParser(ILogger<XlsxBankStatementParser> logger) {
            _logger = logger;
        }

        public async Task<BankStatement> ParseAsync(Stream fileStream, string fileName, Guid organizationId, string userId) {
            ExcelPackage.License.SetNonCommercialPersonal("<Your Name>");
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(fileStream);
            var worksheet = package.Workbook.Worksheets[0]; // Первый лист

            _logger.LogInformation("Начало парсинга XLSX выписки для организации {OrganizationId}", organizationId);

            var bankStatement = new BankStatement {
                Organization_id = organizationId,
                CreatedBy = userId,
                CreatedDate = DateTime.UtcNow
            };

            // Парсинг основных данных
            bankStatement.AccountNumber = worksheet.Cells["B3"].Text.Trim();
            bankStatement.Currency = worksheet.Cells["B4"].Text.Trim();

            var periodText = worksheet.Cells["B5"].Text.Trim();
            var periodParts = periodText.Split(" - ");
            if (periodParts.Length == 2) {
                bankStatement.PeriodFrom = DateTime.Parse(periodParts[0]);
                bankStatement.PeriodTo = DateTime.Parse(periodParts[1]);
            }

            bankStatement.StatementOrganizationBin = worksheet.Cells["B7"].Text.Trim();
            bankStatement.StatementOrganizationName = worksheet.Cells["B8"].Text.Trim();
            bankStatement.InitialBalance = decimal.Parse(worksheet.Cells["B9"].Text.Trim());
            bankStatement.FinalBalance = decimal.Parse(worksheet.Cells["B10"].Text.Trim());

            // Парсинг транзакций
            var transactions = new List<BankTransaction>();
            var row = 13; // Начало данных транзакций

            while (!string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text)) {
                var transaction = ParseTransactionRow(worksheet, row);
                if (transaction != null) {
                    transactions.Add(transaction);
                }
                row++;
            }

            bankStatement.Transactions = transactions;
            bankStatement.LastMovementDate = transactions.Max(t => t.OperationDate);

            _logger.LogInformation("Успешно распаршено {TransactionCount} транзакций из XLSX", transactions.Count);

            return bankStatement;
        }

        private BankTransaction? ParseTransactionRow(ExcelWorksheet worksheet, int row) {
            try {
                var docNumber = worksheet.Cells[row, 1].Text.Trim();
                if (string.IsNullOrWhiteSpace(docNumber) || docNumber == "Итого")
                    return null;

                var operationDateStr = worksheet.Cells[row, 2].Text.Trim();
                var debitStr = worksheet.Cells[row, 3].Text.Trim();
                var creditStr = worksheet.Cells[row, 4].Text.Trim();
                var counterpartyInfo = worksheet.Cells[row, 5].Text.Trim();
                var iik = worksheet.Cells[row, 6].Text.Trim();
                var bik = worksheet.Cells[row, 7].Text.Trim();
                var knp = worksheet.Cells[row, 8].Text.Trim();
                var purpose = worksheet.Cells[row, 9].Text.Trim();

                var transaction = new BankTransaction {
                    DocumentNumber = docNumber,
                    OperationDate = DateTime.Parse(operationDateStr),
                    PaymentPurpose = purpose,
                    PaymentCode = knp,
                    CreatedAt = DateTime.UtcNow
                };

                // Определяем дебет/кредит
                if (!string.IsNullOrWhiteSpace(debitStr))
                    transaction.Debit = decimal.Parse(debitStr);
                if (!string.IsNullOrWhiteSpace(creditStr))
                    transaction.Credit = decimal.Parse(creditStr);

                // Парсим информацию о контрагенте
                ParseCounterpartyInfo(counterpartyInfo, transaction, string.IsNullOrWhiteSpace(debitStr));

                transaction.RecipientIik = iik;
                transaction.RecipientBankBik = bik;
                transaction.PayerBankBik = bik;

                return transaction;
            } catch (Exception ex) {
                _logger.LogWarning(ex, "Ошибка парсинга строки {Row} в XLSX файле", row);
                return null;
            }
        }

        private void ParseCounterpartyInfo(string counterpartyInfo, BankTransaction transaction, bool isIncome) {
            var lines = counterpartyInfo.Split('\n');
            if (lines.Length >= 1) {
                var name = lines[0].Trim();
                if (lines.Length >= 2) {
                    var binLine = lines[1].Trim();
                    if (binLine.StartsWith("ИИН/БИН")) {
                        var bin = binLine.Replace("ИИН/БИН", "").Trim();
                        if (isIncome) {
                            transaction.PayerName = name;
                            transaction.PayerBinInn = bin;
                        } else {
                            transaction.RecipientName = name;
                            transaction.RecipientBinInn = bin;
                        }
                    }
                }
            }
        }
    }
}
