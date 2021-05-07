using ChaapClubMajorProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChaapClubMajorProject.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<YourChoice> YourChoices { get; set; }
        public DbSet<FoodExpo> FoodExpos { get; set; }
        public DbSet<ChaapClub> ChaapClubs { get; set; }
        public DbSet<OrderPlaced> OrderPlaceds { get; set; }
    }
}
