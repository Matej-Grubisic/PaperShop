using Bogus;
using DataAccess.Models;
using FluentValidation.AspNetCore;
using Service.TransferModels.Requests;

namespace TestProject1;

public class TestObjects
{
        public static Paper GetPaper()
        {
            return new Faker<Paper>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Discontinued, f => false)
                .RuleFor(p => p.Stock, f => f.Random.Int())
                .RuleFor(p => p.Price, f => f.Random.Double());
        }

        public static Customer GetCustomer()
        {
            return new Faker<Customer>()
                .RuleFor(c => c.Id, f => f.Random.Int())
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Address, f => f.Address.StreetAddress())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, f => f.Internet.Email());
        }

        public static Order GetOrder()
        {
            return new Faker<Order>()
                .RuleFor(o => o.OrderDate, f => DateTime.UtcNow)
                .RuleFor(o => o.DeliveryDate, f => f.Date.SoonDateOnly())
                .RuleFor(o => o.Status, f => "pending")
                .RuleFor(o => o.TotalAmount, f => f.Random.Double())
                .RuleFor(o => o.CustomerId, f => f.Random.Int());
        }

        public static Property GetProperty()
        {
            return new Faker<Property>()
                .RuleFor(p => p.PropertyName, f => f.Commerce.Categories(1).ToString());
        }

        public static CreateOrderEntryDto GetOrderEntry()
        {
            return new Faker<CreateOrderEntryDto>()
                .RuleFor(e => e.ProductId, f => f.Random.Int())
                .RuleFor(e => e.Quantity, f => f.Random.Int());
        }
}