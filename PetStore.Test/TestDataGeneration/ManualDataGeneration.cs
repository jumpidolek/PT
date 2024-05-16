using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using PetStore.Logic.GenerationMethods;

namespace PetStore.Test.TestDataGeneration;

public class ManualDataGeneration : IDataGeneration
{
    private List<Customer> _customers = [];
    private List<Employee> _employees = [];
    private List<Supplier> _suppliers = [];
    private List<Product> _products = [];
    private List<Invoice> _invoices = [];
    private List<Shipment> _shipments = [];
    private CurrentStock _currentStock = new();
    
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

    private void CreateCustomers()
    {
        List<Customer> customers =
        [
            new Customer
            {
                Id = Guid.Parse("99ff696e-a11c-4064-89c3-5abe881f8a4b"),
                FirstName = "John",
                LastName = "Krasinski",
                Email = "john.krasinki@gmial.com",
                Phone = "000000000",
                Address = "1st Street",
                DateOfBirth = new DateTime(1980, 1, 1),
                BillingInformation = "Credit Card",
                DeliveryAddress = "1st Street"
            },

            new Customer
            {
                Id = Guid.Parse("fbdce505-f699-4741-a69f-c22d1df89ca0"),
                FirstName = "Mary",
                LastName = "Sue",
                Email = "mary.sue@gmial.com",
                Phone = "111111111",
                Address = "2nd Street",
                DateOfBirth = new DateTime(1979, 1, 1),
                BillingInformation = "Pay Pal",
                DeliveryAddress = "2nd Street"
            }
        ];
        _customers = customers;
    }

    private void CreateEmployees()
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
                HireDate = new DateTime(2000, 1, 1)
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
                HireDate = new DateTime(2001, 1, 1)
            }
        ];
        _employees = employees;
    }

    private void CreateSuppliers()
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
        _suppliers = suppliers;
    }

    private void CreateProducts()
    {
        List<Product> products =
        [
            new Product
            {
                Id = new Guid("209dbc6e-ed30-424e-91d2-632863233d2f"),
                Name = "Dog Food",
                Description = "Dry dog food",
                Price = 20,
                Category = Category.Food,
                Brand = "Pedigree",
                Suppliers = [
                    _suppliers.First(x => x.Id == Guid.Parse("d3b05126-1e59-47ee-80a1-1210e9e0d719"))
                ]
            },
            new Product
            {
                Id = Guid.Parse("e1b05126-1e59-47ee-80a1-1210e9e0d719"),
                Name = "Cat Food",
                Description = "Dry cat food",
                Price = 15,
                Category = Category.Food,
                Brand = "Whiskas",
                Suppliers = [
                    _suppliers.First(x => x.Id == Guid.Parse("d3b05126-1e59-47ee-80a1-1210e9e0d719"))
                ]
            }
        ];
        _products = products;
    }

    private void CreateInvoices()
    {
        List<Invoice> invoices =
        [
            new Invoice
            {
                Id = Guid.Parse("e2b05126-1e59-47ee-80a1-1210e9e0d719"),
                Customer = _customers.First(x => x.Id == Guid.Parse("99ff696e-a11c-4064-89c3-5abe881f8a4b")),
                Order = new Order
                {
                    Id = Guid.Parse("e4b05126-1e59-47ee-80a1-1210e9e0d719"),
                    Products = new Dictionary<Product, int>()
                    {
                        { _products.First(x=> x.Id == Guid.Parse("209dbc6e-ed30-424e-91d2-632863233d2f")), 5 },
                    },
                    PromoCode = "aaa",
                    ShippingCost = 10,
                    Total = 150
                }
            }
        ];
        _invoices = invoices;
    }

    private void CreateShipments()
    {
        List<Shipment> shipments =
        [
            new Shipment
            {
                Id = Guid.Parse("e5b05126-1e59-47ee-80a1-1210e9e0d719"),
                Products = new Dictionary<Product, int>()
                {
                    { _products.First(x=> x.Id == Guid.Parse("209dbc6e-ed30-424e-91d2-632863233d2f")), 5 },
                },
                Supplier = new Supplier(),
            }
        ];
        _shipments = shipments;
    }

    private void CreateCurrentStock()
    {
        var currentStock = new CurrentStock
        {
            Products = new Dictionary<Product, int>()
            {
                { _products.First(x=> x.Id == Guid.Parse("209dbc6e-ed30-424e-91d2-632863233d2f")), 5 },
            },
        };
        _currentStock = currentStock;
    }
}