using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using Service.TransferModels.Requests;
using Service.TransferModels.Responses;

namespace Service;

public interface IPaperService
{
    public PaperDto CreatePaper(CreatePaperDto createPaperDto);

    public List<Paper> GetAllPapers(int limit, int startAt);
  
    public Paper DeletePaper(int id);
    
    Paper? DiscontinuePaper(int id);


    public CustomerDto CreateCustomer(CreateCustomerDto createCustomerDto);

    public List<Customer> GetAllCustomers(int limit, int startAt);

    public CustomerDto GetCustomerById(int id);

    public void DeleteCustomer(int id);
    
    public OrderEntryDto CreateOrderEntry(CreateOrderEntryDto createOrderEntryDto);

    public List<Property> GetAllProperties();

    public PropertyDto CreateProperty(CreatePropertyDto createCreateProperty);


}

public class PaperService(IPaperRepository paperRepository, PaperContext context): IPaperService
{
    public PaperDto CreatePaper(CreatePaperDto createPaperDto)
    {
        //createPaperValidator.ValidateAndThrow(createPaperDto);
        var paper = createPaperDto.ToPaper();
        foreach (var paperProperty in paper.Properties)
        {
            context.Properties.Attach(paperProperty);
        }
        
        Paper newPaper = paperRepository.CreatePaper(paper);
        return new PaperDto().FromEntity(newPaper);
    }

    public List<Paper> GetAllPapers(int limit, int startAt)
    {
        return context.Papers.OrderBy(p => p.Id).Skip(startAt).Take(limit).ToList();
    }


    public CustomerDto CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        var customer = createCustomerDto.ToCustomer();
        Customer newCustomer = paperRepository.CreateCustomer(customer);
        return new CustomerDto().FromEntity(newCustomer);
    }

    public List<Customer> GetAllCustomers(int limit, int startAt)
    {
        return context.Customers.OrderBy(c => c.Id).Skip(startAt).Take(limit).ToList();
    }

    public CustomerDto GetCustomerById(int id)
    {
        var customer = context.Customers.Single(c => c.Id == id);
        return new CustomerDto().FromEntity(customer);
    }

    public void DeleteCustomer(int id)
    {
        paperRepository.DeleteCustomer(id);
    }

    public OrderEntryDto CreateOrderEntry(CreateOrderEntryDto createOrderEntryDto)
    {
        var orderEntry = createOrderEntryDto.ToOrderEntry();
        OrderEntry newOrderEntry = paperRepository.CreateOrderEntry(orderEntry);
        return new OrderEntryDto().FromEntity(newOrderEntry);
    }


    public Paper DeletePaper(int id)
    {
        var paper = paperRepository.DeletePaper(id);
        
        if (paper == null)
        {
            return null;
        }
        context.SaveChanges();
        return paper;
    }
    public Paper? DiscontinuePaper(int id)
    {
        var paper = paperRepository.GetById(id);
        if (paper == null) return null;

        paper.Discontinued = true;
        paperRepository.Update(paper);
        return paper;
    }
    
    public List<Property> GetAllProperties()
    {
        return context.Properties.ToList();
    }

    public PropertyDto CreateProperty(CreatePropertyDto createCreateProperty)
    {
        var property = createCreateProperty.ToProperty();
        Property newProperty = paperRepository.CreateProperty(property);
        return new PropertyDto().FromEntity(newProperty);
    }
}