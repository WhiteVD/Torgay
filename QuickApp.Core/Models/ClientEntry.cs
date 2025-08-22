using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace QuickApp.Core.Models {
    public class ClientEntry : BaseEntity {
        [Comment("Идентификатор клиента")]
        public Guid? Client_id { get; set; }

        [Comment("Идентификатор организации")]
        public Guid? Organization_id { get; set; }

        [Comment("Идентификатор источника")]
        public Guid? Source_id { get; set; }

        [Comment("Удалён?")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
