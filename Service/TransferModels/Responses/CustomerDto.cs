using DataAccess.Models;

namespace Service.TransferModels.Responses;

public class CustomerDto
{
    public CustomerDto FromEntity(Customer customer)
    {
        return new CustomerDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email,
            Orders = customer.Orders
        };
    }
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}