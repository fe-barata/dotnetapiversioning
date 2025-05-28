using DotNetApiVersioning.Features.Catalog.V1.Models;
using DotNetApiVersioning.Samplings;

namespace DotNetApiVersioning.Features.Catalog.V1;

public class CatalogV1Service : ICatalogV1Service
{
    public CatalogResponse GetCatalog(int page = 1, int size = 10)
    {
        var catalogs = CatalogSampling.Sample(page, size);

        return new CatalogResponse(
            Items: catalogs.Select(c => new CatalogItemResponse(
                c.Id, c.Name, c.Description, c.CreatedAt
            )).ToList(),
            TotalCount: catalogs.Count,
            Page: page,
            Size: size
        );
    }
}

public interface ICatalogV1Service
{
    CatalogResponse GetCatalog(int page = 1, int size = 10);
}