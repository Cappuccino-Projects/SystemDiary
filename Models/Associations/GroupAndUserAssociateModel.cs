using Models.Abstract;
using Models.Groups;
using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Associations
{
    [Table("group_and_student_associations")]
    public sealed class GroupAndUserAssociateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("group_and_student_association_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_and_student_association_user_id", TypeName = "varchar(100)")]
        public Guid UserId { get; set; }

        [Required]
        [Column("group_and_student_association_group_id", TypeName = "varchar(100)")]
        public Guid GroupId { get; set; }

        [Required]
        [Column("group_and_student_association_state_id", TypeName = "varchar(100)")]
        public Guid AssociateStateId { get; set; }

        public UserModel? User { get; set; }
        public GroupModel? Groups { get; set; }
        public AssociateStateModel? State { get; set; }
    }
}
