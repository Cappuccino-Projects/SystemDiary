using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Journal;

namespace Models.Marks
{
    [Table("marks")]
    public sealed class MarkModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("marks_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("marks_state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("marks_markup", TypeName = "varchar(50)")]
        public string? Markup { get; set; }

        [Required]
        [Column("mark_value", TypeName = "int")]
        public int Value { get; set; }

        [Required]
        [Column("mark_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public MarkStateModel? StateModel { get; set; }
        public JournalMarkModel? Jurnal { get; set; }
    }
}
