using Models.Abstract;
using Models.Associations;
using Models.Auth;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("users")]
    public sealed class UserModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("public_id", TypeName = "varchar(100)")]
        public Guid PublicId { get; set; }

        [Required]
        [Column("state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("role_id", TypeName = "varchar(100)")]
        public Guid RoleId { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Column("surname", TypeName = "varchar(50)")]
        public string Surname { get; set; } = String.Empty;

        [Required]
        [Column("fathername", TypeName = "varchar(50)")]
        public string? Fathername { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; set; } = String.Empty;
        
        [Required]
        [Column("login", TypeName = "varchar(100)")]
        public string? Login { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(100)")]
        public string Password { get; set; } = String.Empty;

        [Required]
        [Column("date_of_birth", TypeName = "date")]
        public DateTime Birth { get; set; }

        [Required]
        [Column("gender", TypeName = "varchar(10)")]
        public Genders Gender { get; set; } = Genders.None;

        [Required]
        [Column("refresh_token")]
        public string? RefreshToken { get; set; } = string.Empty;

        public UserRoleModel Role { get; set; }
        public UserStateModel State { get; set; }
        public GroupAndUserAssociateModel GroupAndUser { get; set; }
        public UserContactModel Contact { get; set; }
    }
}