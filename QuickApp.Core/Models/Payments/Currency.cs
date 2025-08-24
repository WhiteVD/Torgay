using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_Currency")]
    [Comment("Валюты")]
    public class Currency {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Comment("ISO код")]
        [MaxLength(3)]
        public string? ISO { get; set; }

        [Comment("Символ")]
        [MaxLength(4)]
        public string? Symbol { get; set; }

        [NotMapped]
        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }
    }
}
