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
    public class LevelUpMovesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LevelUpMovesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LevelUpMoves
        public async Task<IActionResult> Index()
        {
              return _context.LevelUpMove != null ? 
                          View(await _context.LevelUpMove.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LevelUpMove'  is null.");
        }

        // GET: LevelUpMoves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LevelUpMove == null)
            {
                return NotFound();
            }

            var levelUpMove = await _context.LevelUpMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelUpMove == null)
            {
                return NotFound();
            }

            return View(levelUpMove);
        }

        // GET: LevelUpMoves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LevelUpMoves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MoveLevel,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] LevelUpMove levelUpMove)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levelUpMove);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelUpMove);
        }

        // GET: LevelUpMoves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LevelUpMove == null)
            {
                return NotFound();
            }

            var levelUpMove = await _context.LevelUpMove.FindAsync(id);
            if (levelUpMove == null)
            {
                return NotFound();
            }
            return View(levelUpMove);
        }

        // POST: LevelUpMoves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MoveLevel,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] LevelUpMove levelUpMove)
        {
            if (id != levelUpMove.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelUpMove);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelUpMoveExists(levelUpMove.Id))
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
            return View(levelUpMove);
        }

        // GET: LevelUpMoves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LevelUpMove == null)
            {
                return NotFound();
            }

            var levelUpMove = await _context.LevelUpMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelUpMove == null)
            {
                return NotFound();
            }

            return View(levelUpMove);
        }

        // POST: LevelUpMoves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LevelUpMove == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LevelUpMove'  is null.");
            }
            var levelUpMove = await _context.LevelUpMove.FindAsync(id);
            if (levelUpMove != null)
            {
                _context.LevelUpMove.Remove(levelUpMove);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelUpMoveExists(int id)
        {
          return (_context.LevelUpMove?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
