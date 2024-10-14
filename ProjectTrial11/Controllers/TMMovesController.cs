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
    public class TMMovesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TMMovesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TMMoves
        public async Task<IActionResult> Index()
        {
              return _context.TMMove != null ? 
                          View(await _context.TMMove.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TMMove'  is null.");
        }

        // GET: TMMoves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TMMove == null)
            {
                return NotFound();
            }

            var tMMove = await _context.TMMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tMMove == null)
            {
                return NotFound();
            }

            return View(tMMove);
        }

        // GET: TMMoves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TMMoves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TMNumber,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] TMMove tMMove)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tMMove);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tMMove);
        }

        // GET: TMMoves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TMMove == null)
            {
                return NotFound();
            }

            var tMMove = await _context.TMMove.FindAsync(id);
            if (tMMove == null)
            {
                return NotFound();
            }
            return View(tMMove);
        }

        // POST: TMMoves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TMNumber,MoveName,MoveType,MoveCategory,MovePower,MoveAccuracy")] TMMove tMMove)
        {
            if (id != tMMove.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tMMove);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TMMoveExists(tMMove.Id))
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
            return View(tMMove);
        }

        // GET: TMMoves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TMMove == null)
            {
                return NotFound();
            }

            var tMMove = await _context.TMMove
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tMMove == null)
            {
                return NotFound();
            }

            return View(tMMove);
        }

        // POST: TMMoves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TMMove == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TMMove'  is null.");
            }
            var tMMove = await _context.TMMove.FindAsync(id);
            if (tMMove != null)
            {
                _context.TMMove.Remove(tMMove);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMMoveExists(int id)
        {
          return (_context.TMMove?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
