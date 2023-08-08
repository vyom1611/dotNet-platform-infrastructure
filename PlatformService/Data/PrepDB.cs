using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("Seeding data....");

            context.Platforms.AddRange(
                new Platform() { Name = "Android", Publisher = "Google", Cost = "Free" },
                new Platform() { Name = "iOS", Publisher = "Apple", Cost = "Free" },
                new Platform() { Name = "Windows", Publisher = "Microsoft", Cost = "Free" });

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--- We already have data ---");
        }
    }
}