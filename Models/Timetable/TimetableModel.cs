using Models.Abstract;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Timetable
{
    [Table("timetable")]
    public sealed class TimetableModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("group_id")]
        public Guid GroupId { get; set; }

        [Required]
        [Column("week")]
        public Weeks Week { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("records")]
        public List<TimeTableLessonModel>? Records { get; set; }
    }
}