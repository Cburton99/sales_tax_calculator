using TaxCalculator.Models.Database;
using TaxCalculator.Services.Contexts;

namespace TaxCalculator.Services.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly TaxCalculatorDbContext _dbContext;

    public CategoryRepository(TaxCalculatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Because we are using IN memory database, just a pre-caution seeding so we always have data.
    public void SeedCategories()
    {
        if (!_dbContext.Categories.Any())
        {
            Category[] categories =
            {
                new()
                {
                    CategoryId = 1,
                    Name = "Books",
                    IsTaxExempt = true
                },
                new()
                {
                    CategoryId = 2,
                    Name = "Food",
                    IsTaxExempt = true
                },
                new()
                {
                    CategoryId = 3,
                    Name = "Medical",
                    IsTaxExempt = true
                },
                new()
                {
                    CategoryId = 4,
                    Name = "Perfumes",
                    IsTaxExempt = false
                },
                new()
                {
                    CategoryId = 5,
                    Name = "Music",
                    IsTaxExempt = false
                }
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();
        }
    }
}