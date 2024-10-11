using System.Collections;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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

    
    public List<Paper> GetAllPapersSortedByPrice()
    {
        return context.Papers.OrderBy(p => p.Price).ToList();
    }
    public List<Paper> GetAllPapersSortedByStockAmount()
    {
        return context.Papers.OrderBy(p => p.Stock).ToList();
    }
    public List<Paper> GetAllPapersSortedByDiscount()
    {
        return context.Papers.OrderBy(p => p.Discontinued).ToList();
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
    
    public List<Paper> SearchPapersByName(string name)
    {
        return context.Papers
            .Where(p => p.Name.Contains(name))
            .Include(p => p.Properties) 
            .ToList();
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
    public List<Property> GetAllProperties()
    {
        return context.Properties.ToList();
    }

    public Property CreateProperty(Property property)
    {
        context.Properties.Add(property);
        context.SaveChanges();
        return property;
    }
    
    public List<OrderEntry> GetAllOrderEntries()
    {
        return context.OrderEntries.ToList();
    }

    public Order CreateOrder(Order order)
    {
        context.OrderEntries.AddRange(order.OrderEntries);
        context.Orders.Add(order);
        List<OrderEntry> oe = order.OrderEntries.ToList();
        oe.ForEach(orderEntry => context.Papers.Where(p => p.Id == orderEntry.ProductId).FirstOrDefault().Stock -= orderEntry.Quantity);
        context.SaveChanges();
        return order;
    }
    
    public List<Order> GetAllOrders()
    {
        return context.Orders.ToList();
    }
    
    public void UpdateOrder(Order order)
    {
        context.Orders.Update(order);
        context.SaveChanges();
    }
    
    
}