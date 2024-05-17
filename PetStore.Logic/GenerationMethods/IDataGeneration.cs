using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Logic.GenerationMethods;

public interface IDataGeneration
{
    public List<Customer> GetCustomers();
    public List<Employee> GetEmployees();
    public List<Supplier> GetSuppliers();
    public List<Product> GetProducts();
    public List<Invoice> GetInvoices();
    public List<Shipment> GetShipments();
    public List<CurrentStock> GetCurrentStock();
}