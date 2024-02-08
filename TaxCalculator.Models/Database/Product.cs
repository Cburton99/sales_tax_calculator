using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculator.Models.Database;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool IsImported { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }
}