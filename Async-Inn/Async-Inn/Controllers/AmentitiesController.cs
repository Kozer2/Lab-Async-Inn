using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Data.Interfaces;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmentitiesController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;
        private readonly IAmentity amentityRepo;

        public AmentitiesController(AsyncInnDbContext context, IAmentity amentityRepo)
        {
            _context = context;
            this.amentityRepo = amentityRepo;
        }

        // GET: api/Amentities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amentity>>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        // GET: api/Amentities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amentity>> GetAmentity(int id)
        {
            var amentity = await _context.Amenities.FindAsync(id);

            if (amentity == null)
            {
                return NotFound();
            }

            return amentity;
        }

        // PUT: api/Amentities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmentity(int id, Amentity amentity)
        {
            if (id != amentity.Id)
            {
                return BadRequest();
            }

            _context.Entry(amentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmentityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Amentities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amentity>> PostAmentity(Amentity amentity)
        {
            _context.Amenities.Add(amentity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmentity", new { id = amentity.Id }, amentity);
        }

        // DELETE: api/Amentities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmentity(int id)
        {
            var amentity = await _context.Amenities.FindAsync(id);
            if (amentity == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amentity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmentityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
