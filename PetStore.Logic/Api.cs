using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using PetStore.Logic.GenerationMethods;

namespace PetStore.Logic;

public class Api : Data.Api
{
    public Api(IDataGeneration dataGeneration)
    {
        _customers = dataGeneration.GetCustomers();
        _employees = dataGeneration.GetEmployees();
        _suppliers = dataGeneration.GetSuppliers();
        _products = dataGeneration.GetProducts();
        _invoices = dataGeneration.GetInvoices();
        _shipments = dataGeneration.GetShipments();
        _currentStock = dataGeneration.GetCurrentStock();
    }

    public override List<Customer> GetCustomers()
    {
        return _customers;
    }
    public override List<Employee> GetEmployees()
    {
        return _employees;
    }
    public override List<Supplier> GetSuppliers()
    {
        return _suppliers;
    }
    public override List<Product> GetProducts()
    {
        return _products;
    }
    public override List<Invoice> GetInvoices()
    {
        return _invoices;
    }
    public override CurrentStock GetCurrentStock()
    {
        return _currentStock;
    }
    public override List<Shipment> GetShipments()
    {
        return _shipments;
    }
    
    public override void AddCustomer(Customer customer)
    {
        if (_customers.Exists(x => x.Id == customer.Id)) 
            throw new ArgumentException("Customer already exists");
        _customers.Add(customer);
    }
    public override void AddEmployee(Employee employee)
    {
        if (_employees.Exists(x => x.Id == employee.Id)) 
            throw new ArgumentException("Employee already exists");
        _employees.Add(employee);
    }
    public override void AddSupplier(Supplier supplier)
    {
        if (_suppliers.Exists(x => x.Id == supplier.Id)) 
            throw new ArgumentException("Supplier already exists");
        _suppliers.Add(supplier);
    }
    public override void AddProduct(Product product)
    {
        if (_products.Exists(x => x.Id == product.Id))
            throw new ArgumentException("Product already exists");
        _products.Add(product);
        _currentStock.Products.Add(product, 0);
    }
    public override void AddInvoice(Invoice invoice)
    {
        if (_invoices.Exists(x => x.Id == invoice.Id)) 
            throw new ArgumentException("Invoice already exists");
        _invoices.Add(invoice);
        foreach (var product in invoice.Order.Products)
        {
            _currentStock.Products[product.Key] -= product.Value;
        }
    }
    public override void AddShipment(Shipment shipment)
    {
        if (_shipments.Exists(x => x.Id == shipment.Id)) 
            throw new ArgumentException("Shipment already exists");
        _shipments.Add(shipment);
        foreach (var product in shipment.Products)
        {
            _currentStock.Products[product.Key] += product.Value;
        }
    }

    public override void RemoveCustomer(Guid customerId)
    {
        if (!_customers.Exists(x => x.Id == customerId)) 
            throw new ArgumentException("Customer not found");
        _customers.RemoveAt(_customers.FindIndex(x => x.Id == customerId));
    }
    public override void RemoveEmployee(Guid employeeId)
    {
        if (!_employees.Exists(x => x.Id == employeeId)) 
            throw new ArgumentException("Employee not found");
        _employees.RemoveAt(_employees.FindIndex(x => x.Id == employeeId));
    }
    public override void RemoveSupplier(Guid supplierId)
    {
        if (!_suppliers.Exists(x => x.Id == supplierId))
            throw new ArgumentException("Supplier not found");
        _suppliers.RemoveAt(_suppliers.FindIndex(x => x.Id == supplierId));
    }
    public override void RemoveProduct(Guid productId)
    {
        if (!_products.Exists(x => x.Id == productId))
            throw new ArgumentException("Product not found");
        _products.RemoveAt(_products.FindIndex(x => x.Id == productId));
    }
    
    public override void UpdateCustomer(Customer customer)
    {
        if (!_customers.Exists(x => x.Id == customer.Id)) 
            throw new ArgumentException("Customer not found");
        _customers[_customers.FindIndex(x => x.Id == customer.Id)] = customer;
    }
    public override void UpdateEmployee(Employee employee)
    {
        if (!_employees.Exists(x => x.Id == employee.Id)) 
            throw new ArgumentException("Employee not found");
        _employees[_employees.FindIndex(x => x.Id == employee.Id)] = employee;
    }
    public override void UpdateSupplier(Supplier supplier)
    {
        if (!_suppliers.Exists(x => x.Id == supplier.Id)) 
            throw new ArgumentException("Supplier not found");
        _suppliers[_suppliers.FindIndex(x => x.Id == supplier.Id)] = supplier;
    }
    public override void UpdateProduct(Product product)
    {
        if (!_products.Exists(x => x.Id == product.Id)) 
            throw new ArgumentException("Product not found");
        _products[_products.FindIndex(x => x.Id == product.Id)] = product;
    }
}