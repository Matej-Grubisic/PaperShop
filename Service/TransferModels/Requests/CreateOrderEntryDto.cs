using DataAccess.Models;

namespace Service.TransferModels.Requests;

public class CreateOrderEntryDto
{
    public int Quantity { get; set; }

    public int? ProductId { get; set; }

    public OrderEntry ToOrderEntry()
    {
        return new OrderEntry()
        {
            Quantity = Quantity,
            ProductId = ProductId,
        };
    }
}