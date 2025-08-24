using Microsoft.EntityFrameworkCore;
using Torgay.Core.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torgay.Core.Models.Access {
    [Table("Global_C_UserToClient")]
    public class UserToClient : BaseEntity {
        [Required]
        [Comment("Пользователь")]
        public required Guid user_id;
        public ApplicationUser user;

        [Required]
        [Comment("Клиент")]
        public required Guid client_id;
        public Client client;
    }
}
