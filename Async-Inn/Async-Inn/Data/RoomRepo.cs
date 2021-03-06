using Async_Inn.Data.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class RoomRepo : IRoom
    {
        private readonly AsyncInnDbContext _context;
        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            if (room == null)
            {
                return false;
            }
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Room> GetRoom(int id)
        {
            
            var gettingRooms = await _context.Rooms.FindAsync(id);
            return gettingRooms;
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        public async Task<bool> PutRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }


        }

        // create amentities for rooms
        public async Task<bool> AddAmenityToRoom(int roomId, int amenityId)
        {
            var roomAmentity = new RoomAmenity
            {
                AmenityId = amenityId,
                RoomId = roomId,
            };
             _context.RoomAmenities.Add(roomAmentity);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.FindAsync(roomId, amenityId);
            if (roomAmenity == null)
                return false;

            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
