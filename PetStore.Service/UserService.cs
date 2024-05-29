using System;
using System.Collections.Generic;
using System.Linq;
using static PetStore.Service.Conversions.ToDbObjectConverter;
using static PetStore.Service.Conversions.ToModelObjectConverter;
using Customer = PetStore.Model.Users.Customer;
using Supplier = PetStore.Model.Users.Supplier;

namespace PetStore.Service;

public class UserService(string connectionString)
{
    private readonly Data.PetStoreDataContext _context = new(connectionString);
    
    #region customer
    public void AddCustomer(Customer customer)
    {
        _context.Customers.InsertOnSubmit(ToDb(customer));
        _context.SubmitChanges();
    }
    public Customer GetCustomer(Guid id)
    {
        return ToModel((from customer in _context.Customers
                where customer.Id == id
                select customer).First());
    }
    public List<Customer> GetCustomers()
    {
        return (from customer in _context.Customers
            select customer).AsEnumerable().Select(ToModel).ToList();
    }
    public void UpdateCustomer(Customer customer)
    {
        var c = (from cust in _context.Customers
            where cust.Id == customer.Id
            select cust).First();
        c.FirstName = customer.FirstName;
        c.LastName = customer.LastName;
        c.Address = customer.Address;
        c.DeliveryAddress = customer.DeliveryAddress;
        c.BillingInformation = customer.BillingInformation;
        c.DateOfBirth = customer.DateOfBirth;
        c.Email = customer.Email;
        c.Phone = customer.Phone;
        _context.SubmitChanges();
    }
    public void RemoveCustomer(Guid id)
    { 
        var customer = (from cust in _context.Customers
            where cust.Id == id
            select cust).First();
        _context.Customers.DeleteOnSubmit(customer);
        _context.SubmitChanges();
    }
    #endregion

    #region supplier
    public void AddSupplier(Supplier supplier)
    {
        _context.Suppliers.InsertOnSubmit(ToDb(supplier));
        _context.SubmitChanges();
    }
    public Supplier GetSupplier(Guid id)
    {
        return ToModel((from sup in _context.Suppliers
                where sup.Id == id
                select sup).First());
    }
    public List<Supplier> GetSuppliers()
    {
        return (from sup in _context.Suppliers
            select sup).AsEnumerable().Select(ToModel).ToList();
    }
    public void UpdateSupplierEmail(Guid id, string email)
    {
        var supplier = (from sup in _context.Suppliers
            where sup.Id == id
            select sup).First();
        supplier.Email = email;
        _context.SubmitChanges();
    }
    public void UpdateSupplierPhone(Guid id, string phone)
    {
        var supplier = (from sup in _context.Suppliers
            where sup.Id == id
            select sup).First();
        supplier.Phone = phone;
        _context.SubmitChanges();
    }
    public void UpdateSupplierAddress(Guid id, string address)
    {
        var supplier = (from sup in _context.Suppliers
            where sup.Id == id
            select sup).First();
        supplier.Address = address;
        _context.SubmitChanges();
    }
    public void UpdateSupplierName(Guid id, string name)
    {
        var supplier = (from sup in _context.Suppliers
            where sup.Id == id
            select sup).First();
        supplier.Name = name;
        _context.SubmitChanges();
    }
    public void RemoveSupplier(Guid id) 
    {
        var supplier = (from sup in _context.Suppliers
            where sup.Id == id
            select sup).First();
        _context.Suppliers.DeleteOnSubmit(supplier);
        _context.SubmitChanges();
    }
    #endregion
}