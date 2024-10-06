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

    public OrderDto CreateOrder(CreateOrderDto createOrderDto);

    public List<Order> GetAllOrders();

    public List<OrderEntry> GetAllOrderEntries();
    
    public Order UpdateStatus(string status, int orderId);

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

    public List<OrderEntry> GetAllOrderEntries()
    {
        return context.OrderEntries.ToList();
    }

    public OrderDto CreateOrder(CreateOrderDto createOrderDto)
    {
        var order = createOrderDto.ToOrder();
        Order newOrder = paperRepository.CreateOrder(order);
        return new OrderDto().FromEntity(newOrder);
    }

    public List<Order> GetAllOrders()
    {
        return context.Orders.OrderBy(o => o.Id).ToList();
    }

    public Order UpdateStatus(string status, int orderId)
    {
        var order = context.Orders.Where(o => o.Id == orderId).FirstOrDefault(); 
        if (order == null) return null;
        order.Status = status;
        paperRepository.UpdateOrder(order);
        return order;
    }
}