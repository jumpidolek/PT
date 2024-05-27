using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Service.Conversions
{
    internal static class ToModelObjectConverter
    {
        internal static Data.Model.Users.Employee ToModel(Data.Employee employee) => new Data.Model.Users.Employee
        {
            Id = employee.Id,
            Email = employee.Email,
            Phone = employee.Phone,
            Address = employee.Address,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Position = employee.Position,
            Salary = employee.Salary,
            Department = employee.Department,
            HireDate = employee.HireDate
        };

        internal static Data.Model.Users.Customer ToModel(Data.Customer customer) => new Data.Model.Users.Customer
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

        internal static Data.Model.Users.Supplier ToModel(Data.Supplier supplier) => new Data.Model.Users.Supplier
        {
            Id = supplier.Id,
            Email = supplier.Email,
            Phone = supplier.Phone,
            Address = supplier.Address,
            Name = supplier.Name
        };

        internal static Data.Model.Inventory.Product ToModel(Data.Product product) => new Data.Model.Inventory.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Brand = product.Brand,
            Category = (Data.Model.Inventory.Category)product.Category,
            Price = product.Price,
            PetType = (Data.Model.Inventory.PetType)product.PetType
        };

        internal static Data.Model.Inventory.CurrentStock ToModel(Data.CurrentStock currentStock) => new Data.Model.Inventory.CurrentStock
        {
            Id = currentStock.Id,
            Product = ToModel(currentStock.Product),
            Amount = currentStock.Amount
        };

        internal static Data.Model.Events.Shipment ToModel(Data.Shipment shipment) {
            var products = shipment.Products.Select(ToModel).ToList();
            return new Data.Model.Events.Shipment()
            {
                Id = shipment.Id,
                Product = products,
                Supplier = ToModel(shipment.Supplier)
            };
        }

        internal static Data.Model.Events.Order ToModel(Data.Order order)
        {
            var products = order.Products.Select(ToModel).ToList();
            return new Data.Model.Events.Order()
            {
                Id = order.Id,
                Product = products,
                PromoCode = order.PromoCode,
                ShippingCost = order.ShippingCost,
                Total = order.Total
            };
        }

        internal static Data.Model.Events.Invoice ToModel(Data.Invoice invoice) => new Data.Model.Events.Invoice
        {
            Id = invoice.Id,
            Customer = ToModel(invoice.Customer),
            Order = ToModel(invoice.Order)
        };
    }
}
