using Models.Abstract;
using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("user_roles")]
    public sealed class UserRoleModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = "role_name";
        
        [Required]
        [Column("backend_name", TypeName = "varchar(50)")]
        public string? BackendName { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<UserModel>? Users { get; set; }
    }
}
