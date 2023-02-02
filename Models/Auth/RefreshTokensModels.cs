using Models.Abstract;
using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Auth
{
    [Table("refresh_tokens")]
    public sealed class RefreshTokensModels : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [Column("token")]
        public string Token { get; set; } = string.Empty;

        [Required]
        [Column("created")]
        public DateTime Created { get; set; }

        [Required]
        [Column("expires")]
        public DateTime Expires { get; set; }

        [Column("revoked")]
        public DateTime Revoked { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        public UserModel User { get; set; }
    }
}
