using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    /// <summary>
    /// Банковская транзакция в выписке
    /// </summary>
    public class BankTransaction : ClientEntry {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BankStatementId { get; set; }

        [ForeignKey("BankStatementId")]
        public virtual BankStatement BankStatement { get; set; } = null!;

        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        public DateTime OperationDate { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        // Для получателя
        public string? RecipientName { get; set; }
        public string? RecipientBinInn { get; set; }
        public string? RecipientIik { get; set; }
        public string? RecipientBankBik { get; set; }
        public string? RecipientKbe { get; set; }

        // Для плательщика
        public string? PayerName { get; set; }
        public string? PayerBinInn { get; set; }
        public string? PayerIik { get; set; }
        public string? PayerBankBik { get; set; }
        public string? PayerKbe { get; set; }

        public decimal? Debit { get; set; } // Списание
        public decimal? Credit { get; set; } // Поступление

        public string PaymentPurpose { get; set; } = string.Empty;
        public string PaymentCode { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
