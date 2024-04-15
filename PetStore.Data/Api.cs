using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Data;

public abstract class Api
{
    protected List<Customer> _customers;
    protected List<Employee> _employees;
    protected List<Supplier> _suppliers;
    protected List<Product> _products;
    protected List<Invoice> _invoices;
    protected List<CurrentStock> _currentStock;
    protected List<Shipment> _shipments;

    public abstract List<Customer> GetCustomers();
    public abstract List<Employee> GetEmployees();
    public abstract List<Supplier> GetSuppliers();
    public abstract List<Product> GetProducts();
    public abstract List<Invoice> GetInvoices();    
    public abstract List<CurrentStock> GetCurrentStock();
    public abstract List<Shipment> GetShipments();
}