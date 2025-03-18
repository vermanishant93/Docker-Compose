using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Appling Migrations...");
            context.Database.Migrate();
            if (!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");
                context.ColourItems.AddRange(
                    new Colour() { Name = "Red" },
                    new Colour() { Name = "Green" },
                    new Colour() { Name = "Blue" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding.");
            }
        }

    }
}