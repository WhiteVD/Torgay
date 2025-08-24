using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_PPC")]
    [Comment("Код назначения платежа")]
    public class PPC {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Comment("Код")]
        [MaxLength(3)]
        public required string Code { get; set; }

        [Required]
        [Comment("Наименование")]
        [MaxLength(500)]
        public required string Title { get; set; }
    }
}
