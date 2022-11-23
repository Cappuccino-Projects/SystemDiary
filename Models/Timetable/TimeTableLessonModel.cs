using Models.Abstract;
using Models.Disciplines;
using Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Timetable
{
    [Table("timetable_lessons")]
    public sealed class TimeTableLessonModel : ModelAbstract
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
        public string? StartLesson { get; set; }

        [Required]
        [Column("end_lesson")]
        public string? EndLesson { get; set; }

        [Required]
        [Column("cabinet_number")]
        public int CabinetNumber { get; set; }

        public TimeTableModel? Timetable { get; set; }
        public UserModel? Educator { get; set; }
        public DisciplineModel? Discipline { get; set; }
    }
}
