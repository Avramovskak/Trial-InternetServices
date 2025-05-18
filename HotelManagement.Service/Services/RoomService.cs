using HotelManagement.Service.DTOs;
using HotelManagement.Service.Interfaces;
using HotelManagement.Data.Entities;
using HotelManagement.Data.Interfaces;
using HotelManagement.Service.DTOs;

namespace HotelManagement.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Number = r.Number,
                Floor = r.Floor,
                Type = r.Type
            }).ToList();
        }

        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return null;

            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Floor = room.Floor,
                Type = room.Type
            };
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto dto)
        {
            var room = new Room
            {
                Number = dto.Number,
                Floor = dto.Floor,
                Type = dto.Type
            };

            await _roomRepository.AddAsync(room);

            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Floor = room.Floor,
                Type = room.Type
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateRoomDto dto)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return false;

            room.Number = dto.Number;
            room.Floor = dto.Floor;
            room.Type = dto.Type;

            await _roomRepository.UpdateAsync(room);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return false;

            await _roomRepository.DeleteAsync(room);
            return true;
        }
    }
}
