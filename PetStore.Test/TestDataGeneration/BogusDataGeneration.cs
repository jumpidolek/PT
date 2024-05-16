using Bogus;
using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using PetStore.Logic.GenerationMethods;

namespace PetStore.Test.TestDataGeneration;

public class BogusDataGeneration : IDataGeneration
{
    private List<Customer> _customers = [];
    private List<Employee> _employees = [];
    private List<Supplier> _suppliers = [];
    private List<Product> _products = [];
    private List<Invoice> _invoices = [];
    private List<Shipment> _shipments = [];
    private CurrentStock _currentStock = new();
    
    public BogusDataGeneration()
    {
        CreateCustomers();
        CreateEmployees();
        CreateSuppliers();
        CreateProducts();
        CreateInvoices();
        CreateShipments();
        CreateCurrentStock();
    }
    
    public List<Customer> GetCustomers()
    {
        return _customers;
    }

    public List<Employee> GetEmployees()
    {
        return _employees;
    }

    public List<Supplier> GetSuppliers()
    {
        return _suppliers;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public List<Invoice> GetInvoices()
    {
        return _invoices;
    }

    public List<Shipment> GetShipments()
    {
        return _shipments;
    }

    public CurrentStock GetCurrentStock()
    {
        return _currentStock;
    }
    
    private readonly string[] _billingInformation = new[] {"Credit Card", "PayPal", "Bank Transfer", "Cash", "Klarna"};

    private void CreateCustomers()
    {
        var customers = new Faker<Customer>()
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(c => c.BillingInformation, f => f.PickRandom(_billingInformation))
            .RuleFor(c => c.DateOfBirth, f => f.Date.Past(60, DateTime.Now.AddYears(-20)))
            .RuleFor(c => c.Address , f => f.Address.FullAddress())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
            .Generate(5);
        _customers = customers;
    }

    private void CreateEmployees()
    {
        var employees = new Faker<Employee>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Email, f => f.Person.Email)
            .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Position, f => f.Name.JobTitle())
            .RuleFor(e => e.Salary, f => f.Random.Float(10000F, 100000F))
            .RuleFor(e => e.Department, f => f.Commerce.Department())
            .RuleFor(e => e.HireDate, f => f.Date.Past())
            .Generate(5);
        _employees = employees;
    }

    private void CreateSuppliers()
    {
        var suppliers = new Faker<Supplier>()
            .RuleFor(s => s.Id, _ => Guid.NewGuid())
            .RuleFor(s => s.Name, f => f.Company.CompanyName())
            .RuleFor(s => s.Email, f => f.Person.Email)
            .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(s => s.Address, f => f.Address.FullAddress())
            .Generate(5);
        _suppliers = suppliers;
    }

    private void CreateProducts()
    {
        var products = new Faker<Product>()
            .RuleFor(p => p.Id, _ => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Brand, f => f.Company.CompanyName())
            .RuleFor(p => p.Category, f => f.PickRandom<Category>())
            .RuleFor(p => p.Suppliers, f => GetSuppliers())
            .RuleFor(p => p.Price, f => f.Random.Float(1, 1000))
            .RuleFor(p => p.PetType, f => f.PickRandom<PetType>())
            .Generate(5);
        _products = products;
    }

    private void CreateInvoices()
    {
        var invoices = new Faker<Invoice>()
            .RuleFor(o => o.Id, _ => Guid.NewGuid())
            .RuleFor(o => o.Customer, f => GetCustomers().First())
            .RuleFor(o => o.Order, f => 
                new Faker<Order>()
                    .RuleFor(o => o.Id, _ => Guid.NewGuid())
                    .RuleFor(o => o.Products, _ => new Dictionary<Product, int> {{GetProducts()[1], 1}})
                    .RuleFor(o => o.PromoCode, f => f.Random.String2(5))
                    .RuleFor(o => o.ShippingCost, f => f.Random.Float(5, 20))
                    .RuleFor(o => o.Total, f => f.Random.Float(50, 100))
                    .Generate()
                )
            .Generate(5);
        _invoices = invoices;
    }

    private void CreateShipments()
    {
        var shipments = new Faker<Shipment>()
            .RuleFor(s => s.Id, _ => Guid.NewGuid())
            .RuleFor(s => s.Products, f => new Dictionary<Product, int> {{GetProducts()[1], 1}})
            .RuleFor(s => s.Supplier, f => GetSuppliers().First())
            .Generate(5);
        _shipments = shipments;
    }

    private void CreateCurrentStock()
    {
        var currentStock = new Faker<CurrentStock>()
            .RuleFor(s => s.Products, f => new Dictionary<Product, int> {{GetProducts()[1], 1}})
            .Generate();
        _currentStock = currentStock;
    }
}