using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    /// <summary>
    /// Банковская транзакция в выписке
    /// </summary>
    public class BankTransaction {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid BankStatementId { get; set; }

        [ForeignKey("BankStatementId")]
        public virtual BankStatement BankStatement { get; set; } = null!;

        [StringLength(50)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        public DateTime OperationDate { get; set; }

        [StringLength(100)]
        public string DocumentType { get; set; } = string.Empty;

        // Для получателя
        public string? RecipientName { get; set; }

        [StringLength(12)]
        public string? RecipientBinInn { get; set; }

        [StringLength(50)]
        public string? RecipientIik { get; set; }

        [StringLength(20)]
        public string? RecipientBankBik { get; set; }

        [StringLength(10)]
        public string? RecipientKbe { get; set; }

        // Для плательщика
        public string? PayerName { get; set; }

        [StringLength(12)]
        public string? PayerBinInn { get; set; }

        [StringLength(50)]
        public string? PayerIik { get; set; }

        [StringLength(20)]
        public string? PayerBankBik { get; set; }

        [StringLength(10)]
        public string? PayerKbe { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Debit { get; set; } // Списание

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Credit { get; set; } // Поступление

        public string PaymentPurpose { get; set; } = string.Empty;

        [StringLength(10)]
        public string PaymentCode { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
