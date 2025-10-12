using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Torgay.Core.DTO {
    /// <summary>
    /// DTO для загрузки банковской выписки
    /// </summary>
    public class UploadBankStatementDto {
        [Required]
        public Guid OrganizationId { get; set; }

        [Required]
        public IFormFile File { get; set; } = null!;
    }
}
