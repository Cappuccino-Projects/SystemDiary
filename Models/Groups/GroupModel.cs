using Models.Abstract;
using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Journal;

namespace Models.Groups
{
    [Table("groups")]
    public sealed class GroupModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("group_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("group_state_id", TypeName = "varchar(100)")]
        public Guid GroupStateId { get; set; }
        
        [Required]
        [Column("group_name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required]
        [Column("group_number_course", TypeName = "int")]
        public uint NumberCourse { get; set; }

        [Column("group_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public GroupStateModel? State { get; set; }
        public List<GroupAndUserAssociateModel>? GroupAndUser { get; set; }
        public JournalModel? JurnalModel { get; set; }
    }
}
