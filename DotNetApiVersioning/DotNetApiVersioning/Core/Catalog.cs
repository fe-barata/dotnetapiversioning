namespace DotNetApiVersioning.Core;

public class Catalog
{
    // These are the properties of the Catalog class returned by the V1 API.
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // These are the properties of the Catalog class returned by the V2 API.
    // While it is not a breaking change, it is a change in the API response, so we will version it for demonstration.
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string? Category { get; set; }
}