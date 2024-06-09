using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class SupplierService(Guid id, string email, string phone, string address, string name)
    : ISupplierService
{
    public Guid Id { get; } = id;
    public string Email { get; } = email;
    public string Phone { get; } = phone;
    public string Address { get; } = address;
    public string Name { get; } = name;

    private readonly PetStoreDataContext _context = new();
    
    public void AddSupplier()
    {
        _context.Suppliers.InsertOnSubmit(new Supplier
        {
            Id = id,
            Email = email,
            Phone = phone,
            Address = address,
            Name = name
        });
        _context.SubmitChanges();
    }
    public void UpdatePhone(string phone)
    {
        var supplier = _context.Suppliers.First(s => s.Id == id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        supplier.Phone = phone;
        _context.SubmitChanges();
    }
    public void UpdateAddress(string address)
    {
        var supplier = (from s in _context.Suppliers
            where s.Id == id
            select s).First();
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        supplier.Address = address;
        _context.SubmitChanges();
    }
    public void UpdateName(string name)
    {
        var supplier = _context.Suppliers.First(s => s.Id == id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        supplier.Name = name;
        _context.SubmitChanges();
    }
    public void DeleteSupplier()
    {
        var supplier = _context.Suppliers.First(s => s.Id == id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        _context.Suppliers.DeleteOnSubmit(supplier);
        _context.SubmitChanges();
    }
    
    public static List<ISupplierService> GetSuppliers()
    {
        var context = new PetStoreDataContext();
        var suppliers = new List<ISupplierService>();
        foreach (var supplier in context.Suppliers)
        {
            suppliers.Add(new SupplierService(supplier.Id, supplier.Email, supplier.Phone, supplier.Address, supplier.Name));
        }
        return suppliers;
    }
    public static ISupplierService GetSupplier(Guid id)
    {
        var context = new PetStoreDataContext();
        var supplier = context.Suppliers.First(s => s.Id == id);
        if (supplier == null)
        {
            throw new Exception("Supplier not found");
        }
        return new SupplierService(supplier.Id, supplier.Email, supplier.Phone, supplier.Address, supplier.Name);
    }
}