namespace HotelManagement.Application.DTOs;

public class GuestDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DOB { get; set; }
    public string Address { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int RoomId { get; set; }
}
