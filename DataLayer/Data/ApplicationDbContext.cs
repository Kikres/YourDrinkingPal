using DataLayer.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Drink> Drink { get; set; }
        public DbSet<Flavour> Flavour { get; set; }
        public DbSet<Glass> Glass { get; set; }
        public DbSet<Ingridient> Ingridient { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<Unit> Unit { get; set; }
    }
}