namespace TaxCalculator.Models;

public class ProductReceiptItem
{
    public string Name { get; set;  }

    public decimal OriginalPrice { get; set; }

    public decimal TaxAmount => PriceAfterTax - OriginalPrice;

    public decimal PriceAfterTax { get; set; }
}