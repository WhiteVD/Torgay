using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_PPC")]
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
