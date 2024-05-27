using System.Linq;
using PetStore.Model.Events;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Service.Conversions
{
    internal static class ToModelObjectConverter
    {
        internal static Employee ToModel(Data.Employee employee) => new Employee
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

        internal static Customer ToModel(Data.Customer customer) => new Customer
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

        internal static Supplier ToModel(Data.Supplier supplier) => new Supplier
        {
            Id = supplier.Id,
            Email = supplier.Email,
            Phone = supplier.Phone,
            Address = supplier.Address,
            Name = supplier.Name
        };

        internal static Product ToModel(Data.Product product) => new Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Brand = product.Brand,
            Category = (Category)product.Category,
            Price = product.Price,
            PetType = (PetType)product.PetType
        };

        internal static CurrentStock ToModel(Data.CurrentStock currentStock) => new CurrentStock
        {
            Id = currentStock.Id,
            Product = ToModel(currentStock.Product),
            Amount = currentStock.Amount
        };

        internal static Shipment ToModel(Data.Shipment shipment) {
            var products = shipment.Products.Select(ToModel).ToList();
            return new Shipment()
            {
                Id = shipment.Id,
                Product = products,
                Supplier = ToModel(shipment.Supplier)
            };
        }

        internal static Order ToModel(Data.Order order)
        {
            var products = order.Products.Select(ToModel).ToList();
            return new Order()
            {
                Id = order.Id,
                Product = products,
                PromoCode = order.PromoCode,
                ShippingCost = order.ShippingCost,
                Total = order.Total
            };
        }

        internal static Invoice ToModel(Data.Invoice invoice) => new Invoice
        {
            Id = invoice.Id,
            Customer = ToModel(invoice.Customer),
            Order = ToModel(invoice.Order)
        };
    }
}
