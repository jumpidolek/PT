using PetStore.Service.Implementation;
using PetStore.Service.API;

namespace ServiceTest;

[TestClass]
public class Tests
{
    private string ConnectionString;

    [TestInitialize]
    public void TestInitialize()
    {
        string _DBRelativePath = @"Instrumentation\PetStoreServiceTest.mdf";
        string _TestingWorkingFolder = Environment.CurrentDirectory;
        string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
        ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True;";
    }
    
    [TestMethod]
    public void TestGetCustomer()
    {
        ICustomerService c = CustomerService.GetCustomer(Guid.Parse("2f3e6d94-f266-4886-b0be-d4c951288efd"), ConnectionString);
        Assert.AreEqual("Anne", c.FirstName);
        Assert.AreEqual("Kolanko", c.LastName);
        Assert.AreEqual("Long Street", c.Address);
    }
    
    [TestMethod]
    public void TestGetSupplier()
    {
        ISupplierService s = SupplierService.GetSupplier(Guid.Parse("1e5e96ac-600d-4b05-be9a-85db4789a945"), ConnectionString);
        Assert.AreEqual("Big Pet", s.Name);
        Assert.AreEqual("Field Street", s.Address);
    }
    
    [TestMethod]
    public void TestGetAllCustomers()
    {
        List<ICustomerService> c = CustomerService.GetCustomers(ConnectionString);
        Assert.AreEqual(1, c.Count);
    }
    
    [TestMethod]
    public void TestGetAllSuppliers()
    {
        List<ISupplierService> s = SupplierService.GetSuppliers(ConnectionString);
        Assert.AreEqual(1, s.Count);
    }
}