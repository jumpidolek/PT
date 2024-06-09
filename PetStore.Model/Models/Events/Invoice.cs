using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Users;
using PetStore.Service.API;
using PetStore.Service.Implementation;
using Category = PetStore.Service.API.Category;
using PetType = PetStore.Service.API.PetType;

namespace PetStore.Model.Models.Events;

public class Invoice
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Order Order { get; set; }
    
    public static void Add(Invoice c)
    {
        var productServices = new List<IProductService>();
        foreach (var product in c.Order.Products)
        {
            productServices.Add(new ProductService(product.Id, product.Name, product.Description, product.Brand, (Category)product.Category, product.Price, (PetType)product.PetType));
        }
        Task.Run(() => new InvoiceService(c.Id, new CustomerService(c.Customer.Id, c.Customer.FirstName, c.Customer.LastName, c.Customer.Address, c.Customer.Email, c.Customer.Phone, c.Customer.DateOfBirth), new OrderService(c.Order.Id, productServices, c.Order.PromoCode, c.Order.ShippingCost, c.Order.Total)).AddInvoice());
    }
    public static Invoice Get(Guid id)
    {
        return Task.Run(() =>
        {
            var invoiceService = InvoiceService.GetInvoice(id);
            var products = new List<Product>(); 
            foreach (var productService in invoiceService.Order.Products)
            {
                products.Add(new Product
                {
                    Id = productService.Id,
                    Name = productService.Name,
                    Description = productService.Description,
                    Brand = productService.Brand,
                    Category = (Inventory.Category)productService.Category,
                    Price = productService.Price,
                    PetType = (Inventory.PetType)productService.PetType
                });
            }
            return new Invoice
            {
                Id = invoiceService.Id,
                Customer = new Customer
                {
                    Id = invoiceService.Customer.Id,
                    FirstName = invoiceService.Customer.FirstName,
                    LastName = invoiceService.Customer.LastName,
                    DateOfBirth = invoiceService.Customer.DateOfBirth,
                    Email = invoiceService.Customer.Email,
                    Phone = invoiceService.Customer.Phone,
                    Address = invoiceService.Customer.Address
                },
                Order = new Order
                {
                    Id = invoiceService.Order.Id,
                    Products = products,
                    PromoCode = invoiceService.Order.PromoCode,
                    ShippingCost = invoiceService.Order.ShippingCost,
                    Total = invoiceService.Order.Total
                }
            };
        }).Result;
    }
    public static List<Invoice> GetAll()
    {
        return Task.Run(() =>
        {
            var invoiceServices = InvoiceService.GetInvoices();
            var invoices = new List<Invoice>();
            foreach (var invoiceService in invoiceServices)
            {
                var products = new List<Product>();
                foreach (var productService in invoiceService.Order.Products)
                {
                    products.Add(new Product
                    {
                        Id = productService.Id,
                        Name = productService.Name,
                        Description = productService.Description,
                        Brand = productService.Brand,
                        Category = (Inventory.Category)productService.Category,
                        Price = productService.Price,
                        PetType = (Inventory.PetType)productService.PetType
                    });
                }
                invoices.Add(new Invoice
                {
                    Id = invoiceService.Id,
                    Customer = new Customer
                    {
                        Id = invoiceService.Customer.Id,
                        FirstName = invoiceService.Customer.FirstName,
                        LastName = invoiceService.Customer.LastName,
                        DateOfBirth = invoiceService.Customer.DateOfBirth,
                        Email = invoiceService.Customer.Email,
                        Phone = invoiceService.Customer.Phone,
                        Address = invoiceService.Customer.Address
                    },
                    Order = new Order
                    {
                        Id = invoiceService.Order.Id,
                        Products = products,
                        PromoCode = invoiceService.Order.PromoCode,
                        ShippingCost = invoiceService.Order.ShippingCost,
                        Total = invoiceService.Order.Total
                    }
                });
            }
            return invoices;
        }).Result;
    }
}