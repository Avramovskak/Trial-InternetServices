﻿namespace HotelManagement.Service.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
