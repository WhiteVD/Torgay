using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Account {
    /// <summary>
    /// Связь пользователя с лицензией
    /// </summary>
    public class UserLicense {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid LicenseId { get; set; }

        [ForeignKey(nameof(LicenseId))]
        public virtual License License { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime? PurchasedAt { get; set; }

        public decimal? PurchasePrice { get; set; }

        [MaxLength(50)]
        public string? TransactionId { get; set; }
    }
}
