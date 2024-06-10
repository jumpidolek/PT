using PetStore.Model.Models.Users;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Events;

namespace ModelTest;

[TestClass]
public class Tests
{
    private string ConnectionString;

    [TestInitialize]
    public void TestInitialize()
    {
        string _DBRelativePath = @"Instrumentation\PetStoreModelTest.mdf";
        string _TestingWorkingFolder = Environment.CurrentDirectory;
        string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
        ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True;";
    }
    
    [TestMethod]
    public void TestGetCustomer()
    {
        Customer c = Customer.Get(Guid.Parse("d149be18-c2e0-4711-bbf9-0c43e61ad3d9"), ConnectionString);
        Assert.AreEqual("Anne", c.FirstName);
    }
    
    [TestMethod]
    public void TestGetCustomers()
    {
        List<Customer> c = Customer.GetAll(ConnectionString);
        Assert.AreEqual(1, c.Count);
    }
    
    [TestMethod]
    public void TestGetSupplier()
    {
        Supplier s = Supplier.Get(Guid.Parse("f765c2ca-db0a-4634-ac0a-42400032d341"), ConnectionString);
        Assert.AreEqual("Happy Pet", s.Name);
    }
    
    [TestMethod]
    public void TestGetSuppliers()
    {
        List<Supplier> s = Supplier.GetAll(ConnectionString);
        Assert.AreEqual(1, s.Count);
    }
}