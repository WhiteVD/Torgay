using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_Customers")]
    [Comment("Контрагенты")]
    public class Customer : ClientEntry {
        [Required]
        [Comment("Наименование")]
        [MaxLength(250)]
        public required string Title { get; set; }

        [Comment("БИН")]
        [MaxLength(12)]
        public required string BIN { get; set; }

        [Comment("Страна")]
        public Guid? Country_id { get; set; }
        [NotMapped]
        public virtual Country? Country { get; set; }
    }
}
