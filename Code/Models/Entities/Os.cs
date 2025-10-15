using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace NexaWorksTickets.Code.Models.Entities;
[Table("Os")]
public class Os
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    public ICollection<VersionOs> VersionOs { get; set; } = new List<VersionOs>();
}
