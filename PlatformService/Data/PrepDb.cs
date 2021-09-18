using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using PlatformService.Models;
using System;
namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var servicescope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicescope.ServiceProvider.GetService<AppDbContext>());
            }

        
        }

        private static void SeedData(AppDbContext context)
        {

            if (!context.Platforms.Any())
            {
                System.Console.WriteLine("----->Seeding Data.....");
                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "CNCF", Cost = "Free" }
                );
                context.SaveChanges();
            
            }
            else
            {
                Console.WriteLine("-----> We Already Have Data");
            }

        }
    }
}