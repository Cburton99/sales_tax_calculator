namespace TaxCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.AddServerHeader = false;
                });

                webBuilder.UseStartup<Startup>();
            })
            .Build();

        host.Run();
    }
}