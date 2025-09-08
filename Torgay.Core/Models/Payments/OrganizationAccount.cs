using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_OrganizationAccounts")]
    [Comment("Счета организации")]
    public class OrganizationAccount : ClientEntry {
        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Required]
        [Comment("Тип счёта")]
        public required Guid AccountType_id { get; set; }
        [NotMapped]
        public virtual AccountType accountType { get; set; }

        [Required]
        [Comment("Валюта")]
        public required Guid Currency_id { get; set; }
        [NotMapped]
        public virtual Currency currency { get; set; }

        [Comment("Банк")]
        public Guid Bank_id { get; set; }
        [NotMapped]
        public virtual Bank bank { get; set; }
    }
}
