using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Associations
{
    [Table("permissions_and_roles_associates")]
    public sealed class PermissionAndRoleAssociate
    {
        [Key]
        [Required]
        [Column("permissions_and_roles_associate_id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("permissions_and_roles_associate_role_id")]
        public Guid RoleId { get; set; }
        
        [Required]
        [Column("permissions_and_roles_associate_permission_id")]
        public Guid PermissionId { get; set; }

        public UserRole? Role { get; set; }
        public UserPermission? Permission { get; set; }
    }
}
