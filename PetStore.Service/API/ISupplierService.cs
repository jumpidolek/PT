using System;

namespace PetStore.Service.API;

public interface ISupplierService
{
    public Guid Id { get; }
    public string Email { get; }
    public string Phone { get; }
    public string Address { get; }
    public string Name { get; }
    
    public void AddSupplier();
    public void UpdatePhone(string phone);
    public void UpdateAddress(string address);
    public void UpdateName(string name);
    public void DeleteSupplier();
}