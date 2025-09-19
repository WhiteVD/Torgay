using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Torgay.Core.Models.Enums;

namespace Torgay.Core.Models.Account {
    /// <summary>
    /// Представляет лицензию в системе
    /// </summary>
    public class License {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public LicenseType Type { get; set; }

        [Required]
        public int MaxUsers { get; set; } = 1;

        [Required]
        public int MaxOrganizations { get; set; } = 1;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public decimal Price { get; set; } = 0;

        [Required]
        public int DurationDays { get; set; } = 30;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Навигационные свойства
        public virtual ICollection<UserLicense> UserLicenses { get; set; } = new List<UserLicense>();
        public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
