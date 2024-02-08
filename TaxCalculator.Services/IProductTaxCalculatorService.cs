using TaxCalculator.Models.Database;

namespace TaxCalculator.Services;

public interface IProductTaxCalculatorService
{
    ProductReceipt CalculateProductTaxForRange(List<Product> products);
}