using TaxCalculator.Models.Database;

namespace TaxCalculator.Services.Repositories;

public interface ICategoryRepository
{
    void SeedCategories();
}