namespace TaxCalculator.Models;

public class ProductReceipt
{
    public decimal Total { get; set; }

    public decimal TotalAfterTax { get; set; }

    public List<ProductReceiptItem> TaxedProducts { get; set; }
}