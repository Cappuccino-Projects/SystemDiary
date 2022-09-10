using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.News
{
    [Table("news")]
    public sealed class NewsModel
    {
        [Key]
        [Required]
        [Column("news_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("news_public_id", TypeName = "varchar(100)")]
        public Guid PublicId { get; set; }

        [Required]
        [Column("news_autor_id", TypeName = "varchar(100)")]
        public Guid AuthorId { get; set; }

        [Required]
        [Column("news_title", TypeName = "varchar(100)")]
        public string? Title { get; set; }

        [Required]
        [Column("news_content", TypeName = "varchar(5000)")]
        public string? Content { get; set; }

        [Required]
        [Column("news_created", TypeName = "datetime2(7)")]
        public DateTime DateOfCreation { get; set; }
    }
}
