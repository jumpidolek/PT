using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class CustomerService(
    Guid id,
    string email,
    string phone,
    string address,
    string firstName,
    string lastName,
    DateTime dateOfBirth)
    : ICustomerService
{
    public Guid Id { get; } = id;
    public string Email { get; } = email;
    public string Phone { get; } = phone;
    public string Address { get; } = address;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public DateTime DateOfBirth { get; } = dateOfBirth;

    private readonly PetStoreDataContext _context = new();
    
    public void AddCustomer()
    {
        _context.Customers.InsertOnSubmit(new Customer
        {
            Id = id,
            Email = email,
            Phone = phone,
            Address = address,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth
        });
        _context.SubmitChanges();
    }
    public void UpdatePhone(string phone)
    {
        var customer = _context.Customers.First(c => c.Id == id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        customer.Phone = phone;
        _context.SubmitChanges();
    }
    public void UpdateAddress(string address)
    {
        var customer = (from c in _context.Customers
            where c.Id == id
            select c).First();
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        customer.Address = address;
        _context.SubmitChanges();
    }
    public void DeleteCustomer()
    {
        var customer = _context.Customers.First(c => c.Id == id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        _context.Customers.DeleteOnSubmit(customer);
        _context.SubmitChanges();
    }
    
    public static List<ICustomerService> GetCustomers()
    {
        var context = new PetStoreDataContext();
        return
        [
            ..(from c in context.Customers
                select new CustomerService(
                    c.Id,
                    c.Email,
                    c.Phone,
                    c.Address,
                    c.FirstName,
                    c.LastName,
                    c.DateOfBirth)).ToList()
        ];
    }
    public static ICustomerService GetCustomer(Guid id)
    {
        var context = new PetStoreDataContext();
        var customer = context.Customers.First(c => c.Id == id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        return new CustomerService(
            customer.Id,
            customer.Email,
            customer.Phone,
            customer.Address,
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth);
    }
}