using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Associations
{
    [Table("group_and_users_associate_states")]
    public sealed class AssociateStateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("group_and_users_associate_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_and_users_associate_state_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column("group_and_users_associate_state_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<GroupAndUserAssociateModel>? GroupAndUserAssociates { get; set; }
    }
}
