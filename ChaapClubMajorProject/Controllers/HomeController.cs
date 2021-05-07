using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChaapClubMajorProject.Models;
using ChaapClubMajorProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ChaapClubMajorProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodExpos.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewAllYourChoices()
        {
            return View(await _context.YourChoices.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewAllExpos()
        {
            return View(await _context.FoodExpos.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewFoodByExpo(int? id)
        {
            var applicationDbContext = _context.ChaapClubs
            .Include(b => b.ExpoFood).Include(b => b.ExpoFood).Where(m => m.ExpoID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewFoodByYourChoice(int? id)
        {
            var applicationDbContext = _context.ChaapClubs
            .Include(b => b.ExpoFood).Include(b => b.ExpoFood).Where(m => m.ChoiceID == id);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> UserOrderHistory()
        {
            var applicationDbContext = _context.OrderPlaceds
            .Include(b => b.ChaapClub).Where(m => m.UserID == _userManager.GetUserName(this.User));
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
