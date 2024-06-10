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
    DateTime dateOfBirth,
    string connectionString)
    : ICustomerService
{
    public Guid Id { get; } = id;
    public string Email { get; } = email;
    public string Phone { get; set; } = phone;
    public string Address { get; set; } = address;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public DateTime DateOfBirth { get; } = dateOfBirth;

    private readonly PetStoreDataContext _context = new(connectionString);
    
    public void AddCustomer()
    {
        _context.Customers.InsertOnSubmit(new Customer
        {
            Id = Id,
            Email = Email,
            Phone = Phone,
            Address = Address,
            FirstName = FirstName,
            LastName = LastName,
            DateOfBirth = DateOfBirth
        });
        _context.SubmitChanges();
    }

    public void UpdateCustomer()
    {
        var customer = _context.Customers.Where(c => c.Id == Id).Select(x => x).First();
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        customer.Phone = Phone;
        customer.Address = Address;
        _context.SubmitChanges();
    }
    public void DeleteCustomer()
    {
        var customer = (from c in _context.Customers
                        where c.Id == Id
                        select c).First();
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        _context.Customers.DeleteOnSubmit(customer);
        _context.SubmitChanges();
    }
    
    public static List<ICustomerService> GetCustomers(string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
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
                    c.DateOfBirth,
                    connectionString)).ToList()
        ];
    }
    public static ICustomerService GetCustomer(Guid id, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
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
            customer.DateOfBirth,
            connectionString);
    }
}