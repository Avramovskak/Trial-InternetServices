using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Domain.Entities;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    public ICollection<Guest> Guests { get; set; } = new List<Guest>();
}
