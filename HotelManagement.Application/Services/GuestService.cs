using HotelManagement.Application.DTOs;
using HotelManagement.Application.Interfaces;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Application.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _guestRepository;

    public GuestService(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task<List<GuestDto>> GetAllAsync()
    {
        var guests = await _guestRepository.GetAllAsync();
        return guests.Select(g => new GuestDto
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            DOB = g.DOB,
            Address = g.Address,
            Nationality = g.Nationality,
            CheckInDate = g.CheckInDate,
            CheckOutDate = g.CheckOutDate,
            RoomId = g.RoomId
        }).ToList();
    }

    public async Task<GuestDto?> GetByIdAsync(int id)
    {
        var g = await _guestRepository.GetByIdAsync(id);
        if (g == null) return null;
        return new GuestDto
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            DOB = g.DOB,
            Address = g.Address,
            Nationality = g.Nationality,
            CheckInDate = g.CheckInDate,
            CheckOutDate = g.CheckOutDate,
            RoomId = g.RoomId
        };
    }

    public async Task<GuestDto> CreateAsync(CreateGuestDto dto)
    {
        var g = new Guest
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DOB = dto.DOB,
            Address = dto.Address,
            Nationality = dto.Nationality,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            RoomId = dto.RoomId
        };

        await _guestRepository.AddAsync(g);

        return new GuestDto
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            DOB = g.DOB,
            Address = g.Address,
            Nationality = g.Nationality,
            CheckInDate = g.CheckInDate,
            CheckOutDate = g.CheckOutDate,
            RoomId = g.RoomId
        };
    }

    public async Task<bool> UpdateAsync(int id, CreateGuestDto dto)
    {
        var existing = await _guestRepository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.DOB = dto.DOB;
        existing.Address = dto.Address;
        existing.Nationality = dto.Nationality;
        existing.CheckInDate = dto.CheckInDate;
        existing.CheckOutDate = dto.CheckOutDate;
        existing.RoomId = dto.RoomId;

        await _guestRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _guestRepository.GetByIdAsync(id);
        if (existing == null) return false;

        await _guestRepository.DeleteAsync(existing);
        return true;
    }
}
