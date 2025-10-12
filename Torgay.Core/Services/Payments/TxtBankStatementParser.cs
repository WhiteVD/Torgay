using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Payments.Interfaces;

namespace Torgay.Core.Services.Payments {
    /// <summary>
    /// Парсер банковских выписок в формате 1C (TXT)
    /// </summary>
    public class TxtBankStatementParser : IBankStatementParser {
        private readonly ILogger<TxtBankStatementParser> _logger;

        public TxtBankStatementParser(ILogger<TxtBankStatementParser> logger) {
            _logger = logger;
        }

        public async Task<BankStatement> ParseAsync(Stream fileStream, string fileName, Guid organizationId, string userId) {
            using var reader = new StreamReader(fileStream);
            var content = await reader.ReadToEndAsync();

            _logger.LogInformation("Начало парсинга TXT выписки для организации {OrganizationId}", organizationId);

            var bankStatement = new BankStatement {
                Organization_id = organizationId,
                CreatedBy = userId,
                CreatedDate = DateTime.UtcNow
            };

            var transactions = new List<BankTransaction>();
            BankTransaction? currentTransaction = null;

            var lines = content.Split('\n');
            foreach (var line in lines) {
                var trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("ДатаНачала=")) {
                    bankStatement.PeriodFrom = ParseDate(trimmedLine.Split('=')[1]);
                } else if (trimmedLine.StartsWith("ДатаКонца=")) {
                    bankStatement.PeriodTo = ParseDate(trimmedLine.Split('=')[1]);
                } else if (trimmedLine.StartsWith("РасчСчет=")) {
                    bankStatement.AccountNumber = trimmedLine.Split('=')[1];
                } else if (trimmedLine.StartsWith("НачальныйОстаток=")) {
                    bankStatement.InitialBalance = decimal.Parse(trimmedLine.Split('=')[1]);
                } else if (trimmedLine.StartsWith("КонечныйОстаток=")) {
                    bankStatement.FinalBalance = decimal.Parse(trimmedLine.Split('=')[1]);
                } else if (trimmedLine.StartsWith("СекцияДокумент=выписка")) {
                    currentTransaction = new BankTransaction();
                } else if (trimmedLine.StartsWith("КонецДокумента")) {
                    if (currentTransaction != null) {
                        transactions.Add(currentTransaction);
                        currentTransaction = null;
                    }
                } else if (currentTransaction != null) {
                    ParseTransactionLine(trimmedLine, currentTransaction);
                }
            }

            bankStatement.Transactions = transactions;
            bankStatement.LastMovementDate = transactions.Max(t => t.OperationDate);

            _logger.LogInformation("Успешно распаршено {TransactionCount} транзакций", transactions.Count);

            return bankStatement;
        }

        private DateTime ParseDate(string dateStr) {
            return DateTime.ParseExact(dateStr, "dd.MM.yyyy", null);
        }

        private void ParseTransactionLine(string line, BankTransaction transaction) {
            var parts = line.Split('=', 2);
            if (parts.Length != 2) return;

            var key = parts[0];
            var value = parts[1];

            switch (key) {
                case "ДатаДокумента":
                    transaction.OperationDate = ParseDate(value);
                    break;
                case "НомерДокумента":
                    transaction.DocumentNumber = value;
                    break;
                case "ВидДокумента":
                    transaction.DocumentType = value;
                    break;
                case "ПолучательНаименование":
                    transaction.RecipientName = value;
                    break;
                case "ПолучательБИН_ИИН":
                    transaction.RecipientBinInn = value;
                    break;
                case "ПолучательИИК":
                    transaction.RecipientIik = value;
                    break;
                case "ПолучательБанкБИК":
                    transaction.RecipientBankBik = value;
                    break;
                case "ПолучательКБЕ":
                    transaction.RecipientKbe = value;
                    break;
                case "ПлательщикНаименование":
                    transaction.PayerName = value;
                    break;
                case "ПлательщикБИН_ИИН":
                    transaction.PayerBinInn = value;
                    break;
                case "ПлательщикИИК":
                    transaction.PayerIik = value;
                    break;
                case "ПлательщикБанкБИК":
                    transaction.PayerBankBik = value;
                    break;
                case "ПлательщикКБЕ":
                    transaction.PayerKbe = value;
                    break;
                case "СуммаРасход":
                    transaction.Debit = decimal.Parse(value);
                    break;
                case "СуммаПриход":
                    transaction.Credit = decimal.Parse(value);
                    break;
                case "НазначениеПлатежа":
                    transaction.PaymentPurpose = value;
                    break;
                case "КодНазначенияПлатежа":
                    transaction.PaymentCode = value;
                    break;
            }
        }
    }
}
