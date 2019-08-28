using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace PierreTreats.Models
{
  public class PierreTreatsContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavor> Flavors {get; set;}

    public DbSet<Treat> Treats {get; set;}

    public DbSet<FlavorTreat> FlavorTreats {get; set;}

    public PierreTreatsContext(DbContextOptions options) : base(options) { }
  }
}