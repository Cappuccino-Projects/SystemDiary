using Models.Groups;
using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Associations
{
    [Table("group_and_user_associations")]
    public sealed class GroupAndUserAssociate
    {
        [Key]
        [Required]
        [Column("group_and_user_association_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_and_user_association_user_id", TypeName = "varchar(100)")]
        public Guid UserId { get; set; }

        [Required]
        [Column("group_and_user_association_group_id", TypeName = "varchar(100)")]
        public Guid GroupId { get; set; }

        [Required]
        [Column("group_and_user_association_state_id", TypeName = "varchar(100)")]
        public Guid AssociateStateId { get; set; }

        public User? User { get; set; }

        public Group? Group { get; set; }

        public GlobalAssociateState? State { get; set; }
    }
}
