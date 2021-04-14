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


        public async Task CreateHotel(HotelDto hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteHotel(int id)
        {
            HotelDto hotel = await GetHotel(id);
            if(hotel == null)
            {
                return false;
            }
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<HotelDto> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<IEnumerable<HotelDto>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }

        public async Task<bool> PutHotel( HotelDto hotel)
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
