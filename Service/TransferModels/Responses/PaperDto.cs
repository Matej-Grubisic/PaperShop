using DataAccess.Models;

namespace Service.TransferModels.Responses;

public class PaperDto
{
    public PaperDto FromEntity(Paper paper)
    {
        
        return new PaperDto
        {
            Id = paper.Id,
            Name = paper.Name,
            Discontinued = paper.Discontinued,
            Stock = paper.Stock,
            Price = paper.Price,
            Properties = paper.Properties,
        };
    }
    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Discontinued { get; set; }

    public int Stock { get; set; }

    public double Price { get; set; }

    public ICollection<Property> Properties { get; set; }
}