using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models.Database;

namespace TaxCalculator.Services.Contexts;

public class TaxCalculatorDbContext : DbContext
{
    public TaxCalculatorDbContext(DbContextOptions? options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Product>()
            .ToTable("Product");
        
        modelBuilder
            .Entity<Category>()
            .ToTable("Category");
    }
}