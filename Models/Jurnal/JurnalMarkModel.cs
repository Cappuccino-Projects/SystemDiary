using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jurnal
{
    [Table("jurnal_mark")]
    public sealed class JurnalMarkModel
    {
        [Key]
        [Required]
        [Column("jurnal_mark_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("jurnal_mark_mark_id", TypeName = "varchar(100)")]
        public Guid MarkId { get; set; }

        [Required]
        [Column("jurnal_mark_decipline_id", TypeName = "varchar(100)")]
        public Guid DeciplineId { get; set; }

        [Required]
        [Column("jurnal_mark_user_id", TypeName = "varchar(100)")]
        public Guid UserId { get; set; }

        [Required]
        [Column("jurnal_mark_date_id", TypeName = "datetime2(7)")]
        public DateTime Date { get; set; }
    }
}
