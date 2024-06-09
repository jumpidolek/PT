using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class SupplierService(Guid id, string email, string phone, string address, string name, string connectionString)
    : ISupplierService
{
    public Guid Id { get; } = id;
    public string Email { get; } = email;
    public string Phone { get; set; } = phone;
    public string Address { get; set; } = address;
    public string Name { get; set; } = name;

    private readonly PetStoreDataContext _context = new(connectionString);
    
    public void AddSupplier()
    {
        _context.Suppliers.InsertOnSubmit(new Supplier
        {
            Id = Id,
            Email = Email,
            Phone = Phone,
            Address = Address,
            Name = Name
        });
        _context.SubmitChanges();
    }
    public void UpdateSupplier()
    {
        var supplier = _context.Suppliers.First(s => s.Id == Id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        supplier.Phone = Phone;
        supplier.Address = Address;
        supplier.Name = Name;
        _context.SubmitChanges();
    }
    public void DeleteSupplier()
    {
        var supplier = _context.Suppliers.First(s => s.Id == Id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        _context.Suppliers.DeleteOnSubmit(supplier);
        _context.SubmitChanges();
    }
    
    public static List<ISupplierService> GetSuppliers(string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var suppliers = new List<ISupplierService>();
        foreach (var supplier in context.Suppliers)
        {
            suppliers.Add(new SupplierService(supplier.Id, supplier.Email, supplier.Phone, supplier.Address, supplier.Name, connectionString));
        }
        return suppliers;
    }
    public static ISupplierService GetSupplier(Guid id, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var supplier = context.Suppliers.First(s => s.Id == id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        return new SupplierService(supplier.Id, supplier.Email, supplier.Phone, supplier.Address, supplier.Name, connectionString);
    }
}