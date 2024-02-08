using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Models;
using TaxCalculator.Models.Database;

namespace TaxCalculator.Services;

public class ProductTaxCalculatorService : IProductTaxCalculatorService
{
    public ProductReceipt CalculateProductTaxForRange(List<Product> products)
    {
        ProductReceipt productReceipt = new()
        {
            Total = products.Sum(product => product.Price),
            TaxedProducts = new ()
        };

        foreach (Product product in products)
        {
            decimal taxPercentage = 0;

            if (product.IsImported)
            {
                taxPercentage += 5;
            }

            if (!product.Category.IsTaxExempt)
            {
                taxPercentage += 10;
            }

            decimal salesTaxToPay = Math.Ceiling(((product.Price * taxPercentage) / 100) * 20) / 20;
            decimal amountAfterTax = product.Price + salesTaxToPay;

            ProductReceiptItem productReceiptItem = new()
            {
                Name = product.Name,
                OriginalPrice = product.Price,
                PriceAfterTax = amountAfterTax,
            };

            productReceipt.TaxedProducts.Add(productReceiptItem);
        }

        productReceipt.TotalAfterTax = productReceipt.TaxedProducts.Sum(product => product.PriceAfterTax);

        return productReceipt;
    }
}