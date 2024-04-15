using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Logic.GenerationMethods;

public interface IDataGeneration
{
    public void CreateCustomers();
    public void CreateEmployees();
    public void CreateSuppliers();
    public void CreateProducts();
    public void CreateInvoices();
    public void CreateShipments();
    public void CreateCurrentStock();
    
    public List<Customer> GetCustomers();
    public List<Employee> GetEmployees();
    public List<Supplier> GetSuppliers();
    public List<Product> GetProducts();
    public List<Invoice> GetInvoices();
    public List<Shipment> GetShipments();
    public CurrentStock GetCurrentStock();
}