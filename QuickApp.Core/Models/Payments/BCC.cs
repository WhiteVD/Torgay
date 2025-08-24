using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_BCC")]
    [Comment("Код бюджетной класификации")]
    public class BCC {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Comment("Код")]
        [MaxLength(6)]
        public required string Code { get; set; }

        [Required]
        [Comment("Наименование")]
        [MaxLength(500)]
        public required string Title { get; set; }
    }
}
