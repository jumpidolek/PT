using System;

namespace PetStore.Service.API;

public interface ISupplierService
{
    public Guid Id { get; }
    public string Email { get; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    
    public void AddSupplier();
    public void UpdateSupplier();
    public void DeleteSupplier();
}