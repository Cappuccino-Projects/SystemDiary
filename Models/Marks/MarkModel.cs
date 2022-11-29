using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Marks
{
    [Table("marks")]
    public sealed class MarkModel
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("markup", TypeName = "varchar(25)")]
        public string? Markup { get; set; }

        [Required]
        [Column("value", TypeName = "int")]
        public int Value { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public MarkStateModel? StateModel { get; set; }
    }
}
