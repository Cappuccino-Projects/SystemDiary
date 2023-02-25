using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Abstract;
using Models.Groups;

namespace Models.Journal
{
    [Table("journal")]
    public sealed class JournalModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("state_id", TypeName = "varchar(100)")]
        public Guid StateId { get; set; }

        [Required]
        [Column("group_id", TypeName = "varchar(100)")]
        public Guid GroupId { get; set; }

        [Required]
        [Column("period_start", TypeName = "datetime")]
        public DateTime Start { get; set; }

        [Required]
        [Column("period_end", TypeName = "datetime")]
        public DateTime End { get; set; }

        // public JurnalAndDisciplineAssociateModel? JurnalAndDisciplineAssociation { get; set; }
        public GroupModel? Group { get; set; }
        public JournalStateModel? JurnalState { get; set; }
    }
}
