using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Timetable
{
    [Table("cabinets")]
    public sealed class CabinetModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("label")]
        public string Label { get; set; } = "";

        [Required]
        [Column("description")]
        public string Description { get; set; } = "";
    }
}
