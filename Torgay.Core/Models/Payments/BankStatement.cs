using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    /// <summary>
    /// Банковская выписка
    /// </summary>
    [Table("Payment_D_BankStatement")]
    [Comment("Банковская выписка")]
    public class BankStatement : ClientEntry {
        [Required]
        [Comment("Номер документа")]
        public required string DocumentNumber { get; set; }

        [Required]
        [Comment("Дата операции")]
        public DateTime Date { get; set; }

        [Comment("Дебет")]
        public decimal DR { get; set; }

        [Comment("Кредит")]
        public decimal CR { get; set; }

        [Comment("Наименование бенефициара / отправителя денег")]
        public string Recipient { get; set; }

        [Comment("ИИК бенефициара / отправителя денег")]
        public string IIC { get; set; }

        [Comment("БИК банка бенефициара (отправителя денег)")]
        public string BIC { get; set; }

        [Comment("КНП")]
        public string PPC { get; set; }

        [Comment("Назначение платежа")]
        public string PaymentPurpose { get; set; }
    }
}
