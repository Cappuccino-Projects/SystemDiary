using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Marks
{
    [Table("mark_states")]
    public sealed class MarkStateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("mark_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("mark_state_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required]
        [Column("mark_state_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<MarkModel>? Marks { get; set; }
    }
}
