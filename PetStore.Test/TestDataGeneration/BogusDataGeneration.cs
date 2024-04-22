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
    
    private string[] names = new[] {"Anna", "Hanna", "Joanna", "Barbara", "Karolina"};
    private string[] lastNames = new[] {"Nowak", "Kowalski", "Wiśniewski", "Wójcik", "Kowalczyk"};
    private string[] emails = new[] {"gosia@gmail.com", "franek@yahoo.com", "barok@outlook.com", "arbuz@protonmail.com", "kieszonkowcy@aol.com"};
    private string[] phoneNumbers = new[] {"123456789", "987654321", "456123789", "789456123", "321654987"};
    private string[] billingInformation = new[] {"Credit Card", "PayPal", "Bank Transfer", "Cash", "Klarna"};

    private void CreateCustomers()
    {
        var customers = new Faker<Customer>()
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.PickRandom(names))
            .RuleFor(c => c.LastName, f => f.PickRandom(lastNames))
            .RuleFor(c => c.Email, f => f.PickRandom(emails))
            .RuleFor(c => c.Phone, f => f.PickRandom(phoneNumbers))
            .RuleFor(c => c.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(c => c.BillingInformation, f => f.PickRandom(billingInformation))
            .RuleFor(c => c.DateOfBirth, _ => DateOnly.FromDateTime(DateTime.Now.AddYears(-20)))
            .Generate(5);
        _customers = customers;
    }
    
    private string[] positions = new[] {"Manager", "Salesman", "Accountant", "HR", "IT"};
    private double[] salaries = new[] {5000.0, 4000, 3000, 2000, 1000};
    private string[] departments = new[] {"Sales", "Marketing", "Finance", "IT", "HR"};

    private void CreateEmployees()
    {
        var employees = new Faker<Employee>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.FirstName, f => f.PickRandom(names))
            .RuleFor(e => e.LastName, f => f.PickRandom(lastNames))
            .RuleFor(e => e.Email, f => f.PickRandom(emails))
            .RuleFor(e => e.Phone, f => f.PickRandom(phoneNumbers))
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Position, f => f.PickRandom(positions))
            .RuleFor(e => e.Salary, f => f.PickRandom(salaries))
            .RuleFor(e => e.Department, f => f.PickRandom(departments))
            .RuleFor(e => e.HireDate, _ => DateOnly.FromDateTime(DateTime.Now.AddYears(-5)))
            .Generate(5);
        _employees = employees;
    }
    
    private string[] _companyNames = new[] {"PetShop", "PetWorld", "PetLand", "PetLovers", "PetParadise"};

    private void CreateSuppliers()
    {
        var suppliers = new Faker<Supplier>()
            .RuleFor(s => s.Id, _ => Guid.NewGuid())
            .RuleFor(s => s.Name, f => f.PickRandom(_companyNames))
            .RuleFor(s => s.Email, f => f.PickRandom(emails))
            .RuleFor(s => s.Phone, f => f.PickRandom(phoneNumbers))
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