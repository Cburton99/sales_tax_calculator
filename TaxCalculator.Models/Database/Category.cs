using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models.Database;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public bool IsTaxExempt { get; set; }
}