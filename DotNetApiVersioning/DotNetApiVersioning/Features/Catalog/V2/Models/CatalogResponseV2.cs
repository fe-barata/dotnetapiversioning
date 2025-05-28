namespace DotNetApiVersioning.Features.Catalog.V2.Models;

public record CatalogResponseV2(
    List<CatalogItemResponseV2> Items,
    int TotalCount,
    int Page,
    int Size
);

public record CatalogItemResponseV2(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string? Category
);