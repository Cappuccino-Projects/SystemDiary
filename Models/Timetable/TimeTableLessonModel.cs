using Models.Abstract;
using Models.Disciplines;
using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Timetable
{
    [Table("timetable_lessons")]
    public class TimeTableLessonModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("timetable_id")]
        public Guid TimetableId { get; set; }

        [Required]
        [Column("discipline_id")]
        public Guid DisciplineId { get; set; }

        [Required]
        [Column("educator_id")]
        public Guid EducatorId { get; set; }

        [Required]
        [Column("start_lesson")]
        public string StartLesson { get; set; }

        [Required]
        [Column("end_lesson")]
        public string EndLesson { get; set; }

        [Required]
        [Column("room_number")]
        public int RoomNumber { get; set; }

        public TimetableModel? TimetableModel { get; set; }
    }
}
