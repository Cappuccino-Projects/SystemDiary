using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.News
{
    [Table("news_states")]
    public sealed class NewsState
    {
        [Key]
        [Required]
        [Column("news_states_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("news_states_name", TypeName = "varchar(25)")]
        public string? Name { get; set; }

        [Required]
        [Column("news_states_description", TypeName = "varchar(500)")]
        public string? Description { get; set; }
    }
}
