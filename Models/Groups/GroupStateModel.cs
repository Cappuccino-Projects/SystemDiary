using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Groups
{
    [Table("group_states")]
    public sealed class GroupStateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("group_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_state_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column("group_state_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<GroupModel>? Groups { get; set; }
    }
}
