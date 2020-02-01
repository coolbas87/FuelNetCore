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
    public class mnEnergyObjectFilesController : ControllerBase
    {
        private readonly FuelDbContext _context;

        public mnEnergyObjectFilesController(FuelDbContext context)
        {
            _context = context;
        }

        // GET: api/mnEnergyObjectFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mnEnergyObjectFiles>>> GetmnEnergyObjectFiles()
        {
            return await _context.mnEnergyObjectFiles.ToListAsync();
        }

        // GET: api/mnEnergyObjectFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mnEnergyObjectFiles>> GetmnEnergyObjectFiles(int id)
        {
            var mnEnergyObjectFiles = await _context.mnEnergyObjectFiles.FindAsync(id);

            if (mnEnergyObjectFiles == null)
            {
                return NotFound();
            }

            return mnEnergyObjectFiles;
        }

        // PUT: api/mnEnergyObjectFiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmnEnergyObjectFiles(int id, mnEnergyObjectFiles mnEnergyObjectFiles)
        {
            if (id != mnEnergyObjectFiles.eoflID)
            {
                return BadRequest();
            }

            _context.Entry(mnEnergyObjectFiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mnEnergyObjectFilesExists(id))
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

        // POST: api/mnEnergyObjectFiles
        [HttpPost]
        public async Task<ActionResult<mnEnergyObjectFiles>> PostmnEnergyObjectFiles(mnEnergyObjectFiles mnEnergyObjectFiles)
        {
            _context.mnEnergyObjectFiles.Add(mnEnergyObjectFiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmnEnergyObjectFiles", new { id = mnEnergyObjectFiles.eoflID }, mnEnergyObjectFiles);
        }

        // DELETE: api/mnEnergyObjectFiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<mnEnergyObjectFiles>> DeletemnEnergyObjectFiles(int id)
        {
            var mnEnergyObjectFiles = await _context.mnEnergyObjectFiles.FindAsync(id);
            if (mnEnergyObjectFiles == null)
            {
                return NotFound();
            }

            _context.mnEnergyObjectFiles.Remove(mnEnergyObjectFiles);
            await _context.SaveChangesAsync();

            return mnEnergyObjectFiles;
        }

        private bool mnEnergyObjectFilesExists(int id)
        {
            return _context.mnEnergyObjectFiles.Any(e => e.eoflID == id);
        }
    }
}
