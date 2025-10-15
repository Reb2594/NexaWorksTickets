using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NexaWorksTickets.Code.Models.Entities;
[Table("Status")]
public class Status
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public string Name { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
