using Microsoft.EntityFrameworkCore;

namespace PierreTreats.Models
{
  public class PierreTreatsContext : DbContext
  {
    // public virtual DbSet<Category> Categories { get; set; }
    // public DbSet<Item> Items { get; set; }
    // public DbSet<CategoryItem> CategoryItem { get; set; }

    public PierreTreatsContext(DbContextOptions options) : base(options) { }
  }
}