using System.Data.Linq;
using PetStore.Model.Users;
using PetStore.Model.Inventory;
using PetStore.Model.Events;

namespace PetStore.Service.Conversions;

public static class ToDbObjectConverter
{
    internal static Data.Customer ToDb(Customer customer) => new Data.Customer
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

    internal static Data.Supplier ToDb(Supplier supplier) => new Data.Supplier
    {
        Id = supplier.Id,
        Email = supplier.Email,
        Phone = supplier.Phone,
        Address = supplier.Address,
        Name = supplier.Name
    };

    internal static Data.Product ToDb(Product product) => new Data.Product
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Brand = product.Brand,
        Category = (int)product.Category,
        Price = product.Price,
        PetType = (int)product.PetType
    };

    internal static Data.CurrentStock ToDb(CurrentStock currentStock) => new Data.CurrentStock
    {
        Id = currentStock.Id,
        Product = ToDb(currentStock.Product),
        Amount = currentStock.Amount
    };

    internal static Data.Shipment ToDb(Shipment shipment)
    {
        var products = new EntitySet<Data.Product>();
        foreach (var p in shipment.Products)
        {
            products.Add(ToDb(p));
        }
        return new Data.Shipment()
        {
            Id = shipment.Id,
            Products = products,
            Supplier = ToDb(shipment.Supplier)
        };
    }
    
    internal static Data.Order ToDb(Order order)
    {
        var products = new EntitySet<Data.Product>();
        foreach (var p in order.Products)
        {
            products.Add(ToDb(p));
        }
        return new Data.Order()
        {
            Id = order.Id,
            Products = products,
            PromoCode = order.PromoCode,
            ShippingCost = order.ShippingCost,
            Total = order.Total
        };
    }
    
    internal static Data.Invoice ToDb(Invoice invoice) => new()
    {
        Id = invoice.Id,
        Customer = ToDb(invoice.Customer),
        Order = ToDb(invoice.Order)
    };
}