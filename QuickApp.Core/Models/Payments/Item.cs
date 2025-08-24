using Microsoft.EntityFrameworkCore;
using Torgay.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Payments {
    [Table("Payment_C_Items")]
    [Comment("Статья")]
    public class Item : ClientEntry {
        [Required]
        [Comment("Наименование")]
        [MaxLength(150)]
        public required string Title { get; set; }

        [Required]
        [Comment("Вид движения")]
        public required Guid MovetmentType_id { get; set; }
        [NotMapped]
        public virtual MovementType MovementType { get; set; }

        [Required]
        [Comment("Категория ДДС")]
        public required Guid CashFlowCategory_id { get; set; }
        [NotMapped]
        public virtual CashFlowCategory? CashFlowCategory { get; set; }

        [Required]
        [Comment("Категория ОПиУ")]
        public required Guid PnLCategory_id { get; set; }
        [NotMapped]
        public virtual PnLCategory? PnLCategory { get; set; }
    }
}
