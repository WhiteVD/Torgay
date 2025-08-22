using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Access {
    [Table("Global_C_Clients")]
    public class Client : BaseEntity {
        [Required]
        [MaxLength(250)]
        [Comment("Наименование")]
        public required string Title { get; set; }

        [Comment("Удалён?")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
