using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess;

public class PaperRepository(PaperContext context) : IPaperRepository
{
    public Paper CreatePaper(Paper paper)
    {
        context.Papers.Add(paper);
        context.SaveChanges();
        return paper;
    }

    public List<Paper> GetAllPaper()
    {
        return context.Papers.ToList();
    }


    
    public Paper DeletePaper(int id)
    {
        
        var paper = context.Papers.FirstOrDefault(p => p.Id == id);

        
        if (paper == null)
        {
            return null;
        }

        context.SaveChanges();
        return paper;
    }

    public Paper? GetById(int id)
    {
        return context.Papers.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Paper paper)
    {
        context.Papers.Update(paper);
        context.SaveChanges();
    }

    public Customer CreateCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
        return customer;
    }

    public List<Customer> GetAllCustomer()
    {
        return context.Customers.ToList();
    }

    public void DeleteCustomer(int id)
    {
        Customer customerToDelete = context.Customers.Single(c => c.Id == id);
        context.Customers.Remove(customerToDelete);
        context.SaveChanges();
    }

    public OrderEntry CreateOrderEntry(OrderEntry orderEntry)
    {
        //orderEntry.Order = context.Orders.Single(o => o.Id == orderEntry.OrderId);
        //orderEntry.Product = context.Papers.Single(p => p.Id == orderEntry.ProductId);
        context.OrderEntries.Add(orderEntry);
        context.SaveChanges();
        return orderEntry;

    }
}