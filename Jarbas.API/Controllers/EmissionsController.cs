using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jarbas.Domain.Data;
using Jarbas.Domain.Entities;
using Jarbas.Domain.Repositories;

namespace Jarbas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmissionsController : ControllerBase
    {
        private readonly APIContext _context;
        private EmissionRepository _repository { get; set; }

        public EmissionsController(APIContext context)
        {
            _context = context;
            _repository = new EmissionRepository(_context);
        }

        // GET: api/Emissions
        [HttpGet]
        public IEnumerable<Emission> Get()
        {
            var result = _repository.GetAll().Result;

            return result;
        }

        // GET: api/Emissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmission([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var travelMessage = await _context.Emission.FindAsync(id);

            if (travelMessage == null)
            {
                return NotFound();
            }

            return Ok(travelMessage);
        }

        // PUT: api/Emissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmission([FromRoute] Guid id, [FromBody] Emission travelMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmissionExists(id))
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

        // POST: api/Emissions
        [HttpPost]
        public async Task<IActionResult> PostEmission([FromBody] Emission travelMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Emission.Add(travelMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelMessage", new { id = travelMessage.Id }, travelMessage);
        }

        // DELETE: api/Emissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmission([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var travelMessage = await _context.Emission.FindAsync(id);
            if (travelMessage == null)
            {
                return NotFound();
            }

            _context.Emission.Remove(travelMessage);
            await _context.SaveChangesAsync();

            return Ok(travelMessage);
        }

        private bool EmissionExists(Guid id)
        {
            return _context.Emission.Any(e => e.Id == id);
        }
    }
}