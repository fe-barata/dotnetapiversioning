using DotNetApiVersioning.Features.Catalog.V2.Models;
using DotNetApiVersioning.Samplings;

namespace DotNetApiVersioning.Features.Catalog.V2;

public class CatalogV2Service : ICatalogV2Service
{
    public CatalogResponseV2 GetCatalog(int page = 1, int size = 10)
    {
        var catalogs = CatalogSampling.Sample(page, size);

        return new CatalogResponseV2(
            Items: catalogs.Select(c => new CatalogItemResponseV2(
                c.Id, c.Name, c.Description, c.CreatedAt, c.UpdatedAt, c.Category
            )).ToList(),
            TotalCount: catalogs.Count,
            Page: page,
            Size: size
        );
    }
}

public interface ICatalogV2Service
{
    CatalogResponseV2 GetCatalog(int page = 1, int size = 10);
}