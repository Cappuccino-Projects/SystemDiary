using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Marks
{
    [Table("marks")]
    public sealed class MarkModel
    {
        [Key]
        [Required]
        [Column("marks_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("marks_state_id", TypeName = "varchar(25)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("marks_markup", TypeName = "varchar(25)")]
        public string? Markup { get; set; }

        [Required]
        [Column("mark_value", TypeName = "int")]
        public int Value { get; set; }

        [Required]
        [Column("mark_description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public MarkStateModel? StateModel { get; set; }
    }
}
