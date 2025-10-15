using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorksTickets.Models.Entities;

[Table("Tickets")]
public class Ticket
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int VersionOsId { get; set; }
    public VersionOs VersionOs { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    public DateTime? ResolvedDate { get; set; }
    [Required]
    public int StatusId { get; set; }
    public Status Status { get; set; }
    [Required]
    public string Problem { get; set; }
    public string? Resolution { get; set; }
}
