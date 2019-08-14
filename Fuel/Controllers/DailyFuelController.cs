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
        [HttpGet("{dcID}")]
        public async Task<ActionResult<esfDailyFuel>> GetesfDailyFuel(int dcID)
        {
            var doc = await _context.esfDailyFuel
                .Include(d => d.Items)
                    .ThenInclude(ft => ft.esfFuelTypes)
                .Include(d => d.Items)
                    .ThenInclude(eo => eo.mnEnergyObjects)
                .FirstOrDefaultAsync(d => d.dcID == dcID);

            if (doc == null)
            {
                return NotFound();
            }

            return doc;
        }

        // PUT: api/DailyFuel/5
        [HttpPut("{dcID}")]
        public async Task<IActionResult> PutesfDailyFuel(int dcID, esfDailyFuel esfDailyFuel)
        {
            if (dcID != esfDailyFuel.dcID)
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
                if (!esfDailyFuelExists(dcID))
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
        [HttpDelete("{dcID}")]
        public async Task<ActionResult<esfDailyFuel>> DeleteesfDailyFuel(int dcID)
        {
            var esfDailyFuel = await _context.esfDailyFuel.FindAsync(dcID);
            if (esfDailyFuel == null)
            {
                return NotFound();
            }

            _context.esfDailyFuel.Remove(esfDailyFuel);
            await _context.SaveChangesAsync();

            return esfDailyFuel;
        }

        private bool esfDailyFuelExists(int dcID)
        {
            return _context.esfDailyFuel.Any(e => e.dcID == dcID);
        }
    }
}
