using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fuel.Models;

namespace Fuel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mnEnergyObjectsController : ControllerBase
    {
        private readonly FuelDbContext _context;

        public mnEnergyObjectsController(FuelDbContext context)
        {
            _context = context;
        }

        // GET: api/mnEnergyObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mnEnergyObjects>>> GetmnEnergyObjects()
        {
            return await _context.mnEnergyObjects.ToListAsync();
        }

        // GET: api/mnEnergyObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mnEnergyObjects>> GetmnEnergyObjects(int id)
        {
            var mnEnergyObjects = await _context.mnEnergyObjects.FindAsync(id);

            if (mnEnergyObjects == null)
            {
                return NotFound();
            }

            return mnEnergyObjects;
        }

        // PUT: api/mnEnergyObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmnEnergyObjects(int id, mnEnergyObjects mnEnergyObjects)
        {
            if (id != mnEnergyObjects.eoID)
            {
                return BadRequest();
            }

            _context.Entry(mnEnergyObjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mnEnergyObjectsExists(id))
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

        // POST: api/mnEnergyObjects
        [HttpPost]
        public async Task<ActionResult<mnEnergyObjects>> PostmnEnergyObjects(mnEnergyObjects mnEnergyObjects)
        {
            _context.mnEnergyObjects.Add(mnEnergyObjects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmnEnergyObjects", new { id = mnEnergyObjects.eoID }, mnEnergyObjects);
        }

        // DELETE: api/mnEnergyObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<mnEnergyObjects>> DeletemnEnergyObjects(int id)
        {
            var mnEnergyObjects = await _context.mnEnergyObjects.FindAsync(id);
            if (mnEnergyObjects == null)
            {
                return NotFound();
            }

            _context.mnEnergyObjects.Remove(mnEnergyObjects);
            await _context.SaveChangesAsync();

            return mnEnergyObjects;
        }

        private bool mnEnergyObjectsExists(int id)
        {
            return _context.mnEnergyObjects.Any(e => e.eoID == id);
        }
    }
}
