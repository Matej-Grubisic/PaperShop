using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service;
using Service.TransferModels.Requests;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(IPaperService service,
    IOptionsMonitor<AppOptions> options
) : ControllerBase
{
    [HttpPost]
    [Route("")]
    public ActionResult<Customer> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        var customer = service.CreateCustomer(createCustomerDto);
        return Ok(customer);
    }

    [HttpGet]
    [Route("")]
    public ActionResult<List<Customer>> GetAllCustomers(int limit = 10, int startAt = 0)
    {
        var customers = service.GetAllCustomers(limit, startAt);
        return Ok(customers);
    }

    [HttpGet]
    [Route("{customerId}")]
    public ActionResult<Customer> GetCustomer(int customerId)
    {
        var customer = service.GetCustomerById(customerId); 
        return Ok(customer);
    }

    [HttpDelete]
    [Route("{customerId}")]
    public ActionResult<Customer> DeleteCustomer(int customerId)
    {
        service.DeleteCustomer(customerId);
        return Ok("Customer deleted:" + customerId + "!");
    }
}