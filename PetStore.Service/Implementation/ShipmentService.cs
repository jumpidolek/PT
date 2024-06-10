using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class ShipmentService(Guid id, List<IProductService> products, ISupplierService supplier, string connectionString)
    : IShipmentService
{
    public Guid Id { get; } = id;
    public List<IProductService> Products { get; } = products;
    public ISupplierService Supplier { get; } = supplier;

    private readonly PetStoreDataContext _context = new(connectionString);
    
    public void AddShipment()
    {
        var shipment = new Shipment
        {
            Id = Id,
            Products = []
        };
        foreach (var product in Products)
        {
            shipment.Products.Add(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
        }
        shipment.Supplier = new Supplier
        {
            Id = Supplier.Id,
            Name = Supplier.Name,
            Email = Supplier.Email,
            Phone = Supplier.Phone,
            Address = Supplier.Address
        };
        _context.Shipments.InsertOnSubmit(shipment);
        _context.SubmitChanges();
    }
    
    public static List<IShipmentService> GetShipments(string connectionString)
    {
        var shipments = new List<IShipmentService>();
        var context = new PetStoreDataContext(connectionString);
        var shipmentQuery = from s in context.Shipments
            select s;
        foreach (var shipment in shipmentQuery)
        {
            var products = new List<IProductService>();
            foreach (var product in shipment.Products)
            {
                products.Add(new ProductService(
                    product.Id, 
                    product.Name, 
                    product.Description, 
                    product.Brand, 
                    (Category)product.Category, 
                    product.Price, 
                    (PetType)product.PetType,
                    connectionString));
            }
            var supplier = new SupplierService(shipment.Supplier.Id, shipment.Supplier.Email, shipment.Supplier.Phone, shipment.Supplier.Address, shipment.Supplier.Name, connectionString);
            shipments.Add(new ShipmentService(shipment.Id, products, supplier, connectionString));
        }
        return shipments;
    }
    public static IShipmentService GetShipment(Guid id, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var shipment = (from s in context.Shipments
            where s.Id == id
            select s).First();
        var products = new List<IProductService>();
        foreach (var product in shipment.Products)
        {
            products.Add(new ProductService(
                product.Id, 
                product.Name, 
                product.Description, 
                product.Brand, 
                (Category)product.Category, 
                product.Price, 
                (PetType)product.PetType,
                connectionString));
        }
        var supplier = new SupplierService(shipment.Supplier.Id, shipment.Supplier.Email, shipment.Supplier.Phone, shipment.Supplier.Address, shipment.Supplier.Name, connectionString);
        return new ShipmentService(shipment.Id, products, supplier, connectionString);
    }
}