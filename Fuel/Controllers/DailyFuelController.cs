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
    public class DailyFuelController : ControllerBase
    {
        private readonly FuelDbContext _context;

        public DailyFuelController(FuelDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyFuel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<esfDailyFuel>>> GetesfDailyFuel()
        {
            return await _context.esfDailyFuel.ToListAsync();
        }

        // GET: api/DailyFuel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<esfDailyFuel>> GetesfDailyFuel(int id)
        {
            var esfDailyFuel = await _context.esfDailyFuel.Include(d => d.Items).FirstAsync(d => d.dcID == id);

            if (esfDailyFuel == null)
            {
                return NotFound();
            }

            return esfDailyFuel;
        }

        // PUT: api/DailyFuel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutesfDailyFuel(int id, esfDailyFuel esfDailyFuel)
        {
            if (id != esfDailyFuel.dcID)
            {
                return BadRequest();
            }

            _context.Entry(esfDailyFuel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!esfDailyFuelExists(id))
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

        // POST: api/DailyFuel
        [HttpPost]
        public async Task<ActionResult<esfDailyFuel>> PostesfDailyFuel(esfDailyFuel esfDailyFuel)
        {
            _context.esfDailyFuel.Add(esfDailyFuel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetesfDailyFuel", new { id = esfDailyFuel.dcID }, esfDailyFuel);
        }

        // DELETE: api/DailyFuel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<esfDailyFuel>> DeleteesfDailyFuel(int id)
        {
            var esfDailyFuel = await _context.esfDailyFuel.FindAsync(id);
            if (esfDailyFuel == null)
            {
                return NotFound();
            }

            _context.esfDailyFuel.Remove(esfDailyFuel);
            await _context.SaveChangesAsync();

            return esfDailyFuel;
        }

        private bool esfDailyFuelExists(int id)
        {
            return _context.esfDailyFuel.Any(e => e.dcID == id);
        }
    }
}
