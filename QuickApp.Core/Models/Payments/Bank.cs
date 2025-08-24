using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_Banks")]
    public class Bank {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Comment("Наименование")]
        [MaxLength(250)]
        public required string Title { get; set; }

        [Required]
        [Comment("Банковский идентификационный код")]
        [MaxLength(9)]
        public required string BIC { get; set; }

        [Comment("Страна")]
        public Guid? Country_id { get; set; }
        [NotMapped]
        public virtual Country? Country { get; set; }

        [Comment("Идентификатор источника")]
        public Guid? SourceId { get; set; }

        [Comment("Удалён?")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
