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

    public CustomerDto CreateCustomer(CreateCustomerDto createCustomerDto);

    public List<Customer> GetAllCustomers(int limit, int startAt);

    public CustomerDto GetCustomerById(int id);

    public void DeleteCustomer(int id);
    
    public OrderEntryDto CreateOrderEntry(CreateOrderEntryDto createOrderEntryDto);

}

public class PaperService(IPaperRepository paperRepository, PaperContext context): IPaperService
{
    public PaperDto CreatePaper(CreatePaperDto createPaperDto)
    {
        //createPaperValidator.ValidateAndThrow(createPaperDto);
        var paper = createPaperDto.ToPaper();
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

}