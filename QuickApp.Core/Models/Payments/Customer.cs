using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_Customers")]

    public class Customer : ClientEntry {
        [Required]
        [Comment("Наименование")]
        [MaxLength(250)]
        public required string Title { get; set; }

        [Comment("ИНН")]
        [MaxLength(12)]
        public string INN { get; set; }
    }
}
