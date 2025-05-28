namespace DotNetApiVersioning.Features.Catalog.V1.Models;

public record CatalogResponse(
    List<CatalogItemResponse> Items,
    int TotalCount,
    int Page,
    int Size
);

public record CatalogItemResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedAt
);