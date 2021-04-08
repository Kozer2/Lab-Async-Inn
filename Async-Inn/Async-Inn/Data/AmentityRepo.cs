using Async_Inn.Data.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class AmentityRepo : IAmentity
    {
        private readonly AsyncInnDbContext _context;
        public AmentityRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmentity(Amentity amentity)
        {
            _context.Amenities.Add(amentity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAmentity(int id)
        {
            Amentity amentity = await GetAmentity(id);
            if(amentity == null)
            {
                return false;
            }
            _context.Entry(amentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Amentity> GetAmentity(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<IEnumerable<Amentity>> GetAmentities()
        {
            return await _context.Amenities.ToListAsync();
        }

        private bool AmentityExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        public async Task<bool> PutAmentity(Amentity amentity)
        {
            _context.Entry(amentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmentityExists(amentity.Id))
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
