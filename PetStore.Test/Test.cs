using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using PetStore.Logic;
using PetStore.Test.TestDataGeneration;

namespace PetStore.Test;

[TestClass]
public class Test
{
    private Api _logic;
    
    [TestInitialize]
    public void Initialize()
    {
        //_logic = new Api(new ManualDataGeneration());
        _logic = new Api(new BogusDataGeneration());
    }
    
    [TestMethod]
    public void TestAdd()
    {
        Customer c = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
        _logic.AddCustomer(c);
        Assert.IsTrue(_logic.GetCustomers().Contains(c));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestAddDuplicate() 
    {
        Customer c = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
        _logic.AddCustomer(c);
        _logic.AddCustomer(c);
    }

    [TestMethod]
    public void TestRemove()
    {
        Customer c = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
        _logic.AddCustomer(c);
        _logic.RemoveCustomer(c.Id);
        Assert.IsFalse(_logic.GetCustomers().Contains(c));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestRemoveNonExistent()
    {
        _logic.RemoveCustomer(Guid.NewGuid());
    }

    [TestMethod]
    public void TestUpdate()
    {
        Customer c = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
        _logic.AddCustomer(c);
        Customer c1 = new()
        {
            Id = c.Id,
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "987654321",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
        _logic.UpdateCustomer(c1);
        Assert.IsTrue(_logic.GetCustomers().First(x => x.Id == c.Id).Phone.Equals("987654321"));
    }

    [TestMethod]
    public void TestCreateUser()
    {
        Customer c = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main St.",
            BillingInformation = "Credit Card",
            DateOfBirth = new DateOnly(2000, 1, 1),
            DeliveryAddress = "123 Main St."
        };
    }

    [TestMethod]
    public void TestCreateInventory()
    {
        Product p = new()
        {
            Id = Guid.NewGuid(),
            Brand = "exampleBrand",
            Category = Category.Food,
            Description = "exampleDescription",
            Name = "exampleName",
            PetType = PetType.Dog,
            Price = 5,
            Suppliers = []
        };
    }

    [TestMethod]
    public void TestCreateEvent()
    {
        Shipment s = new()
        {
            Id = Guid.NewGuid(),
            Products = [],
            Supplier = new Supplier()
            {
                Id = Guid.NewGuid(),
                Address = "example address",
                Email = "sup@email.com",
                Phone = "123456789",
                Name = "Sup"
            }
        };
    }
}