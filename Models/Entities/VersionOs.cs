using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace NexaWorksTickets.Models.Entities;

[Table("Version_Os")]
public class VersionOs
{
    public int Id { get; set; }

    [Required]
    public int VersionId { get; set; }
    public ProductVersion Version { get; set; }

    [Required]
    public int OsId { get; set; }
    public Os Os { get; set; }

    public bool Available { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
