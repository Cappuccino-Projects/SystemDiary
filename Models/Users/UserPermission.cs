using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("user_permissions")]
    public sealed class UserPermission
    {
        [Key]
        [Required]
        [Column("user_permission_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_permission_role_id", TypeName = "varchar(100)")]
        public Guid RoleId { get; set; }

        [Required]
        [Column("user_permission_name", TypeName = "varchar(25)")]
        public string Name { get; set; } = "permission_name";

        [Column("user_permission_is_enabled")]
        public bool IsEnabled { get; set; } = false;

        [Column("user_permission_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<PermissionAndRole>? PermissionAndRoles { get; set; }
    }
}
