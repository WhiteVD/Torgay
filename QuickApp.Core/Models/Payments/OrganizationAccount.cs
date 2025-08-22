using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models.Access;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_OrganizationAccounts")]
    public class OrganizationAccount : ClientEntry {
        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Required]
        [Comment("Тип счёта")]
        public required Guid AccountType_id { get; set; }
        public required AccountType accountType { get; set; }

        [Required]
        [Comment("Валюта")]
        public required Guid Currency_id { get; set; }
        public required Currency currency { get; set; }

        [Comment("Банк")]
        public Guid Bank_id { get; set; }
        public Bank bank { get; set; }
    }
}
