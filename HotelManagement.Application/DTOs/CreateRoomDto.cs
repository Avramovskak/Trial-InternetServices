namespace HotelManagement.Application.DTOs;

public class CreateRoomDto
{
    public int Number { get; set; }
    public int Floor { get; set; }
    public string Type { get; set; } = null!;
}
