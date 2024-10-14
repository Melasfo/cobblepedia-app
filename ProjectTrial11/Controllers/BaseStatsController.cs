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

namespace ProjectTrial11.Controllers
{
    [Authorize(Policy = "RequireEmailAdmin")]
    public class BaseStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseStats
        public async Task<IActionResult> Index()
        {
              return _context.BaseStat != null ? 
                          View(await _context.BaseStat.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BaseStat'  is null.");
        }

        // GET: BaseStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BaseStat == null)
            {
                return NotFound();
            }

            var baseStat = await _context.BaseStat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseStat == null)
            {
                return NotFound();
            }

            return View(baseStat);
        }

        // GET: BaseStats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseStats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CobblemonStatsName,HP,Attack,Defense,SpecialAttack,SpecialDefense,Speed,TotalStats")] BaseStat baseStat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseStat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseStat);
        }

        // GET: BaseStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BaseStat == null)
            {
                return NotFound();
            }

            var baseStat = await _context.BaseStat.FindAsync(id);
            if (baseStat == null)
            {
                return NotFound();
            }
            return View(baseStat);
        }

        // POST: BaseStats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CobblemonStatsName,HP,Attack,Defense,SpecialAttack,SpecialDefense,Speed,TotalStats")] BaseStat baseStat)
        {
            if (id != baseStat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseStat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseStatExists(baseStat.Id))
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
            return View(baseStat);
        }

        // GET: BaseStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BaseStat == null)
            {
                return NotFound();
            }

            var baseStat = await _context.BaseStat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseStat == null)
            {
                return NotFound();
            }

            return View(baseStat);
        }

        // POST: BaseStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BaseStat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BaseStat'  is null.");
            }
            var baseStat = await _context.BaseStat.FindAsync(id);
            if (baseStat != null)
            {
                _context.BaseStat.Remove(baseStat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseStatExists(int id)
        {
          return (_context.BaseStat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
