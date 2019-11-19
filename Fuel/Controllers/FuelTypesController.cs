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
    public class esfFuelTypesController : ControllerBase
    {
        private readonly FuelDbContext _context;

        public esfFuelTypesController(FuelDbContext context)
        {
            _context = context;
        }

        // GET: api/esfFuelTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<esfFuelTypes>>> GetesfFuelTypes()
        {
            return await _context.esfFuelTypes.ToListAsync();
        }

        // GET: api/esfFuelTypes/5
        [HttpGet("{fuID}")]
        public async Task<ActionResult<esfFuelTypes>> GetesfFuelTypes(int fuID)
        {
            var esfFuelTypes = await _context.esfFuelTypes.FindAsync(fuID);

            if (esfFuelTypes == null)
            {
                return NotFound();
            }

            return esfFuelTypes;
        }

        // PUT: api/esfFuelTypes/5
        [HttpPut("{fuID}")]
        public async Task<IActionResult> PutesfFuelTypes(int fuID, esfFuelTypes esfFuelTypes)
        {
            if (fuID != esfFuelTypes.fuID)
            {
                return BadRequest();
            }

            _context.Entry(esfFuelTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!esfFuelTypesExists(fuID))
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

        // POST: api/esfFuelTypes
        [HttpPost]
        public async Task<ActionResult<esfFuelTypes>> PostesfFuelTypes(esfFuelTypes esfFuelTypes)
        {
            _context.esfFuelTypes.Add(esfFuelTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetesfFuelTypes", new { id = esfFuelTypes.fuID }, esfFuelTypes);
        }

        // DELETE: api/esfFuelTypes/5
        [HttpDelete("{fuID}")]
        public async Task<ActionResult<esfFuelTypes>> DeleteesfFuelTypes(int fuID)
        {
            var esfFuelTypes = await _context.esfFuelTypes.FindAsync(fuID);
            if (esfFuelTypes == null)
            {
                return NotFound();
            }

            _context.esfFuelTypes.Remove(esfFuelTypes);
            await _context.SaveChangesAsync();

            return esfFuelTypes;
        }

        private bool esfFuelTypesExists(int fuID)
        {
            return _context.esfFuelTypes.Any(e => e.fuID == fuID);
        }
    }
}
