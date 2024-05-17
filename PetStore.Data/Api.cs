using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using System;
using System.Collections.Generic;

namespace PetStore.Data
{
    public abstract class Api
    {
        protected List<Customer> _customers = new List<Customer>();
        protected List<Employee> _employees = new List<Employee>();
        protected List<Supplier> _suppliers = new List<Supplier>();
        protected List<Product> _products = new List<Product>();
        protected List<Invoice> _invoices = new List<Invoice>();
        protected List<Shipment> _shipments = new List<Shipment>();
        protected List<CurrentStock> _currentStock = new List<CurrentStock>();

        public abstract List<Customer> GetCustomers();
        public abstract List<Employee> GetEmployees();
        public abstract List<Supplier> GetSuppliers();
        public abstract List<Product> GetProducts();
        public abstract List<Invoice> GetInvoices();
        public abstract List<CurrentStock> GetCurrentStock();
        public abstract List<Shipment> GetShipments();

        public abstract void AddCustomer(Customer customer);
        public abstract void AddEmployee(Employee employee);
        public abstract void AddSupplier(Supplier supplier);
        public abstract void AddProduct(Product product);
        public abstract void AddInvoice(Invoice invoice);
        public abstract void AddShipment(Shipment shipment);

        public abstract void RemoveCustomer(Guid customerId);
        public abstract void RemoveEmployee(Guid employeeId);
        public abstract void RemoveSupplier(Guid supplierId);
        public abstract void RemoveProduct(Guid productId);

        public abstract void UpdateCustomer(Customer customer);
        public abstract void UpdateEmployee(Employee employee);
        public abstract void UpdateSupplier(Supplier supplier);
        public abstract void UpdateProduct(Product product);
    }
}