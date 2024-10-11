using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;

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
    
    [HttpPost]
    [Route("")]
    public ActionResult<Paper> CreateProperty(CreatePropertyDto createPropertyDto)
    {
        var property = service.CreateProperty(createPropertyDto);
        return Ok(property);
    }
    
}