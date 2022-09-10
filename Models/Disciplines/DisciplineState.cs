﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Disciplines
{
    [Table("discipline_states")]
    public sealed class DisciplineState
    {
        [Key]
        [Required]
        [Column("discipline_state_id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("discipline_state_name", TypeName = "varchar(25)")]
        public string? Name { get; set; }
        
        [Required]
        [Column("discipline_state_description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public List<DisciplineModel> Disciplines { get; set; }
    }
}
