using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NexaWorksTickets.Code.Models.Entities;

[Table("Versions")]
public class ProductVersion
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Number { get; set; }

    [Required]
    public int ProductId { get; set; }

    // Navigation Properties
    public Product Product { get; set; }
    public ICollection<VersionOs> VersionOs { get; set; } = new List<VersionOs>();
}
