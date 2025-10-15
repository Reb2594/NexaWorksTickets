using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace NexaWorksTickets.Code.Models.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation Property
        public ICollection<ProductVersion> Versions { get; set; } = new List<ProductVersion>();

    }
}
