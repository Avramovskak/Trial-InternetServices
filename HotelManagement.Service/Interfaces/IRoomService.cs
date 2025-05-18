using HotelManagement.Service.DTOs;
using HotelManagement.Service.DTOs;

namespace HotelManagement.Service.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto?> GetByIdAsync(int id);
        Task<RoomDto> CreateAsync(CreateRoomDto roomDto);
        Task<bool> UpdateAsync(int id, CreateRoomDto roomDto);
        Task<bool> DeleteAsync(int id);
    }
}
