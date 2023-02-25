using Models.Disciplines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Journal;

namespace Models.Associations
{
    [Table("jurnal_and_discipline_associations")]
    public sealed class JurnalAndDisciplineAssociateModel
    {
        [Key]
        [Required]
        [Column("jurnal_and_discipline_associations_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("jurnal_and_discipline_associations_jurnal_id", TypeName = "varchar(100)")]
        public Guid JurnalId { get; set; }

        [Required]
        [Column("jurnal_and_discipline_associations_discipline_id", TypeName = "varchar(100)")]
        public Guid DisciplineId { get; set; }

        public JournalModel? Jurnal { get; set; }
        public List<JournalMarkModel>? JurnalMarks { get; set; }
        public DisciplineModel? Discipline { get; set; } 
    }
}
