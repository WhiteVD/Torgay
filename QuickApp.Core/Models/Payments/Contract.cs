using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models.Access;
using QuickApp.Core.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models.Payments {
    [Table("Payment_C_Contracts")]
    [Comment("Договора")]
    public class Contract : BaseEntity {
        [Comment("Идентификатор с 1С")]
        public Guid? SourceId { get; set; }

        [Comment("Наименование")]
        [MaxLength(250)]
        public required string Title { get; set; }

        [MaxLength(250)]
        [Comment("Номер договора")]
        public required string Number { get; set; }

        [Comment("Дата договора")]
        public DateTime? Date { get; set; }

        [Comment("Дата начала")]
        public DateTime? StartDate { get; set; }

        [Comment("Дата окончания")]
        public DateTime? EndDate { get; set; }

        [Comment("Тип договора")]
        public Guid ContractType_id { get; set; }
        [NotMapped]
        public virtual ContractType? ContractType { get; set; }

        [Comment("Статус")]
        public ContractStatus Status { get; set; }

        [Comment("Идентификатор клиента")]
        public Guid? Client_id { get; set; }
        [NotMapped]
        public virtual Client Client { get; set; }

        [Comment("Идентификатор организации")]
        public Guid? OrganizationId { get; set; }
        [NotMapped]
        public virtual Organization Organization { get; set; }

        [Comment("Идентификатор контрагента")]
        public Guid Customer_id { get; set; }
        [NotMapped]
        public virtual Customer? customer { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }

        [Comment("Удалён?")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
