using Async_Inn.Models;
using Async_Inn.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data 
{
    public class HotelRepo : IHotel
    {

        private readonly AsyncInnDbContext _context;
        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }

        public async Task<bool> PutHotel( Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(hotel.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }


    }
}
