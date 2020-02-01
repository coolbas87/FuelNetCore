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
    public class mnEnergyObjectFuelsController : ControllerBase
    {
        private readonly FuelDbContext _context;

        public mnEnergyObjectFuelsController(FuelDbContext context)
        {
            _context = context;
        }

        // GET: api/mnEnergyObjectFuels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mnEnergyObjectFuel>>> GetmnEnergyObjectFuel()
        {
            return await _context.mnEnergyObjectFuel.ToListAsync();
        }

        // GET: api/mnEnergyObjectFuels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mnEnergyObjectFuel>> GetmnEnergyObjectFuel(int id)
        {
            var mnEnergyObjectFuel = await _context.mnEnergyObjectFuel.FindAsync(id);

            if (mnEnergyObjectFuel == null)
            {
                return NotFound();
            }

            return mnEnergyObjectFuel;
        }

        // PUT: api/mnEnergyObjectFuels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmnEnergyObjectFuel(int id, mnEnergyObjectFuel mnEnergyObjectFuel)
        {
            if (id != mnEnergyObjectFuel.eofID)
            {
                return BadRequest();
            }

            _context.Entry(mnEnergyObjectFuel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mnEnergyObjectFuelExists(id))
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

        // POST: api/mnEnergyObjectFuels
        [HttpPost]
        public async Task<ActionResult<mnEnergyObjectFuel>> PostmnEnergyObjectFuel(mnEnergyObjectFuel mnEnergyObjectFuel)
        {
            _context.mnEnergyObjectFuel.Add(mnEnergyObjectFuel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmnEnergyObjectFuel", new { id = mnEnergyObjectFuel.eofID }, mnEnergyObjectFuel);
        }

        // DELETE: api/mnEnergyObjectFuels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<mnEnergyObjectFuel>> DeletemnEnergyObjectFuel(int id)
        {
            var mnEnergyObjectFuel = await _context.mnEnergyObjectFuel.FindAsync(id);
            if (mnEnergyObjectFuel == null)
            {
                return NotFound();
            }

            _context.mnEnergyObjectFuel.Remove(mnEnergyObjectFuel);
            await _context.SaveChangesAsync();

            return mnEnergyObjectFuel;
        }

        private bool mnEnergyObjectFuelExists(int id)
        {
            return _context.mnEnergyObjectFuel.Any(e => e.eofID == id);
        }
    }
}
