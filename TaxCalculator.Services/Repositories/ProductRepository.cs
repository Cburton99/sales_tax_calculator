using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models.Database;
using TaxCalculator.Models.Enums;
using TaxCalculator.Services.Contexts;

namespace TaxCalculator.Services.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly TaxCalculatorDbContext _dbContext;

    public ProductRepository(TaxCalculatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Because we are using IN memory database, just a pre-caution seeding so we always have data.
    public void SeedProducts()
    {
        if (!_dbContext.Products.Any())
        {
            Product[] products =
            {
                new()
                {
                    CategoryId = (int)CategoriesEnum.Books,
                    Name = "The Adventures of C and Sharp",
                    Description = "Award winning book with a description",
                    IsImported = false,
                    Price = 12.49M,
                    ProductId = 1
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Books,
                    Name = "The Life of a Pointer",
                    Description = "Award winning book with a description",
                    IsImported = false,
                    Price = 11.99M,
                    ProductId = 2
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Books,
                    Name = "Mr array and Mrs List",
                    Description = "Award winning book with a description",
                    IsImported = false,
                    Price = 7.50M,
                    ProductId = 3
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Books,
                    Name = "Syntax Error : Return of the missing ;",
                    Description = "Award winning book with a description",
                    IsImported = false,
                    Price = 19.99M,
                    ProductId = 4
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Books,
                    Name = "The Adventures of C and Sharp",
                    Description = "Award winning book with a description",
                    IsImported = false,
                    Price = 4.99M,
                    ProductId = 5
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Music,
                    Name = "Generic Album 1",
                    Description = "Award winning album with a description",
                    IsImported = false,
                    Price = 14.99M,
                    ProductId = 6
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Music,
                    Name = "Generic Album 2",
                    Description = "Award winning album with a description",
                    IsImported = false,
                    Price = 11.99M,
                    ProductId = 7
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Music,
                    Name = "Generic Album 3",
                    Description = "Award winning album with a description",
                    IsImported = false,
                    Price = 7.50M,
                    ProductId = 8
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Music,
                    Name = "Generic Album 4",
                    Description = "Award winning album with a description",
                    IsImported = false,
                    Price = 19.99M,
                    ProductId = 9
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Music,
                    Name = "Generic Album 5",
                    Description = "Award winning album with a description",
                    IsImported = false,
                    Price = 4.99M,
                    ProductId = 10
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Generic Chocolate Bar 1",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 0.85M,
                    ProductId = 11
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Generic Chocolate Bar 2",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 11.99M,
                    ProductId = 12
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Generic Chocolate Bar 3",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 7.50M,
                    ProductId = 13
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Generic Chocolate Bar 4",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 19.99M,
                    ProductId = 14
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Generic Chocolate Bar 5",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 4.99M,
                    ProductId = 15
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Imported Box of Chocolates",
                    Description = "Award winning selection of chocolate with a description",
                    IsImported = true,
                    Price = 10.00M,
                    ProductId = 16
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Food,
                    Name = "Imported Box of Chocolates",
                    Description = "Award winning selection of chocolate with a description",
                    IsImported = true,
                    Price = 11.25M,
                    ProductId = 17
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Generic perfume 1",
                    Description = "Award winning chocolate with a description",
                    IsImported = false,
                    Price = 0.85M,
                    ProductId = 18
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Generic perfume 2",
                    Description = "Award winning perfume with a description",
                    IsImported = false,
                    Price = 11.99M,
                    ProductId = 19
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Generic perfume 3",
                    Description = "Award winning perfume with a description",
                    IsImported = false,
                    Price = 7.50M,
                    ProductId = 20
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Generic perfume 4",
                    Description = "Award winning perfume with a description",
                    IsImported = false,
                    Price = 19.99M,
                    ProductId = 21
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Generic perfume 5",
                    Description = "Award winning perfume with a description",
                    IsImported = false,
                    Price = 18.99M,
                    ProductId = 22
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Imported Perfume 1",
                    Description = "Award winning perfume with a description",
                    IsImported = true,
                    Price = 47.50M,
                    ProductId = 23
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Perfumes,
                    Name = "Imported Perfume 2",
                    Description = "Award winning perfume with a description",
                    IsImported = true,
                    Price = 27.99M,
                    ProductId = 24
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Medicine,
                    Name = "Paracetamol",
                    Description = "Award winning Medicine with a description",
                    IsImported = false,
                    Price = 9.75M,
                    ProductId = 25
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Medicine,
                    Name = "Generic Medicine 2",
                    Description = "Award winning Medicine with a description",
                    IsImported = false,
                    Price = 11.99M,
                    ProductId = 26
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Medicine,
                    Name = "Generic Medicine 3",
                    Description = "Award winning Medicine with a description",
                    IsImported = false,
                    Price = 7.50M,
                    ProductId = 27
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Medicine,
                    Name = "Generic Medicine 4",
                    Description = "Award winning Medicine with a description",
                    IsImported = false,
                    Price = 19.99M,
                    ProductId = 28
                },
                new()
                {
                    CategoryId = (int)CategoriesEnum.Medicine,
                    Name = "Generic Medicine 5",
                    Description = "Award winning Medicine with a description",
                    IsImported = false,
                    Price = 18.99M,
                    ProductId = 29
                },
            };

            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }
    }

    public List<Product> GetProductsWithCategories()
        => _dbContext
            .Products
            .Include(product => product.Category)
            .ToList();
}