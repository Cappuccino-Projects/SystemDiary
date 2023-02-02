using Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Users
{
    [Table("user_states")]
    public sealed class UserStateModel : ModelAbstract
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column("description", TypeName = "varchar(550)")]
        public string? Description { get; set; }

        public List<UserModel>? Users { get; set; }
    }
}
