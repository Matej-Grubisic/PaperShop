using DataAccess.Models;

namespace Service.TransferModels.Requests;

public class CreateCustomerDto
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Customer ToCustomer()
    {
        return new Customer()
        {
            Name = Name,
            Address = Address,
            Phone = Phone,
            Email = Email
        };
    }
}