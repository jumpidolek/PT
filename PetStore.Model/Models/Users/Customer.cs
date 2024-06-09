using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Users;

public class Customer
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    #region functions

    public static void Add(Customer c)
    {
        Task.Run(() =>
            new CustomerService(c.Id, c.FirstName, c.LastName, c.Address, c.Email, c.Phone, c.DateOfBirth).AddCustomer()
            );
    }
        
    public static Customer Get(Guid id)
    {
        return Task.Run(() =>
        {
            var customerService = CustomerService.GetCustomer(id);
            return new Customer
            {
                Id = customerService.Id,
                FirstName = customerService.FirstName,
                LastName = customerService.LastName,
                DateOfBirth = customerService.DateOfBirth,
                Email = customerService.Email,
                Phone = customerService.Phone,
                Address = customerService.Address
            };
        }).Result;
    }
    public static List<Customer> GetAll()
    {
        return Task.Run(() =>
        {
            var customerServices = CustomerService.GetCustomers();
            return customerServices.Select(customerService => new Customer
            {
                Id = customerService.Id,
                FirstName = customerService.FirstName,
                LastName = customerService.LastName,
                DateOfBirth = customerService.DateOfBirth,
                Email = customerService.Email,
                Phone = customerService.Phone,
                Address = customerService.Address
            }).ToList();
        }).Result;
    }
    public static void ChangeAddress(Guid id, string address)
    {
        Task.Run(() => CustomerService.GetCustomer(id).UpdateAddress(address));
    }
    public static void ChangePhone(Guid id, string phone)
    {
        Task.Run(() => CustomerService.GetCustomer(id).UpdatePhone(phone));
    }
    public static void Remove(Guid id)
    {
        Task.Run(() => CustomerService.GetCustomer(id).DeleteCustomer());
    }
    
    #endregion
}