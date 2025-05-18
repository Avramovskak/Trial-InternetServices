using HotelManagement.Application.DTOs;

namespace HotelManagement.Application.Interfaces;

public interface IGuestService
{
    Task<List<GuestDto>> GetAllAsync();
    Task<GuestDto?> GetByIdAsync(int id);
    Task<GuestDto> CreateAsync(CreateGuestDto guestDto);
    Task<bool> UpdateAsync(int id, CreateGuestDto guestDto);
    Task<bool> DeleteAsync(int id);
}
