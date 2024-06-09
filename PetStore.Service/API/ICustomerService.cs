using System;

namespace PetStore.Service.API;

public interface ICustomerService
{
    public Guid Id { get; }
    public string Email { get; }
    public string Phone { get; }
    public string Address { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    
    public void AddCustomer();
    public void UpdatePhone(string phone);
    public void UpdateAddress(string address);
    public void DeleteCustomer();
}