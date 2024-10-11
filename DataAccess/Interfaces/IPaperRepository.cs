using DataAccess.Models;

namespace DataAccess.Interfaces;

public interface IPaperRepository
{
    public Paper CreatePaper(Paper paper);

    public List<Paper> GetAllPaper();
    
    public List<Paper> GetAllPapersSortedByPrice();
    public List<Paper> GetAllPapersSortedByStockAmount();
    public List<Paper> GetAllPapersSortedByDiscount();
    
    public List<Paper> SearchPapersByName(string name);



    public Customer CreateCustomer(Customer customer);
    
    public List<Customer> GetAllCustomer();

    public void DeleteCustomer(int id);

    public OrderEntry CreateOrderEntry(OrderEntry orderEntry);
  
    public Paper DeletePaper(int id);
    Paper? GetById(int id);
    void Update(Paper paper); // Make sure this method exists

    public List<Property> GetAllProperties();

    public Property CreateProperty(Property property);

    public Order CreateOrder(Order order);

    public List<Order> GetAllOrders();

    public List<OrderEntry> GetAllOrderEntries();

    public void UpdateOrder(Order order);


}