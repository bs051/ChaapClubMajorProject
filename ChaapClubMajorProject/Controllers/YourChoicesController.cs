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
    [Authorize(Roles="power")]
    public class YourChoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YourChoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YourChoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.YourChoices.ToListAsync());
        }

        // GET: YourChoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cho = await _context.YourChoices
                .FirstOrDefaultAsync(m => m.ChoiceID == id);
            if (cho == null)
            {
                return NotFound();
            }

            return View(cho);
        }

        // GET: YourChoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YourChoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChoiceID,ChoiceName")] YourChoice choic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(choic);
        }

        // GET: YourChoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choic = await _context.YourChoices.FindAsync(id);
            if (choic == null)
            {
                return NotFound();
            }
            return View(choic);
        }

        // POST: YourChoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChoiceID,ChoiceName")] YourChoice choice)
        {
            if (id != choice.ChoiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(choice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoiceExists(choice.ChoiceID))
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
            return View(choice);
        }

        // GET: YourChoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cho = await _context.YourChoices
                .FirstOrDefaultAsync(m => m.ChoiceID == id);
            if (cho == null)
            {
                return NotFound();
            }

            return View(cho);
        }

        // POST: YourChoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urCh = await _context.YourChoices.FindAsync(id);
            _context.YourChoices.Remove(urCh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoiceExists(int id)
        {
            return _context.YourChoices.Any(e => e.ChoiceID == id);
        }
    }
}
