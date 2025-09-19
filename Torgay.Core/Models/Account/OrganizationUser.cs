using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Torgay.Core.Models.Enums;

namespace Torgay.Core.Models.Account {
    /// <summary>
    /// Связь пользователя с организацией и его ролью
    /// </summary>
    public class OrganizationUser {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public OrganizationRole Role { get; set; } = OrganizationRole.Member;

        [Required]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedAt { get; set; }
    }
}
