using DataAccess.Models;

namespace Service.TransferModels.Requests;

public class CreatePropertyDto
{
    public string PropertyName { get; set; } = null!;
    
    public Property ToProperty()
    {
        return new Property()
        {
            PropertyName = PropertyName
        };
    }
}