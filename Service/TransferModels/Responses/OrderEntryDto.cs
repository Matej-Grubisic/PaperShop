using DataAccess.Models;

namespace Service.TransferModels.Responses;

public class OrderEntryDto
{
    public OrderEntryDto FromEntity(OrderEntry orderEntry)
    {
        return new OrderEntryDto
        {
            Id = orderEntry.Id,
            Quantity = orderEntry.Quantity,
            ProductId = orderEntry.ProductId,
        };
    }
    
    public int Id { get; init; }
    
    public int Quantity { get; set; }

    public int? ProductId { get; set; }
    

}