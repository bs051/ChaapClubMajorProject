using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChaapClubMajorProject.Data;
using ChaapClubMajorProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;  
using Microsoft.AspNetCore.Authorization;

namespace ChaapClubMajorProject.Controllers
{
    [Authorize(Roles = "power")]
    public class ChaapClubsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ChaapClubsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: ChaapClubs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChaapClubs.Include(f => f.ExpoFood).Include(f => f.YourChoice);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChaapClubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodInfo = await _context.ChaapClubs
                .Include(f => f.ExpoFood)
                .Include(f => f.YourChoice)
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (foodInfo == null)
            {
                return NotFound();
            }

            return View(foodInfo);
        }

        // GET: ChaapClubs/Create
        public IActionResult Create()
        {
            ViewData["ExpoID"] = new SelectList(_context.FoodExpos, "ExpoID", "ExpoName");
            ViewData["ChoiceID"] = new SelectList(_context.YourChoices, "ChoiceID", "ChoiceName");
            return View();
        }

        // POST: ChaapClubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubID,FoodName,Description,File,Price,ChoiceID,ExpoID")] ChaapClub chInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await chInfo.File.FormFile.CopyToAsync(memoryStream);

                string photoname = chInfo.File.FormFile.FileName;
                chInfo.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(chInfo.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(chInfo);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "foodphotos");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = chInfo.ClubID + chInfo.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await chInfo.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpoID"] = new SelectList(_context.FoodExpos, "ExpoID", "ExpoName", chInfo.ExpoID);
            ViewData["ChoiceID"] = new SelectList(_context.YourChoices, "ChoiceID", "ChoiceName", chInfo.ChoiceID);
            return View(chInfo);
        }

        // GET: ChaapClubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chInfo = await _context.ChaapClubs.FindAsync(id);
            if (chInfo == null)
            {
                return NotFound();
            }
            ViewData["ExpoID"] = new SelectList(_context.FoodExpos, "ExpoID", "ExpoName", chInfo.ExpoID);
            ViewData["ChoiceID"] = new SelectList(_context.YourChoices, "ChoiceID", "ChoiceName", chInfo.ChoiceID);
            return View(chInfo);
        }

        // POST: ChaapClubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubID,FoodName,Description,Extension,Price,ChoiceID,ExpoID")] ChaapClub foodInfo)
        {
            if (id != foodInfo.ClubID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChaapClubExists(foodInfo.ClubID))
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
            ViewData["ExpoID"] = new SelectList(_context.FoodExpos, "ExpoID", "ExpoName", foodInfo.ExpoID);
            ViewData["ChoiceID"] = new SelectList(_context.YourChoices, "ChoiceID", "ChoiceName", foodInfo.ChoiceID);
            return View(foodInfo);
        }

        // GET: FoodInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodInfo = await _context.ChaapClubs
                .Include(f => f.ExpoFood)
                .Include(f => f.YourChoice)
                .FirstOrDefaultAsync(m => m.ClubID == id);
            if (foodInfo == null)
            {
                return NotFound();
            }

            return View(foodInfo);
        }

        // POST: ChaapClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodInfo = await _context.ChaapClubs.FindAsync(id);
            _context.ChaapClubs.Remove(foodInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChaapClubExists(int id)
        {
            return _context.ChaapClubs.Any(e => e.ClubID == id);
        }
    }
}
