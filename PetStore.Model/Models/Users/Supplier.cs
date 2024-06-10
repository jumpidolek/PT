using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Users;

public class Supplier
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    
    public static void Add(Supplier c, string connectionString)
    {
        Task.Run(() =>
            new SupplierService(c.Id, c.Email, c.Phone, c.Address, c.Name, connectionString).AddSupplier());
    }
    public static Supplier Get(Guid id, string connectionString)
    {
        return Task.Run(() =>
        {
            var supplierService = SupplierService.GetSupplier(id, connectionString);
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
    public static List<Supplier> GetAll(string connectionString)
    {
        return Task.Run(() =>
        {
            var supplierServices = SupplierService.GetSuppliers(connectionString);
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

    public static void Change(Supplier s, string connectionString)
    {
        Task.Run(() =>
        {
            var supplier = SupplierService.GetSupplier(s.Id, connectionString);
            supplier.Name = s.Name;
            supplier.Phone = s.Phone;
            supplier.Address = s.Address;
            supplier.UpdateSupplier();
        });
    }
    public static void RemoveSupplier(Guid id, string connectionString)
    {
        Task.Run(() => SupplierService.GetSupplier(id, connectionString).DeleteSupplier());
    }
}