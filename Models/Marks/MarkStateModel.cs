using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Marks
{
    [Table("mark_states")]
    public sealed class MarkStateModel
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(25)")]
        public string? Name { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public List<MarkModel>? Marks { get; set; }
    }
}
