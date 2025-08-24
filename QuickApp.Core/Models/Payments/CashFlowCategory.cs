using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_CashFlowCategories")]
    [Comment("Категория ДДС")]
    public class CashFlowCategory: BaseEntity {
        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Required]
        [Comment("Вид движения")]
        [MaxLength(150)]
        public required Guid MovementType_id { get; set; }
        [NotMapped]
        public virtual MovementType? MovementType { get; set; }
    }
}
