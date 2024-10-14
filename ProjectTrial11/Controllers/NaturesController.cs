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
    public class NaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Natures
        public async Task<IActionResult> Index()
        {
              return _context.Nature != null ? 
                          View(await _context.Nature.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nature'  is null.");
        }

        // GET: Natures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nature == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nature == null)
            {
                return NotFound();
            }

            return View(nature);
        }

        // GET: Natures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Natures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Increases,Decreases")] Nature nature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nature);
        }

        // GET: Natures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nature == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature.FindAsync(id);
            if (nature == null)
            {
                return NotFound();
            }
            return View(nature);
        }

        // POST: Natures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Increases,Decreases")] Nature nature)
        {
            if (id != nature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatureExists(nature.Id))
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
            return View(nature);
        }

        // GET: Natures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nature == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nature == null)
            {
                return NotFound();
            }

            return View(nature);
        }

        // POST: Natures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nature == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nature'  is null.");
            }
            var nature = await _context.Nature.FindAsync(id);
            if (nature != null)
            {
                _context.Nature.Remove(nature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatureExists(int id)
        {
          return (_context.Nature?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
