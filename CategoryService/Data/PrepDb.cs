using CategoryService.Models;

namespace CategoryService.Data;

public static class PrepDb
{
    public static void PrepPopulation(this IApplicationBuilder builder)
    {
        using(var ServiceScope = builder.ApplicationServices.CreateScope())
        {
            SeedData(ServiceScope.ServiceProvider.GetService<CategoryDbContext>());
        }
    }

    private static void SeedData(CategoryDbContext context)
    {
        if (!context.Categories.Any())
        {
            Console.WriteLine("Seeding Data...");

            context.AddRange(
                new Category("Phone"),
                new Category("Laptop"),
                new Category("TV"),
                new Category("Watch")
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("We Already Have Data !!");
        }
    }
}