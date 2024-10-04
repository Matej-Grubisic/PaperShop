using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult<List<Property>> GetAllPropreties()
    {
        var properties = service.GetAllProperties();
        return Ok(properties);
    }
    
}