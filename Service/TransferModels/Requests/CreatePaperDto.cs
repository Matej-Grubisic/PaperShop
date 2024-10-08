using System.Net.Security;
using DataAccess.Models;

namespace Service.TransferModels.Requests;

public class CreatePaperDto
{
    public string Name { get; set; } = null!;

    public bool Discontinued { get; set; }

    public int Stock { get; set; }

    public double Price { get; set; }
    
    public ICollection<Property> Properties { get; set; } = new List<Property>();


    public Paper ToPaper()
    {
        return new Paper()
        {
            Name = Name,
            Discontinued = Discontinued,
            Stock = Stock,
            Price = Price,
            Properties = Properties
        };
    }
}