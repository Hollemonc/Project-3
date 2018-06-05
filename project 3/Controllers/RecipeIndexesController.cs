using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_3.Data;
using project_3.Models;

namespace project_3.Controllers
{
    public class RecipeIndexesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeIndexesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipeIndexes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeIndex.ToListAsync());
        }

        // GET: RecipeIndexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIndex = await _context.RecipeIndex
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipeIndex == null)
            {
                return NotFound();
            }

            return View(recipeIndex);
        }

        // GET: RecipeIndexes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeIndexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Type")] RecipeIndex recipeIndex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeIndex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeIndex);
        }

        // GET: RecipeIndexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIndex = await _context.RecipeIndex.SingleOrDefaultAsync(m => m.ID == id);
            if (recipeIndex == null)
            {
                return NotFound();
            }
            return View(recipeIndex);
        }

        // POST: RecipeIndexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Type")] RecipeIndex recipeIndex)
        {
            if (id != recipeIndex.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeIndex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeIndexExists(recipeIndex.ID))
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
            return View(recipeIndex);
        }

        // GET: RecipeIndexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIndex = await _context.RecipeIndex
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recipeIndex == null)
            {
                return NotFound();
            }

            return View(recipeIndex);
        }

        // POST: RecipeIndexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeIndex = await _context.RecipeIndex.SingleOrDefaultAsync(m => m.ID == id);
            _context.RecipeIndex.Remove(recipeIndex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeIndexExists(int id)
        {
            return _context.RecipeIndex.Any(e => e.ID == id);
        }
    }
}
