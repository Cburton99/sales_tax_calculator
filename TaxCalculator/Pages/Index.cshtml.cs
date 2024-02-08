using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalculator.Models.Database;
using TaxCalculator.Models.Enums;
using TaxCalculator.Services;
using TaxCalculator.Services.Repositories;

namespace TaxCalculator.Pages;

public class IndexModel : PageModel
{
    public ProductReceipt PurchasedProducts { get; set; }

    public bool IsCheckout { get; set; } = false;

    public List<Product> Products { get; set; }

    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductTaxCalculatorService _taxCalculatorService;

    public IndexModel(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IProductTaxCalculatorService taxCalculatorService)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _taxCalculatorService = taxCalculatorService;
    }

    public void OnGet()
    {
        _categoryRepository.SeedCategories();
        _productRepository.SeedProducts();

        Products = _productRepository
            .GetProductsWithCategories();
    }

    public void OnPost()
    {
        IsCheckout = true;

        int[] basketProductIds = Request.Form["basket-ids"]
            .ToString()
            .Split(",")
            .Select(int.Parse)
            .ToArray();

        List<Product> purchasedProducts = _productRepository
            .GetProductsWithCategories()
            .Where(product => basketProductIds.Contains(product.ProductId))
            .ToList();

        PurchasedProducts = _taxCalculatorService.CalculateProductTaxForRange(purchasedProducts);
    }
}