using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTrial11.Data;
using ProjectTrial11.Models;
using ProjectTrial11.ViewModels;

namespace ProjectTrial11.Controllers
{
    [Authorize(Policy = "RequireEmailAdmin")]
    public class CobblemonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public CobblemonsController(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Cobblemons
        public async Task<IActionResult> Index()
        {
            return _context.Cobblemon != null ? 
                          View(await _context.Cobblemon.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cobblemon'  is null.");
        }

        // GET: Cobblemons/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobblemon == null)
            {
                return NotFound();
            }

            var cobblemon = await _context.Cobblemon.
                Include(x => x.CobblemonCTypes).ThenInclude(CType => CType.CType)
                .Include(x=>x.CobblemonBaseStats).ThenInclude(BaseStat=>BaseStat.BaseStat)
                .Include(x=>x.CobblemonLevelUpMoves).ThenInclude(LevelUpMove=>LevelUpMove.LevelUpMove)
                .Include(x=>x.CobblemonTMMoves).ThenInclude(TMMove=>TMMove.TMMove)
                .Include(x=>x.CobblemonEggMoves).ThenInclude(EggMove=>EggMove.EggMove)
                .Include(x=>x.CobblemonLocations).ThenInclude(Location=> Location.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(cobblemon == null)
            {
                return NotFound();
            }
            return View(cobblemon);         
        }

        // GET: Cobblemons/Create
        public IActionResult Create()
        {
            var CTypes = _context.CType.ToList();
            ViewBag.CTypes = CTypes;
            var BaseStats = _context.BaseStat.ToList();
            ViewBag.BaseStats = BaseStats;
            var TMMoves = _context.TMMove.ToList();
            ViewBag.TMMoves = TMMoves;
            var LevelUpMoves = _context.LevelUpMove.ToList();
            ViewBag.LevelUpMoves = LevelUpMoves;
            var EggMoves = _context.EggMove.ToList();
            ViewBag.EggMoves = EggMoves;
            var Locations = _context.Location.ToList();
            ViewBag.Locations = Locations;
            CobblemonViewModel model = new CobblemonViewModel();
            return View(model);
        }

        // POST: Cobblemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CobblemonViewModel model, [FromForm] IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if(Image!=null && Image.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                    var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images", uniqueFileName);
                    using(var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    model.ImagePath = Path.Combine("Images", uniqueFileName);
                }
                Cobblemon cobblemon = new Cobblemon()
                {
                    Name = model.Name,
                    Description = model.Description,
                    NationalDexNum = model.NationalDexNum,
                    Species = model.Species,
                    Weight = model.Weight,
                    Height = model.Height,
                    Abilities = model.Abilities,
                    CanEvolve = model.CanEvolve,
                    EvolutionMethod=model.EvolutionMethod,
                    ImagePath=model.ImagePath
                };

                _context.Add(cobblemon);
                if (cobblemon.CanEvolve)
                {
                    switch (cobblemon.EvolutionMethod)
                    {
                        case "When friendship is high":
                            cobblemon.Description += " This Cobblemon evolves when they are leveled up with a friendship/happiness of at least 220. As long as the Cobblemon has the required amount of happiness, unless there are other requirments for its evolution, it will attempt to evolve whenever it levels up by battle or Rare Candy.";
                            break;
                        case "When the cobblemon knows a certain move":
                            cobblemon.Description += " This Cobblemon evolves when they learn or know a required move, they have to be leveled up and have that specific move.";
                            break;
                        case "In certain locations":
                            cobblemon.Description += " This Cobblemon evolves when they are leveled up next to a certain location.";
                            break;
                        case "In a certain region":
                            cobblemon.Description += " This Cobblemon evolves when they are leveled up in a certain region.";
                            break;
                        case "At certain times":
                            cobblemon.Description += " This Cobblemon evolves when leveled up at a certain time of day.";
                            break;
                        case "While holding an item":
                            cobblemon.Description += " This Cobblemon evolves when they are holding a specific Evolution Item.";
                            break;
                        case "If the cobblemon is a certain gender":
                            cobblemon.Description += " This Cobblemon evolves when they are leveled up but their evolution depends on the Pokemon gender.";
                            break;
                        case "Evolution Stone":
                            cobblemon.Description += " This Cobblemon evolves when they are exposed to a Evolution Stone, in this case you would have to right click on your cobblemon.";
                            break;
                        case "Trade holding a certain item":
                            cobblemon.Description += " This Cobblemon evolves when they are traded while holding a certain item.";
                            break;
                        case "Trading for a certain cobblemon":
                            cobblemon.Description += "This Cobblemon evolves when they are traded with a specific Cobblemon.";
                            break;
                        case "Trading":
                            cobblemon.Description += "This Cobblemon evolves when they are traded with another player.";
                            break;
                    }
                }
                    if (model.CTypeIds != null && model.CTypeIds.Any())
                {
                    var selectedCTypes = _context.CType.Where(x => model.CTypeIds.Contains(x.Id)).ToList();
                    foreach (var CType in selectedCTypes)
                    {
                        _context.CobblemonCTypes.Add(new CobblemonCType { Cobblemon = cobblemon, CType = CType });
                    }
                }
                if (model.BaseStatIds != null && model.BaseStatIds.Any())
                {
                    var selectedBaseStats= _context.BaseStat.Where(x=>model.BaseStatIds.Contains(x.Id)).ToList();
                    foreach(var BaseStat in selectedBaseStats)
                    {
                        _context.CobblemonBaseStats.Add(new CobblemonBaseStat { Cobblemon=cobblemon, BaseStat=BaseStat});
                    }
                }
                if (model.TMMoveIds != null && model.TMMoveIds.Any())
                {
                    var selectedTMs = _context.TMMove.Where(x => model.TMMoveIds.Contains(x.Id)).ToList();
                    foreach (var TMmove in selectedTMs)
                    {
                        _context.CobblemonTMMoves.Add(new CobblemonTMMove { Cobblemon = cobblemon, TMMove = TMmove });
                    }
                }
                if (model.LevelUpMoveIds != null && model.LevelUpMoveIds.Any())
                {
                    var selectedLevelUpMoves = _context.LevelUpMove.Where(x => model.LevelUpMoveIds.Contains(x.Id)).ToList();
                    foreach (var LevelUpMove in selectedLevelUpMoves)
                    {
                        _context.CobblemonLevelUpMoves.Add(new CobblemonLevelUpMove { Cobblemon = cobblemon, LevelUpMove=LevelUpMove });
                    }
                }
                if (model.EggMoveIds != null && model.EggMoveIds.Any())
                {
                    var selectedEggMoves = _context.EggMove.Where(x => model.EggMoveIds.Contains(x.Id)).ToList();
                    foreach (var EggMove in selectedEggMoves)
                    {
                        _context.CobblemonEggMoves.Add(new CobblemonEggMove { Cobblemon = cobblemon, EggMove = EggMove });
                    }
                }
                if (model.LocationIds != null && model.LocationIds.Any())
                {
                    var selectedLocations = _context.Location.Where(x => model.LocationIds.Contains(x.Id)).ToList();
                    foreach (var Location in selectedLocations)
                    {
                        _context.CobblemonLocations.Add(new CobblemonLocation { Cobblemon = cobblemon, Location = Location });
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CTypes = _context.CType.ToList();
            ViewBag.BaseStats = _context.BaseStat.ToList();
            ViewBag.TMMoves = _context.TMMove.ToList();
            ViewBag.LevelUpMoves = _context.LevelUpMove.ToList();
            ViewBag.EggMoves=_context.EggMove.ToList();
            ViewBag.Locations=_context.Location.ToList();
            return View(model);
        }

        // GET: Cobblemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobblemon == null)
            {
                return NotFound();
            }

            var cobblemon = await _context.Cobblemon.FindAsync(id);
            if (cobblemon == null)
            {
                return NotFound();
            }
            return View(cobblemon);
        }

        // POST: Cobblemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,NationalDexNum,Type,Species,Height,Weight,Abilities")] Cobblemon cobblemon)
        {
            if (id != cobblemon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobblemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobblemonExists(cobblemon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cobblemon);
        }

        // GET: Cobblemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobblemon == null)
            {
                return NotFound();
            }

            var cobblemon = await _context.Cobblemon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobblemon == null)
            {
                return NotFound();
            }

            return View(cobblemon);
        }

        // POST: Cobblemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobblemon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cobblemon'  is null.");
            }
            var cobblemon = await _context.Cobblemon.FindAsync(id);
            if (cobblemon != null)
            {
                _context.Cobblemon.Remove(cobblemon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobblemonExists(int id)
        {
          return (_context.Cobblemon?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
