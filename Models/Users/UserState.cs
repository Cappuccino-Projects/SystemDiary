using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("user_states")]
    public sealed class UserState
    {
        [Key]
        [Required]
        [Column("user_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("user_state_name", TypeName = "varchar(25)")]
        public string? Name { get; set; }

        [Column("user_state_description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<User>? Users { get; set; }
    }
}
