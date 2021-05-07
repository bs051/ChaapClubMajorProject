using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChaapClubMajorProject.Data;
using ChaapClubMajorProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ChaapClubMajorProject.Controllers
{
    public class OrderPlacedsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderPlacedsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "power")]
        // GET: OrderPlaceds
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderPlaceds.ToListAsync());
        }

        [Authorize(Roles = "power")]
        // GET: OrderPlaceds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.OrderPlaceds
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        [Authorize]
        // GET: OrderPlaceds/Create
        public IActionResult Create()
        {
            ViewData["ClubID"] = new SelectList(_context.ChaapClubs, "ClubID", "FoodName");
            return View();
        }

        // POST: OrderPlaceds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Description,Quantity,ClubID")] OrderPlaced foodOrder)
        {
            ModelState.Remove("Price");
            ModelState.Remove("TotalAmount");
            ModelState.Remove("UserID");
            ModelState.Remove("OrderDate");

            if (ModelState.IsValid)
            {

                var foodInfo = await _context.ChaapClubs
                    .FirstOrDefaultAsync(m => m.ClubID == foodOrder.ClubID);
                foodOrder.Price = foodInfo.Price;
                foodOrder.TotalAmount = foodOrder.Price * foodOrder.Quantity;
                foodOrder.UserID = _userManager.GetUserName(this.User);
                foodOrder.OrderDate = DateTime.Now;
                _context.Add(foodOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success", "Home");
            }
            ViewData["ClubID"] = new SelectList(_context.ChaapClubs, "ClubID", "FoodName", foodOrder.ClubID);
            return View(foodOrder);
        }


        [Authorize(Roles = "power")]
        // GET: OrderPlaceds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.OrderPlaceds
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        // POST: OrderPlaceds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodOrder = await _context.OrderPlaceds.FindAsync(id);
            _context.OrderPlaceds.Remove(foodOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodOrderExists(int id)
        {
            return _context.OrderPlaceds.Any(e => e.OrderID == id);
        }
    }
}
