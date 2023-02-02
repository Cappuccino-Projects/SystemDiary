using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jurnal
{
    [Table("jurnal_states")]
    public sealed class JournalStateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("jurnal_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("jurnal_state_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required]
        [Column("jurnal_state_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<JournalModel>? JurnalModel { get; set; }
    }
}
