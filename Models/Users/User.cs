using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("users")]
    public sealed class User
    {
        [Key]
        [Required]
        [Column("user_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_public_id", TypeName = "varchar(100)")]
        public Guid PublicId { get; set; }

        [Required]
        [Column("user_name", TypeName = "varchar(25)")]
        public string? Name { get; set; }

        [Required]
        [Column("user_surname", TypeName = "varchar(25)")]
        public string? Surname { get; set; }

        [Required]
        [Column("user_fathername", TypeName = "varchar(25)")]
        public string? Fathername { get; set; }

        [Required]
        [Column("user_email", TypeName = "varchar(100)")]
        public string? Email { get; set; }
        
        [Required]
        [Column("user_login", TypeName = "varchar(100)")]
        public string? Login { get; set; }

        [Required]
        [Column("user_password", TypeName = "varchar(100)")]
        public string? Password { get; set; }

        [Required]
        [Column("user_age", TypeName = "int")]
        public uint Age { get; set; }

        [Required]
        [Column("user_gender", TypeName = "varchar(10)")]
        public Genders Gender { get; set; } = Genders.None;

        [Required]
        [Column("user_last_session", TypeName = "datetime2(7)")]
        public DateTime LastSession { get; set; }

        [Required]
        [Column("user_state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("user_role_id", TypeName = "varchar(100)")]
        public Guid RoleId { get; set; }

        public UserRole? Role { get; set; }
        public UserState? State { get; set; }
        public List<GroupAndUser>? GroupAndUser { get; set; }
    }

    public enum Genders 
    {
        Male,
        Female,
        None
    }
}