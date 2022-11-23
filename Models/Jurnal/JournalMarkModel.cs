using Models.Abstract;
using Models.Associations;
using Models.Marks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jurnal
{
    [Table("jurnal_marks")]
    public sealed class JournalMarkModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("mark_id", TypeName = "varchar(100)")]
        public Guid MarkId { get; set; }

        [Required]
        [Column("jurnal_and_descipline_id", TypeName = "varchar(100)")]
        public Guid JurnalAndDesciplineId { get; set; }

        [Required]
        [Column("educator_id")]
        public Guid EducatorId { get; set; }

        [Required]
        [Column("student_id", TypeName = "varchar(100)")]
        public Guid UserId { get; set; }

        [Required]
        [Column("date", TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public List<GroupAndStudentAssociateModel>? GroupAndStudentAssociates { get; set; }
        public List<DisciplineAndEducatorAssociateModel>? DisciplineAndEducatorAssociates { get; set; }
        public List<JurnalAndDisciplineAssociateModel>? JurnalAndDisciplineAssociates { get; set; }
        public List<MarkModel>? Marks { get; set; }

    }
}
