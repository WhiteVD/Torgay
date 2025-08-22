using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_Payments")]
    public class Payment : ClientEntry {
        [Required]
        [Comment("Номер")]
        public required string PaymentId { get; set; }

        [Precision(19, 2)]
        [Comment("Общая сумма")]
        public decimal TotalAmount { get; set; }

        [Precision(19, 2)]
        [Comment("Сумма платежа")]
        public decimal Amount { get; set; }

        [Precision(19, 2)]
        [Comment("Общая сумма в валюте")]
        public decimal TotalAmountInCurrency { get; set; }

        [Precision(19, 2)]
        [Comment("Сумма платежа в валюте")]
        public decimal AmountInCurrency { get; set; }

        [ForeignKey("Payment")]
        [Comment("Идентификатор родительского платежа")]
        public Guid? ParentPayment_id { get; set; }

        [JsonIgnore]
        public virtual Payment? ParentPayment { get; set; }

        [Comment("Прогнозная дата оплаты")]
        public DateTime? PlannedDate { get; set; }

        [Comment("Фактическая дата")]
        public DateTime ActualDate { get; set; }

        [Comment("Статус платежа")]
        public PaymentStatus Status { get; set; }

        [Comment("Идентификатор счёта получателя")]
        public Guid? RecipientAccount_id { get; set; }

        [Comment("Идентификатор счёта отправителя")]
        public Guid? SenderAccountId { get; set; }

        [Comment("Вид платежа")]
        public Guid? PaymentCategory_id { get; set; }

        [Comment("Ставка НДС")]
        public double? VatRate { get; set; }

        [Comment("Тип платежа")]
        public PaymentType Type { get; set; }

        [Comment("Идентификатор валюты")]
        public Guid CurrencyId { get; set; }
        public virtual Currency? Currency { get; set; }

        [Comment("Примечание")]
        public string? Note { get; set; }

        [Comment("КНП")]
        public string? KnpCode { get; set; }

        [Comment("КБК")]
        public string? KbkCode { get; set; }

        [Comment("Идентификатор договора")]
        public Guid? Contract_id { get; set; }

        [Comment("Идентификатор контрагента получателя/отправителя")]
        public Guid? Customer_id { get; set; }

        [Comment("Назначение платежа")]
        public string? PurposeOfPayment { get; set; }

        [Comment("Идентификатор пары")]
        public Guid? TransferPair_id { get; set; }

        [Comment("Дата поступления")]
        public DateTime? IncomeDate { get; set; }
    }
}
