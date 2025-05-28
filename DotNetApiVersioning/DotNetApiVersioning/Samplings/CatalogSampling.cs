using DotNetApiVersioning.Core;

namespace DotNetApiVersioning.Samplings;

public class CatalogSampling
{
    public static List<Catalog> Sample(int page = 1, int size = 10)
    {
        // This is a sampling of the V1 API for the Catalog.
        // It returns a list of Catalog items with their details.
        var catalogItems = new List<Catalog>();
        for (var i = 1; i <= size; i++)
        {
            catalogItems.Add(new Catalog
            {
                Id = Guid.NewGuid(),
                Name = $"Catalog Item {i}",
                Description = $"Description for Catalog Item {i}",
                CreatedAt = DateTime.UtcNow.AddDays(-i), // Simulating creation date
                UpdatedAt = DateTime.UtcNow.AddDays(-i), // Simulating update date
                Category = i % 2 == 0 ? "Category A" : "Category B" // Simulating categories
            });
        }

        return catalogItems;
    }
}