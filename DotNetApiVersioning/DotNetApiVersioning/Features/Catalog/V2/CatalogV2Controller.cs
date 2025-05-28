using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApiVersioning.Features.Catalog.V2;

[ApiVersion("2")]
[ApiController]
[Route("api/v{version:apiVersion}/catalog")]
public class CatalogV2Controller(ICatalogV2Service catalogService) : ControllerBase
{
    [HttpGet]
    public IActionResult ListCatalogs(int page = 1, int size = 10)
    {
        var result = catalogService.GetCatalog(page, size);
        return Ok(result);
    }
}