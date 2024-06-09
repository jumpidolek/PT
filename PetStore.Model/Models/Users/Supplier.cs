using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Users;

public class Supplier
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    
    public static void Add(Supplier c)
    {
        Task.Run(() =>
            new SupplierService(c.Id, c.Name, c.Address, c.Email, c.Phone).AddSupplier());
    }
    public static Supplier Get(Guid id)
    {
        return Task.Run(() =>
        {
            var supplierService = SupplierService.GetSupplier(id);
            return new Supplier
            {
                Id = supplierService.Id,
                Name = supplierService.Name,
                Email = supplierService.Email,
                Phone = supplierService.Phone,
                Address = supplierService.Address
            };
        }).Result;
    }
    public static List<Supplier> GetAll()
    {
        return Task.Run(() =>
        {
            var supplierServices = SupplierService.GetSuppliers();
            return supplierServices.Select(supplierService => new Supplier
            {
                Id = supplierService.Id,
                Name = supplierService.Name,
                Email = supplierService.Email,
                Phone = supplierService.Phone,
                Address = supplierService.Address
            }).ToList();
        }).Result;
    }
    public static void ChangeAddress(Guid id, string address)
    {
        Task.Run(() => SupplierService.GetSupplier(id).UpdateAddress(address));
    }
    public static void ChangePhone(Guid id, string phone)
    {
        Task.Run(() => SupplierService.GetSupplier(id).UpdatePhone(phone));
    }
    public static void ChangeName(Guid id, string name)
    {
        Task.Run(() => SupplierService.GetSupplier(id).UpdateName(name));
    }
    public static void RemoveSupplier(Guid id)
    {
        Task.Run(() => SupplierService.GetSupplier(id).DeleteSupplier());
    }
}