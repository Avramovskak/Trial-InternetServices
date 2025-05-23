﻿using HotelManagement.Data.Entities;

namespace HotelManagement.Data.Interfaces;

public interface IRoomRepository
{
    Task<List<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(int id);
    Task AddAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(Room room);
}
