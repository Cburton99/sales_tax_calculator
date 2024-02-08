using TaxCalculator.Models.Database;

namespace TaxCalculator.Services.Repositories;

public interface IProductRepository
{
    void SeedProducts();

    List<Product> GetProductsWithCategories();
}