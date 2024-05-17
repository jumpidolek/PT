using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Logic.GenerationMethods;

public class EmptyDataGeneration : IDataGeneration
{

    public List<Customer> GetCustomers()
    {
        return [];
    }

    public List<Employee> GetEmployees()
    {
        return [];
    }

    public List<Supplier> GetSuppliers()
    {
        return [];
    }

    public List<Product> GetProducts()
    {
        return [];
    }

    public List<Invoice> GetInvoices()
    {
        return [];
    }

    public List<Shipment> GetShipments()
    {
        return [];
    }

    public List<CurrentStock> GetCurrentStock()
    {
        return [];
    }
}