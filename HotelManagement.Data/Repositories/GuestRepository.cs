﻿using HotelManagement.Data.DbContexts;
using HotelManagement.Data.Entities;
using HotelManagement.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guest>> GetAllAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetByIdAsync(int id)
        {
            return await _context.Guests.FindAsync(id);
        }

        public async Task AddAsync(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guest guest)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }
}

