using PetStore.Model.Models.Events;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Users;

namespace PetStore.ViewModel.Repository;

public class DataRepository : IDataRepository
{
    public List<Customer> Customers { get; set; }
    public List<Supplier> Suppliers { get; }
    public List<Product> Products { get; }
    public List<CurrentStock> CurrentStocks { get; }
    public List<Order> Orders { get; }
    public List<Invoice> Invoices { get; }
    public List<Shipment> Shipments { get; }
    
    private readonly string _connectionString = "";

    public DataRepository(string connectionString)
    {
        Customers = Customer.GetAll(connectionString);
        Suppliers = Supplier.GetAll(connectionString);
        Products = Product.GetAll(connectionString);
        CurrentStocks = CurrentStock.GetAll(connectionString);
        Orders = Order.GetAll(connectionString);
        Invoices = Invoice.GetAll(connectionString);
        Shipments = Shipment.GetAll(connectionString);
        _connectionString = connectionString;
    }
    public DataRepository(List<Customer> customers, List<Supplier> suppliers, List<Product> products, List<CurrentStock> currentStocks, List<Order> orders, List<Invoice> invoices, List<Shipment> shipments)
    {
        Customers = customers;
        Suppliers = suppliers;
        Products = products;
        CurrentStocks = currentStocks;
        Orders = orders;
        Invoices = invoices;
        Shipments = shipments;
    }
    public DataRepository()
    {
        Customers = [];
        Suppliers = [];
        Products = [];
        CurrentStocks = [];
        Orders = [];
        Invoices = [];
        Shipments = [];
    }
    
    public string GetConnectionString()
    {
        return _connectionString;
    }

}