using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class ShipmentService(Guid id, List<IProductService> products, ISupplierService supplier)
    : IShipmentService
{
    public Guid Id { get; set; } = id;
    public List<IProductService> Products { get; set; } = products;
    public ISupplierService Supplier { get; set; } = supplier;

    private readonly PetStoreDataContext _context = new();
    
    public void AddShipment()
    {
        var shipment = new Shipment
        {
            Id = id,
            Products = []
        };
        foreach (var product in products)
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
            Id = supplier.Id,
            Name = supplier.Name,
            Email = supplier.Email,
            Phone = supplier.Phone,
            Address = supplier.Address
        };
        _context.Shipments.InsertOnSubmit(shipment);
        _context.SubmitChanges();
    }
    
    public static List<IShipmentService> GetShipments()
    {
        var shipments = new List<IShipmentService>();
        var context = new PetStoreDataContext();
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
                    (PetType)product.PetType));
            }
            var supplier = new SupplierService(shipment.Supplier.Id, shipment.Supplier.Email, shipment.Supplier.Phone, shipment.Supplier.Address, shipment.Supplier.Name);
            shipments.Add(new ShipmentService(shipment.Id, products, supplier));
        }
        return shipments;
    }
    public static IShipmentService GetShipment(Guid id)
    {
        var context = new PetStoreDataContext();
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
                (PetType)product.PetType));
        }
        var supplier = new SupplierService(shipment.Supplier.Id, shipment.Supplier.Email, shipment.Supplier.Phone, shipment.Supplier.Address, shipment.Supplier.Name);
        return new ShipmentService(shipment.Id, products, supplier);
    }
}