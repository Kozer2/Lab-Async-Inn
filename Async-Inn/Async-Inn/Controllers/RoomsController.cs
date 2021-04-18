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
    public class RoomsController : ControllerBase
    {
        /*private readonly AsyncInnDbContext _context;
        private readonly IRoom roomRepo;

        public RoomsController(AsyncInnDbContext context, IRoom roomRepo)
        {
            _context = context;
            this.roomRepo = roomRepo;
        }*/

        IRoom _roomRepo;
       public RoomsController(IRoom roomRepo)
        {
            
            _roomRepo = roomRepo;
        }

        // GET: api/Rooms
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet]
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _roomRepo.GetRooms();
        }

        // GET: api/Rooms/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _roomRepo.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            if(!await _roomRepo.PutRoom(room))
            {
                return NoContent();
            }

            return NoContent();
        }

        // POST: api/Rooms
        [Authorize(Roles = "District Manager, Property Manager")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            
            await _roomRepo.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomRepo.DeleteRoom(id);
            

            return NoContent();
        }

        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AmenityAddToRoom(int roomId, int amenityId)
        {
            if (!await _roomRepo.AddAmenityToRoom(roomId, amenityId))
                return NotFound();


            return NoContent();
        }
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AmenityRemoveFromRoom(int roomId, int amenityId)
        {
            if (!await _roomRepo.RemoveAmentityFromRoom(roomId, amenityId))
                return NotFound();

            return NoContent();
        }



    }
}
