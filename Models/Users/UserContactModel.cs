using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Abstract;

namespace Models.Users {
    
    [Table("contacts")]
    public sealed class UserContactModel : ModelAbstract {
        
        [Key]
        [Required]
        [Column("id", TypeName="varchar(100)")]
        public Guid Id { get; set;}
        
        [Required]
        [Column("user_id", TypeName="varchar(100)")]
        public Guid UserId { get; set; }
        
        [Required]
        [Column("phone", TypeName="varchar(16)")]
        public string Phone { get; set; } = String.Empty;

        public UserModel User { get; set; }
    }
}