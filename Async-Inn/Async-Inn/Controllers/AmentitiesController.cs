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
    public class AmentitiesController : ControllerBase
    {
        /*private readonly AsyncInnDbContext _context;
        private readonly IAmentity amentityRepo;

        public AmentitiesController(AsyncInnDbContext context, IAmentity amentityRepo)
        {
            _context = context;
            this.amentityRepo = amentityRepo;
        }*/

        IAmentity _amentityRepo;
        public AmentitiesController(IAmentity amentityRepo)
        {

            _amentityRepo = amentityRepo;
        }

        // GET: api/Amentities
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet]
        public async Task<IEnumerable<Amentity>> GetAmentities()
        {
            return await _amentityRepo.GetAmentities();
        }

        // GET: api/Amentities/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Amentity>> GetAmentity(int id)
        {
            var amentity = await _amentityRepo.GetAmentity(id);

            if (amentity == null)
            {
                return NotFound();
            }

            return Ok(amentity);
        }

        // PUT: api/Amentities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmentity(int id, Amentity amentity)
        {
            if (id != amentity.Id)
            {
                return BadRequest();
            }

            if(!await _amentityRepo.PutAmentity(amentity))
            {
                return NotFound();
            }
         

            return NoContent();
        }

        // POST: api/Amentities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost]
        public async Task<ActionResult<Amentity>> PostAmentity(Amentity amentity)
        {
            
            await _amentityRepo.CreateAmentity(amentity);

            return CreatedAtAction("GetAmentity", new { id = amentity.Id }, amentity);
        }

        // DELETE: api/Amentities/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmentity(int id)
        {
            await _amentityRepo.DeleteAmentity(id);
           

            return NoContent();
        }

        
    }
}
