using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models.Access;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_CustomerAccounts")]
    public class CustomerAccount : ClientEntry {

        [Required]
        [Comment("Контрагент")]
        public required Guid Customer_id { get; set; }
        public Customer customer { get; set; }

        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Required]
        [Comment("Тип счёта")]
        public required Guid AccountType_id { get; set; }
        public AccountType accountType { get; set; }

        [Required]
        [Comment("Валюта")]
        public required Guid Currency_id { get; set; }
        public Currency currency { get; set; }

        [Required]
        [Comment("Банк")]
        public required Guid Bank_id { get; set; }
        public Bank bank { get; set; }
    }
}
