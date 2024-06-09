using System;

namespace PetStore.Service.API;

public interface ICustomerService
{
    public Guid Id { get; }
    public string Email { get; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    
    public void AddCustomer();
    public void UpdateCustomer();
    public void DeleteCustomer();
}