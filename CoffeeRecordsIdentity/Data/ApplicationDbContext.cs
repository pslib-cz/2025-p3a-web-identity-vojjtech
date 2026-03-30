using CoffeeRecordsIdentity.Areas.Identity.Data;
using CoffeeRecordsIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeRecordsIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<CoffeeRecordsIdentityUser>
    {
        public DbSet<CoffeeCup> Cups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
