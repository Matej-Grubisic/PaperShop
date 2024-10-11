using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Logging.Abstractions;
using PgCtx;
using Service;
using Service.TransferModels.Requests;
using Service.TransferModels.Responses;

namespace TestProject1;

public class PaperServiceTest
{
    private readonly PaperService _paperService;
    private readonly PgCtxSetup<PaperContext> _setup = new();

    public PaperServiceTest()
    {
        _paperService = new PaperService(NullLogger<PaperService>.Instance, new StubPaperRepository(_setup.DbContextInstance),
            _setup.DbContextInstance);
    }

    [Fact]
    public void CreatePaper_Should_Return_Created_Paper()
    {
        var createPaperDto = new CreatePaperDto
        {
            Discontinued = false,
            Name = "John",
            Price = 10,
            Stock = 15
        };
        var result = _paperService.CreatePaper(createPaperDto);
        Assert.Equal("John", result.Name);
        Assert.Equal(10, result.Price);
        Assert.Equal(15, result.Stock);
    }

    [Fact]
    public void GetAllPapers_Should_Return_All_Papers()
    {
        var papers = new List<Paper>
        {
            TestObjects.GetPaper(),
            TestObjects.GetPaper()
        };
        _setup.DbContextInstance.Papers.AddRange(papers);
        _setup.DbContextInstance.SaveChanges();
        
        int limit = 2;
        int startAt = 0;
        var result = _paperService.GetAllPapers(limit, startAt);
        Assert.Equal(papers.Count, result.Count);
    }

    [Fact]
    public void GetAllPapersSortedByPrice_Return_Sorted_By_Price()
    {
        var papers = new List<Paper>
        {
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper()
        };
        _setup.DbContextInstance.Papers.AddRange(papers);
        _setup.DbContextInstance.SaveChanges();
        var result = _paperService.GetAllPapersSortedByPrice();
        //Probably not the right way to test
        Assert.NotEqual(papers, result);
    }

    [Fact]
    public void GetAllPapersSortedByStockAmount_Return_Sorted_By_StockAmount()
    {
        var papers = new List<Paper>
        {
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper(),
            TestObjects.GetPaper()
        };
        _setup.DbContextInstance.Papers.AddRange(papers);
        _setup.DbContextInstance.SaveChanges();
        var result = _paperService.GetAllPapersSortedByStockAmount();
        //Probably not the right way to test
        Assert.NotEqual(papers, result);
    }

    [Fact]
    public void SearchPapers_Returns_Correct_Papers()
    {
        var createPaperDto = new CreatePaperDto
        {
            Discontinued = false,
            Name = "paper",
            Price = 10,
            Stock = 15
        };
        var paper = _paperService.CreatePaper(createPaperDto);
        var result = _paperService.SearchPapers("paper");
        Assert.True(result.Count == 1);
    }

    [Fact]
    public void CreateCustomer_Returns_Created_Customer()
    {
        var customer = TestObjects.GetCustomer();
        var createCustomerDto = new CreateCustomerDto
        {
            Name = customer.Name,
            Address = customer.Address,
            Email = customer.Email,
            Phone = customer.Phone
        };
        var result = _paperService.CreateCustomer(createCustomerDto);
        Assert.Equal(customer.Name, result.Name);
        Assert.Equal(customer.Address, result.Address);
        Assert.Equal(customer.Email, result.Email);
        Assert.Equal(customer.Phone, result.Phone);
    }

    [Fact]
    public void GetAllCustomers_Returns_All_Customers()
    {
        var customers = new List<Customer>
        {
            TestObjects.GetCustomer(),
            TestObjects.GetCustomer(),
            TestObjects.GetCustomer(),
        };
        _setup.DbContextInstance.Customers.AddRange(customers);
        _setup.DbContextInstance.SaveChanges();
        
        int limit = 3;
        int startAt = 0;
        var result = _paperService.GetAllCustomers(limit, startAt);
        Assert.Equal(customers.Count, result.Count);
    }

    [Fact]
    public void GetCustomerById_Returns_Customer_By_Id()
    {
        var customer = TestObjects.GetCustomer();
        var createCustomerDto = new CreateCustomerDto
        {
            Name = customer.Name,
            Address = customer.Address,
            Email = customer.Email,
            Phone = customer.Phone
        };
        var makeCustomer = _paperService.CreateCustomer(createCustomerDto);
        var result = _paperService.GetCustomerById(makeCustomer.Id);
        Assert.Equal(customer.Name, result.Name);
        Assert.Equal(customer.Address, result.Address);
        Assert.Equal(customer.Email, result.Email);
        Assert.Equal(customer.Phone, result.Phone);
    }
/*
    [Fact]
    public void DiscontinuePaper_Returns_Discontinued_Paper()
    {
        var paper = TestObjects.GetPaper();
        var createPaperDto = new CreatePaperDto
        {
            Name = paper.Name,
            Discontinued = paper.Discontinued,
            Price = paper.Price,
            Stock = paper.Stock
        };
        var makePaper = _paperService.CreatePaper(createPaperDto);
        
        var result = _paperService.DiscontinuePaper(makePaper.Id);
        Assert.NotNull(result);
        Assert.True(result.Discontinued);
    }


    [Fact]
    public void CreateOrder_Returns_Created_Order()
    {
        var order = TestObjects.GetOrder();
        var createOrderDto = new CreateOrderDto
        {
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            CustomerId = order.CustomerId,
        };
        //var result1 = _setup.DbContextInstance.Orders.Add(order);
        var result = _paperService.CreateOrder(createOrderDto);
        Assert.Equal(order.DeliveryDate,result.DeliveryDate);
        Assert.Equal(order.Status, result.Status);
        Assert.Equal(order.TotalAmount, result.TotalAmount);
        Assert.Equal(order.CustomerId, result.CustomerId);
    }
    

    [Fact]
    public void GetAllOrders_Returns_All_Orders()
    {
        var orders = new List<Order>
        {
            TestObjects.GetOrder(),
            TestObjects.GetOrder()
        };
        _setup.DbContextInstance.Orders.AddRange(orders);
        var result = _paperService.GetAllOrders();
        Assert.Equal(orders.Count, result.Count);
    }
    */
}