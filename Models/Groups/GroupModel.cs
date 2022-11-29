﻿using Models.Associations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Groups
{
    [Table("groups")]
    public sealed class GroupModel
    {
        [Key]
        [Required]
        [Column("id", TypeName = "varchar(100)")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("state_id", TypeName = "varchar(100)")]
        public Guid GroupStateId { get; set; }
        
        [Required]
        [Column("name", TypeName = "varchar(25)")]
        public string? Name { get; set; }

        [Column("description", TypeName = "varchar(500)")]
        public string? Description { get; set; }

        public GroupState? State { get; set; }

        public List<GroupAndUserAssociate>? GroupAndUser { get; set; }
    }
}
