using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Groups
{
    [Table("groups")]
    public sealed class Group
    {
        [Key]
        [Required]
        [Column("group_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_name", TypeName = "varchar(25)")]
        public string Name { get; set; } = "default_group_name";

        [Column("group_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        [Required]
        [Column("group_state_id", TypeName = "varchar(100)")]
        public Guid GroupStateId { get; set; }

        public GroupState? State { get; set; }

        public List<GroupAndUser>? GroupAndUser { get; set; }
    }
}
