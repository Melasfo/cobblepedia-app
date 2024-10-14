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
    public class EggMovesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EggMovesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EggMoves
        public async Task<IActionResult> Index()
        {
              return _context.EggMove != null ? 
                          View(await _context.EggMove.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EggMove'  is null.");
        }

        // GET: EggMoves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EggMove == null)
            {
                return NotFound();
            }

            var eggMove = await _context.EggMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eggMove == null)
            {
                return NotFound();
            }

            return View(eggMove);
        }

        // GET: EggMoves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EggMoves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] EggMove eggMove)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eggMove);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eggMove);
        }

        // GET: EggMoves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EggMove == null)
            {
                return NotFound();
            }

            var eggMove = await _context.EggMove.FindAsync(id);
            if (eggMove == null)
            {
                return NotFound();
            }
            return View(eggMove);
        }

        // POST: EggMoves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] EggMove eggMove)
        {
            if (id != eggMove.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eggMove);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EggMoveExists(eggMove.Id))
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
            return View(eggMove);
        }

        // GET: EggMoves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EggMove == null)
            {
                return NotFound();
            }

            var eggMove = await _context.EggMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eggMove == null)
            {
                return NotFound();
            }

            return View(eggMove);
        }

        // POST: EggMoves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EggMove == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EggMove'  is null.");
            }
            var eggMove = await _context.EggMove.FindAsync(id);
            if (eggMove != null)
            {
                _context.EggMove.Remove(eggMove);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EggMoveExists(int id)
        {
          return (_context.EggMove?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
