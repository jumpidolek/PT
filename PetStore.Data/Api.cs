using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Data;

public abstract class Api
{
    private List<Customer> _customers;
    private List<Employee> _employees;
    private List<Supplier> _suppliers;
    private List<Product> _products;
    private List<Invoice> _invoices;
    private List<CurrentStock> _currentStock;
    private List<Shipment> _shipments;

    public abstract List<Customer> GetCustomers();
    public abstract List<Employee> GetEmployees();
    public abstract List<Supplier> GetSuppliers();
    public abstract List<Product> GetProducts();
    public abstract List<Invoice> GetInvoices();    
    public abstract List<CurrentStock> GetCurrentStock();
    public abstract List<Shipment> GetShipments();
}