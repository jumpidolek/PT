using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Logic.GenerationMethods;

public class ManualDataGeneration : IDataGeneration
{
    private readonly List<Customer> _customers = [];
    private readonly List<Employee> _employees = [];
    private readonly List<Supplier> _suppliers = [];
    private readonly List<Product> _products = [];
    private readonly List<Invoice> _invoices = [];
    private readonly List<Shipment> _shipments = [];
    private readonly CurrentStock _currentStock = new();
    
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
    
    public ManualDataGeneration()
    {
        CreateCustomers();
        CreateEmployees();
        CreateSuppliers();
        CreateProducts();
        CreateInvoices();
        CreateShipments();
        CreateCurrentStock();
    }

    public void CreateCustomers()
    {
        List<Customer> customers =
        [
            new Customer
            {
                Id = Guid.Parse("e3b05126-1e59-47ee-80a1-1210e9e0d719"),
                FirstName = "John",
                LastName = "Krasinski",
                Email = "john.krasinki@gmial.com",
                Phone = "000000000",
                Address = "1st Street",
                DateOfBirth = new DateOnly(1980, 1, 1),
                BillingInformation = "Credit Card",
                DeliveryAddress = "1st Street"
            },

            new Customer
            {
                Id = Guid.Parse("a3b05126-1e59-47ee-80a1-1210e9e0d719"),
                FirstName = "Mary",
                LastName = "Sue",
                Email = "mary.sue@gmial.com",
                Phone = "111111111",
                Address = "2nd Street",
                DateOfBirth = new DateOnly(1979, 1, 1),
                BillingInformation = "Pay Pal",
                DeliveryAddress = "2nd Street"
            }
        ];
    }

    public void CreateEmployees()
    {
        List<Employee> employees =
        [
            new Employee
            {
                Id = Guid.Parse("b3b05126-1e59-47ee-80a1-1210e9e0d719"),
                FirstName = "Jim",
                LastName = "Halpert",
                Email = "jimothy.halpert@gmail.com",
                Phone = "222222222",
                Address = "3rd Street",
                Position = "Manager",
                Salary = 100000,
                Department = "Sales",
                HireDate = new DateOnly(2000, 1, 1)
            },
            new Employee
            {
                Id = Guid.Parse("c3b05126-1e59-47ee-80a1-1210e9e0d719"),
                FirstName = "Pam",
                LastName = "Beesly",
                Email = "pamela.beesly@gmail.com",
                Phone = "333333333",
                Address = "4th Street",
                Position = "Assistant",
                Salary = 50000,
                Department = "Sales",
                HireDate = new DateOnly(2001, 1, 1)
            }
        ];
    }

    public void CreateSuppliers()
    {
        List<Supplier> suppliers =
        [
            new Supplier
            {
                Id = Guid.Parse("d3b05126-1e59-47ee-80a1-1210e9e0d719"),
                Name = "PetCo",
                Email = "petco@petco.com",
                Address = "5th Street",
                Phone = "444444444"
            },
            new Supplier
            {
            Id = Guid.Parse("f3b05126-1e59-47ee-80a1-1210e9e0d719"),
            Name = "PetSmart",
            Email = "petsmart@petsmart.com",
            Address = "6th Street",
            Phone = "658961235"
            }
        ];
    }

    public void CreateProducts()
    {
        List<Product> products =
        [
            new Product
            {
                Id = Guid.Parse("g3b05126-1e59-47ee-80a1-1210e9e0d719"),
                Name = "Dog Food",
                Description = "Dry dog food",
                Price = 20,
                Category = Category.Food,
                Brand = "Pedigree",
                Suppliers = [
                    new Supplier{
                        Id = Guid.Parse("d3b05126-1e59-47ee-80a1-1210e9e0d719"),
                        Name = "PetCo",
                        Email = "petco@petco.com",
                        Address = "5th Street",
                        Phone = "444444444"
                    },
                ]
            },
            new Product
            {
                Id = Guid.Parse("h3b05126-1e59-47ee-80a1-1210e9e0d719"),
                Name = "Cat Food",
                Description = "Dry cat food",
                Price = 15,
                Category = Category.Food,
                Brand = "Whiskas",
                Suppliers = [
                    new Supplier{
                        Id = Guid.Parse("d3b05126-1e59-47ee-80a1-1210e9e0d719"),
                        Name = "PetCo",
                        Email = "petco@petco.com",
                        Address = "5th Street",
                        Phone = "444444444"
                    },
                ]
            }
        ];
    }

    public void CreateInvoices()
    {
        List<Invoice> invoices =
        [
            new Invoice
            {
                Id = Guid.Parse("i3b05126-1e59-47ee-80a1-1210e9e0d719"),
                Customer = new Customer
                {
                    Id = Guid.Parse("e3b05126-1e59-47ee-80a1-1210e9e0d719"),
                    FirstName = "John",
                    LastName = "Krasinski",
                    Email = "john.krasinki@gmial.com",
                    Phone = "000000000",
                    Address = "1st Street",
                    DateOfBirth = new DateOnly(1980, 1, 1),
                    BillingInformation = "Credit Card",
                    DeliveryAddress = "1st Street"
                },
                Order = new Order
                {
                    Id = Guid.Parse("j3b05126-1e59-47ee-80a1-1210e9e0d719"),
                    Products = new Dictionary<Product, int>()
                    {
                        {_products.First(x=> x.Id == Guid.Parse("g3b05126-1e59-47ee-80a1-1210e9e0d719")), 5},
                    },
                    PromoCode = "aaa",
                    ShippingCost = 10,
                    Total = 150
                }
            }
        ];
    }

    public void CreateShipments()
    {
        List<Shipment> shipments =
        [
            new Shipment
            {
                Id = Guid.Parse("k3b05126-1e59-47ee-80a1-1210e9e0d719"),
                Products = new Dictionary<Product, int>()
                {
                    { _products.First(x=> x.Id == Guid.Parse("g3b05126-1e59-47ee-80a1-1210e9e0d719")), 5 },
                },
                Supplier = new Supplier(),
            }
        ];
    }

    public void CreateCurrentStock()
    {
        var currentStock = new CurrentStock
        {
            Products = new Dictionary<Product, int>()
            {
                {_products.First(x=> x.Id == Guid.Parse("g3b05126-1e59-47ee-80a1-1210e9e0d719")), 5 },
            },
        };
    }
}