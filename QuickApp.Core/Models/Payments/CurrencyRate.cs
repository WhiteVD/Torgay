using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_CurrencyRates")]
    public class CurrencyRate {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Comment("Дата")]
        public required DateTime Date { get; set; }

        [Required]
        [Comment("Валюта")]
        public required Guid Currency_id { get; set; }
        [NotMapped]
        public virtual Currency currency { get; set; }

        [Required]
        [Comment("Курс")]
        public required decimal Rate { get; set; }
    }
}
