using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IPaperRepository
{
    public Paper CreatePaper(Paper paper);

    public List<Paper> GetAllPaper();


    public Customer CreateCustomer(Customer customer);
    
    public List<Customer> GetAllCustomer();

    public void DeleteCustomer(int id);

    public OrderEntry CreateOrderEntry(OrderEntry orderEntry);
  
    public Paper DeletePaper(int id);
    Paper? GetById(int id);
    void Update(Paper paper); // Make sure this method exists

    public Order CreateOrder(Order order);

}