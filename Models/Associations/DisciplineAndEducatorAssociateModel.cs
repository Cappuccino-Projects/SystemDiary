using Models.Abstract;
using Models.Disciplines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Associations
{
    [Table("discipline_and_educator_associations")]
    public sealed class DisciplineAndEducatorAssociateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("discipline_and_educator_associations_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("discipline_and_educator_associations_user_id", TypeName = "varchar(100)")]
        public Guid UserId { get; set; }
        
        [Required]
        [Column("discipline_and_educator_associations_discipline_id", TypeName = "varchar(100)")]
        public Guid DisciplineId { get; set; }
        
        [Required]
        [Column("discipline_and_educator_associations_state_id", TypeName = "varchar(100)")]
        public Guid AssociateStateId { get; set; }

        public AssociateStateModel? State { get; set; }
        public DisciplineModel? Discipline { get; set; }
    }
}
