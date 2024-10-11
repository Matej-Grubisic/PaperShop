using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public ActionResult<Order> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        var order = service.CreateOrder(orderDto);
        //var order = service.CreateOrder(orderDto);
        return Ok(order);
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<Order>> GetAllOrders()
    {
        var orders = service.GetAllOrders(); 
        return Ok(orders);
    }

    [HttpPatch]
    [Route("")]
    public ActionResult<Order> UpdateOrder(string status, int orderId)
    {
        var order = service.UpdateStatus(status, orderId);
        return Ok(order);
    }
}