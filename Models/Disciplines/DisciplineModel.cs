using Models.Abstract;
using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Disciplines
{
    [Table("disciplines")]
    public sealed class DisciplineModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("discipline_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("discipline_state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("discipline_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }
        
        [Required]
        [Column("discipline_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public DisciplineStateModel? State { get; set; }
        public List<JurnalAndDisciplineAssociateModel>? JurnalAndDisciplineAssociates { get; set; }
        public List<DisciplineAndEducatorAssociateModel>? DisciplineAndEducatorAssociates { get; set; }
    }
}
