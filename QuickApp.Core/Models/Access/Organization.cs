using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Access {
    [Table("Global_C_Organizations")]
    public class Organization : BaseEntity {
        [Column("Source_Id")]
        [Comment("Идентификатор источника")]
        public Guid? SourceId { get; set; }

        [Required]
        [Column("Title")]
        [MaxLength(250)]
        [Comment("Наименование")]
        public required string Title { get; set; }

        [Column("BIN")]
        [MaxLength(12)]
        [Comment("БИН")]
        public string? BIN { get; set; }

        [Column(name: "Is_Deleted")]
        [Comment("Удалён?")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
