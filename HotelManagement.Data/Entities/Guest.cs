using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Data.Entities;

public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(400)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime DOB { get; set; }

    [Required]
    [MaxLength(600)]
    public string Address { get; set; } = null!;

    [Required]
    public string Nationality { get; set; } = null!;

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    [ForeignKey(nameof(Room))]
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
}
