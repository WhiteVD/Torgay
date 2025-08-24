// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickApp.Core.Models
{
    public class BaseEntity : IAuditableEntity
    {
        [Key]
        [Comment("Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Comment("Кем создано")]
        [MaxLength(40)]
        public string? CreatedBy { get; set; }

        [Comment("Кем изменено")]
        [MaxLength(40)]
        public string? UpdatedBy { get; set; }

        [Comment("Когда изменено")]
        public DateTime UpdatedDate { get; set; }

        [Comment("Когда создано")]
        public DateTime CreatedDate { get; set; }
    }
}
