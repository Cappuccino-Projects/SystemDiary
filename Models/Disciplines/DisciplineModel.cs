using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Disciplines
{
    [Table("disciplines")]
    public sealed class DisciplineModel
    {
        [Key]
        [Required]
        [Column("discipline_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("discipline_state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("discipline_name", TypeName = "varchar(25)")]
        public string? Name { get; set; }
        
        [Required]
        [Column("discipline_description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public DisciplineState State { get; set; }
    }
}
