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
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn.Controllers
{
    [Authorize(Roles = "District Manager, Property Manager, Agent")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        /*private readonly AsyncInnDbContext _context;*/
        /*private readonly IHotel hotelRepo;*/
        /*public HotelsController(AsyncInnDbContext context, IHotel hotelRepo)
        {
            _context = context;
            this.hotelRepo = hotelRepo;
        }*/

        IHotel _hotelRepo;

        public HotelsController( IHotel hotelRepo)
        {
            _hotelRepo = hotelRepo;
            
        }



        // GET: api/Hotels
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet]
        public async Task<IEnumerable<HotelDto>> GetHotels()
        {
            return await _hotelRepo.GetHotels();
        }


        // GET: api/Hotels/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelRepo.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }


        /*// GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelRepo.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }*/

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            if (!await _hotelRepo.PutHotel(hotel))
                {
                return NotFound();
                }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotel(HotelDto hotel)
        {
            await _hotelRepo.CreateHotel(hotel);
            

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
             await _hotelRepo.DeleteHotel(id);
            /*if (hotel == null)
            {
                return NotFound();
            }*/

            /*_context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();*/

            return NoContent();
        }

        /*private bool HotelExists(int id)
        {
            return _HotelRepo.HotelExists.Any(e => e.Id == id);
        }*/
    }
}
