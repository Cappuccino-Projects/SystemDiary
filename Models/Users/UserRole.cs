using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("user_roles")]
    public sealed class UserRole
    {
        [Key]
        [Required]
        [Column("user_roles_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_role_name", TypeName = "varchar(25)")]
        public string Name { get; set; } = "role_name";
        
        [Required]
        [Column("user_role_backend_name", TypeName = "varchar(25)")]
        public string? BackendName { get; set; }

        [Required]
        [Column("user_role_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<UserModel>? Users { get; set; }
        public List<PermissionAndRoleAssociate>? PermissionAndRoles { get; set; }
    }
}
