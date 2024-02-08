# Project Overview

The project was developed using the ASP.Net Core web application framework, employing an in-memory database provider for Entity Framework. The chosen approach involved the creation of a mock database with two distinct tables: Products and Categories.

## Products Table

The Products table captures detailed information about various products, including the following properties:

```csharp
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
```

## Categories Table

The Categories table is responsible for maintaining essential properties related to product categories:

```csharp
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public bool IsTaxExempt { get; set; }
}

```

## Relationships
The Products table establishes a one-to-one relationship with the Categories table. 

This design facilitates the seamless exclusion or inclusion of tax exemption based on a product's category. 

Additionally, the Products table includes a distinct attribute, IsImported, to track whether an individual product is imported or not. 

This information is not part of the Category table since products under the same category may have varying import statuses (e.g., Chocolate vs. Imported Chocolate).

## Web Interface

Upon establishing the database, a straightforward web interface was implemented, resembling a virtual shop. Users can add items to their basket, and during checkout, the system displays a page presenting the sales tax for each item alongside summary information.

## Testing

To ensure comprehensive coverage of test scenarios, the solution incorporates unit tests. These tests evaluate the accuracy of the Product tax calculation service against predefined scenarios, enhancing the overall reliability and robustness of the system.
