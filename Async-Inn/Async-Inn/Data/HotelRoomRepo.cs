using Async_Inn.Data.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class HotelRoomRepo : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;
        public HotelRoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteHotelRoom(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomId);
            if (hotelRoom == null)
            {
                return false;
            }
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomId)
        {
            
            var gettingHotelRooms = await _context.HotelRooms.FindAsync(hotelId, roomId);
            return gettingHotelRooms;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRooms.ToListAsync();
        }

        private bool HotelRoomExists(int id, int number)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id && e.RoomNumber == number);
        }

        public async Task<bool> PutHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(hotelRoom.HotelId, hotelRoom.RoomNumber))
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
        /*public async Task<bool> AddAmenityToRoom(int roomId, int amenityId)
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
        }*/
    }
}
