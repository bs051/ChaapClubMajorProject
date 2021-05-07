using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChaapClubMajorProject.Data;
using ChaapClubMajorProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChaapClubMajorProject.Controllers
{
    [Authorize(Roles = "power")]
    public class FoodExposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodExposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodExpos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodExpos.ToListAsync());
        }

        // GET: FoodExpos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expo = await _context.FoodExpos
                .FirstOrDefaultAsync(m => m.ExpoID == id);
            if (expo == null)
            {
                return NotFound();
            }

            return View(expo);
        }

        // GET: FoodExpos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodExpos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpoID,ExpoName")] FoodExpo expo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expo);
        }

        // GET: FoodExpos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expo = await _context.FoodExpos.FindAsync(id);
            if (expo == null)
            {
                return NotFound();
            }
            return View(expo);
        }

        // POST: FoodExpos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpoID,ExpoName")] FoodExpo expo)
        {
            if (id != expo.ExpoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodCategoryExists(expo.ExpoID))
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
            return View(expo);
        }

        // GET: FoodExpos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodexpo = await _context.FoodExpos
                .FirstOrDefaultAsync(m => m.ExpoID == id);
            if (foodexpo == null)
            {
                return NotFound();
            }

            return View(foodexpo);
        }

        // POST: FoodExpos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xpo = await _context.FoodExpos.FindAsync(id);
            _context.FoodExpos.Remove(xpo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodExpos.Any(e => e.ExpoID == id);
        }
    }
}
