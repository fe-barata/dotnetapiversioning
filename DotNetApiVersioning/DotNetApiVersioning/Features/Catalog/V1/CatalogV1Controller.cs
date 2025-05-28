using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApiVersioning.Features.Catalog.V1;

[ApiVersion("1", Deprecated = true)]
[ApiController]
[Route("api/v{version:apiVersion}/catalog")]
public class CatalogV1Controller(ICatalogV1Service catalogService) : ControllerBase
{
    [HttpGet]
    public IActionResult ListCatalogs(int page = 1, int size = 10)
    {
        // Add sunset header to inform clients about the upcoming removal
        Response.Headers.Append("Sunset", DateTime.UtcNow.AddMonths(3).ToString("R"));
        var result = catalogService.GetCatalog(page, size);
        return Ok(result);
    }
}