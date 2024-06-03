using System.Linq;
using PetStore.Model.Events;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Service.Conversions;

public static class ToModelObjectConverter
{
    public static Customer ToModel(Data.Customer customer) => new()
    {
        Id = customer.Id,
        Email = customer.Email,
        Phone = customer.Phone,
        Address = customer.Address,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        DeliveryAddress = customer.DeliveryAddress,
        BillingInformation = customer.BillingInformation,
        DateOfBirth = customer.DateOfBirth
    }; 
    public static Supplier ToModel(Data.Supplier supplier) => new()
    {
        Id = supplier.Id,
        Email = supplier.Email,
        Phone = supplier.Phone,
        Address = supplier.Address,
        Name = supplier.Name
    };
    public static Product ToModel(Data.Product product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Brand = product.Brand,
        Category = (Category)product.Category,
        Price = product.Price,
        PetType = (PetType)product.PetType
    };
    public static CurrentStock ToModel(Data.CurrentStock currentStock) => new()
    {
        Id = currentStock.Id,
        Product = ToModel(currentStock.Product),
        Amount = currentStock.Amount
    };
    public static Shipment ToModel(Data.Shipment shipment) {
        var products = shipment.Products.Select(ToModel).ToList();
        return new Shipment
        {
            Id = shipment.Id,
            Products = products,
            Supplier = ToModel(shipment.Supplier)
        };
    }
    public static Order ToModel(Data.Order order)
    {
        var products = order.Products.Select(ToModel).ToList();
        return new Order()
        {
            Id = order.Id,
            Products = products,
            PromoCode = order.PromoCode,
            ShippingCost = order.ShippingCost,
            Total = order.Total
        };
    }
    public static Invoice ToModel(Data.Invoice invoice) => new()
    {
        Id = invoice.Id,
        Customer = ToModel(invoice.Customer),
        Order = ToModel(invoice.Order)
    };
}