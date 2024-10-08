using System.Net.Security;
using DataAccess.Models;
using Service.TransferModels.Responses;

namespace Service.TransferModels.Requests;

public class CreatePaperDto
{
    public string Name { get; set; } = null!;

    public bool Discontinued { get; set; }

    public int Stock { get; set; }

    public double Price { get; set; }
    
    public ICollection<PropertyDto> PropertyIds { get; set; } = new List<PropertyDto>();


    public Paper ToPaper()
    {
        return new Paper()
        {
            Name = Name,
            Discontinued = Discontinued,
            Stock = Stock,
            Price = Price,
            Properties = PropertyIds.Select(p => new Property(){PropertyName = p.PropertyName, Id = p.Id}).ToList()
        };
    }
}