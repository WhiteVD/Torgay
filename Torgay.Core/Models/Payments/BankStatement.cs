using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Account;

namespace Torgay.Core.Models.Payments {
    /// <summary>
    /// Банковская выписка
    /// </summary>
    [Table("Payment_D_BankStatement")]
    [Comment("Банковская выписка")]
    public class BankStatement : ClientEntry {
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Currency { get; set; } = "KZT";

        [Required]
        public DateTime PeriodFrom { get; set; }

        [Required]
        public DateTime PeriodTo { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InitialBalance { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalBalance { get; set; }

        public DateTime LastMovementDate { get; set; }

        // Эти поля дублируются для сохранения данных на момент выписки
        [Required]
        [StringLength(12)]
        public string StatementOrganizationBin { get; set; } = string.Empty;

        [Required]
        public string StatementOrganizationName { get; set; } = string.Empty;

        // Навигационное свойство для транзакций
        [NotMapped]
        public virtual ICollection<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();

        // Ссылка на пользователя
        [NotMapped]
        public virtual ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Конструктор для установки базовых свойств ClientEntry
        /// </summary>
        public BankStatement() {
        }
    }
}
