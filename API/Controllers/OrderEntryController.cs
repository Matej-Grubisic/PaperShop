using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderEntryController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public ActionResult<OrderEntry> CreateOrderEntry(CreateOrderEntryDto orderEntryDto)
    {
        var orderEntry = service.CreateOrderEntry(orderEntryDto);
        return Ok(orderEntry);
    }
}