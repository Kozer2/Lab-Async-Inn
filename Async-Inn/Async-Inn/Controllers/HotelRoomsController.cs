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
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        /*private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }*/

        IHotelRoom _hotelRoomRepo;
        public HotelRoomsController(IHotelRoom hotelRoomRepo)
        {

            _hotelRoomRepo = hotelRoomRepo;
        }

        // GET: api/HotelRooms
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("/api/Hotels/{hotelId}/Rooms")]
        public async Task<IEnumerable<HotelRoom>> GetHotelRooms()
        {
            return await _hotelRoomRepo.GetHotelRooms();
        }

        // GET: api/HotelRooms/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _hotelRoomRepo.GetHotelRoom(hotelId, roomId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelId)
            {
                return BadRequest();
            }

            if (!await _hotelRoomRepo.PutHotelRoom(hotelRoom))
            {
                return NoContent();
            }

            return NoContent();
        }

        // POST: api/HotelRooms
        [Authorize(Roles = "District Manager, Property Manager")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {

            await _hotelRoomRepo.CreateHotelRoom(hotelRoom);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomId)
        {
            await _hotelRoomRepo.DeleteHotelRoom(hotelId,  roomId);

            return NoContent();
        }

    }
}
