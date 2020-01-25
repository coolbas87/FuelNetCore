using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fuel.Models;
using Fuel.ViewModel;

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
        public async Task<ActionResult<DailyFuelViewModel>> GetesfDailyFuel(int dcID)
        {
            var doc = await _context.esfDailyFuel
                .Include(d => d.Items)
                    .ThenInclude(ft => ft.esfFuelTypes)
                .Include(d => d.Items)
                    .ThenInclude(eo => eo.mnEnergyObjects)
                .Select(d => new DailyFuelViewModel
                {
                    HIID        = d.HIID,
                    dcID        = d.dcID,
                    emID        = d.emID,
                    dcDate      = d.dcDate,
                    Comment     = d.Comment,
                    CreateAt    = d.CreateAt,
                    CreateBy    = d.CreateBy,
                    dcNo        = d.dcNo,
                    dcType      = d.dcType,
                    EditAt      = d.EditAt,
                    EditBy      = d.EditBy,
                    Items       = d.Items
                        .Select(i => new DailyFuelItemsViewModel
                        {
                            HIID        = i.HIID,
                            dfiID       = i.dfiID,
                            dcID        = i.dcID,
                            Income      = i.Income,
                            Outcome     = i.Outcome,
                            Remains     = i.Remains,
                            FileName    = i.FileName,
                            eoID        = i.eoID,
                            eoCode      = i.mnEnergyObjects.eoCode,
                            EnObjName   = i.mnEnergyObjects.Name,
                            fuID        = i.fuID,
                            FuelCode    = i.esfFuelTypes.Code,
                            FuelName    = i.esfFuelTypes.Name,
                            CreateAt    = i.CreateAt,
                            CreateBy    = i.CreateBy,
                            EditAt      = i.EditAt,
                            EditBy      = i.EditBy,
                        }).ToList()
                }).FirstOrDefaultAsync(d => d.dcID == dcID);

            if (doc == null)
            {
                return NotFound();
            }

            return doc;
        }

        // PUT: api/DailyFuel/5
        [HttpPut("{dcID}")]
        public async Task<IActionResult> PutesfDailyFuel(int dcID, DailyFuelViewModel DailyFuel)
        {
            if (dcID != DailyFuel.dcID)
            {
                return BadRequest();
            }

            esfDailyFuel doc = _context.esfDailyFuel.Include(d => d.Items).FirstOrDefault(d => d.dcID == dcID);

            doc.dcNo = DailyFuel.dcNo;
            doc.dcDate = DailyFuel.dcDate;
            doc.emID = DailyFuel.emID;
            doc.Comment = DailyFuel.Comment;

            doc.Items.RemoveAll(item => !DailyFuel.Items.Any(i => i.dfiID == item.dfiID));

            foreach (var updItem in DailyFuel.Items)
            {
                var item = doc.Items.FirstOrDefault(i => (updItem.dfiID == i.dfiID));

                if (item == null)
                {
                    item = new esfDailyFuelItems
                    {
                        HIID = null,
                        dfiID = 0,
                        dcID = doc.dcID,
                        Income = updItem.Income,
                        Outcome = updItem.Outcome,
                        Remains = updItem.Remains,
                        FileName = updItem.FileName,
                        eoID = updItem.eoID,
                        fuID = updItem.fuID,
                        CreateAt = DateTime.Now,
                        CreateBy = 0,
                    };
                    doc.Items.Add(item);
                }
                else
                {
                    if (((updItem.eoID != item.eoID) || (updItem.FileName != item.FileName) || (updItem.fuID != item.fuID) || (updItem.Income != item.Income) ||
                        (updItem.Outcome != item.Outcome) || (updItem.Remains != item.Remains)))
                    {
                        item.eoID = updItem.eoID;
                        item.fuID = updItem.fuID;
                        item.FileName = updItem.FileName;
                        item.Income = updItem.Income;
                        item.Outcome = updItem.Outcome;
                        item.Remains = updItem.Remains;
                        item.EditAt = DateTime.Now;
                    }
                }
            }

            _context.Entry(doc).State = EntityState.Modified;

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
        public async Task<ActionResult<esfDailyFuel>> PostesfDailyFuel(DailyFuelViewModel DailyFuel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                esfDailyFuel doc = null;
                try
                {
                   doc = new esfDailyFuel
                    {
                        dcNo = DailyFuel.dcNo,
                        dcType = DailyFuel.dcType,
                        dcDate = DailyFuel.dcDate,
                        emID = DailyFuel.emID,
                        Comment = DailyFuel.Comment,
                        CreateAt = DateTime.Now,
                        CreateBy = 0
                    };

                    _context.esfDailyFuel.Add(doc);
                    await _context.SaveChangesAsync();
                    var items = DailyFuel.Items
                                .Select(i => new esfDailyFuelItems
                                {
                                    HIID = null,
                                    dfiID = 0,
                                    dcID = doc.dcID,
                                    Income = i.Income,
                                    Outcome = i.Outcome,
                                    Remains = i.Remains,
                                    FileName = i.FileName,
                                    eoID = i.eoID,
                                    fuID = i.fuID,
                                    CreateAt = DateTime.Now,
                                    CreateBy = 0,
                                }).ToList();
                    _context.esfDailyFuelItems.AddRange(items);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                return CreatedAtAction("GetesfDailyFuel", new { id = doc.dcID }, DailyFuel);
            }
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
