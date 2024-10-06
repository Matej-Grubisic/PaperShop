using DataAccess.Models;

namespace Service.TransferModels.Responses;

public class PropertyDto
{
    public PropertyDto FromEntity(Property property)
    {
        return new PropertyDto()
        {
            Id = property.Id,
            PropertyName = property.PropertyName,
            
        };
    }
    public int Id { get; set; }
    
    public string PropertyName { get; set; } = null!;
}