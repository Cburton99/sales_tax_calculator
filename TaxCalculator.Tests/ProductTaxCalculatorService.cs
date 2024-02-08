using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TaxCalculator.Models;
using TaxCalculator.Models.Database;
using TaxCalculator.Services;
using TaxCalculator.Services.Contexts;
using TaxCalculator.Services.Repositories;

namespace TaxCalculator.Tests
{
    public class Tests
    {
        [TestCase("1,6,11", 29.83, 1.50)]
        [TestCase("16,23", 65.15, 7.65)]
        [TestCase("24,22,25,17", 74.68, 6.7)]
        public void Test1(string productIdString, decimal expectedTaxedTotal, decimal expectedSalesTax)
        {
            DbContextOptions<TaxCalculatorDbContext> contextOptions =
                new DbContextOptionsBuilder<TaxCalculatorDbContext>()
                    .UseInMemoryDatabase("TestDatabase")
                    .Options;

            TaxCalculatorDbContext dbContext = new(contextOptions);

            ICategoryRepository categoryRepository = new CategoryRepository(dbContext);
            IProductRepository productRepository = new ProductRepository(dbContext);
            IProductTaxCalculatorService productTaxCalculatorService = new ProductTaxCalculatorService();

            categoryRepository.SeedCategories();
            productRepository.SeedProducts();

            int[] productIds = productIdString
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            List<Product> productsToTax = productRepository
                .GetProductsWithCategories()
                .Where(product => productIds.Contains(product.ProductId))
                .ToList();

            ProductReceipt productReceipt = productTaxCalculatorService
                .CalculateProductTaxForRange(productsToTax);

            Assert.That(productReceipt.TotalAfterTax, Is.EqualTo(expectedTaxedTotal));
            Assert.That(productReceipt.TotalAfterTax - productReceipt.Total, Is.EqualTo(expectedSalesTax));
        }
    }
}