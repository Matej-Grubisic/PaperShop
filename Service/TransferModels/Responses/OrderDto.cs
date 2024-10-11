using DataAccess.Models;

namespace Service.TransferModels.Responses;

public class OrderDto
{
    public OrderDto FromEntity(Order order)
    {
        return new OrderDto()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            CustomerId = order.CustomerId,
            Customer = order.Customer,
            OrderEntries = order.OrderEntries.Select(oe => new OrderEntryDto
            {
                Id = oe.Id,
                ProductId = oe.ProductId,
                Quantity = oe.Quantity,
            }).ToList(),
        };
    }
    
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string Status { get; set; } = null!;

    public double TotalAmount { get; set; }

    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public ICollection<OrderEntryDto> OrderEntries { get; set; } = new List<OrderEntryDto>();
}