using Microsoft.EntityFrameworkCore;
using TaxCalculator.Services;
using TaxCalculator.Services.Contexts;
using TaxCalculator.Services.Repositories;

namespace TaxCalculator;

public class Startup
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        serviceCollection.AddDbContext<TaxCalculatorDbContext>(b =>
            b.UseInMemoryDatabase(nameof(TaxCalculatorDbContext)));

        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IProductTaxCalculatorService, ProductTaxCalculatorService>();

        serviceCollection.AddRazorPages();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {

        applicationBuilder.UseStaticFiles();
        applicationBuilder.UseRouting();

        applicationBuilder.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}