using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class InvoiceService(Guid id, ICustomerService customer, IOrderService order) : IInvoiceService
{
    public Guid Id { get; set; } = id;
    public ICustomerService Customer { get; set; } = customer;
    public IOrderService Order { get; set; } = order;

    private readonly PetStoreDataContext _context = new();

    public void AddInvoice()
    {
        var customer = _context.Customers.First(c => c.Id == Customer.Id);
        var order = _context.Orders.First(o => o.Id == Order.Id);
        if (customer == null || order == null)
        {
            throw new Exception("Customer or Order not found");
        }
        _context.Invoices.InsertOnSubmit(new Invoice
        {
            Id = id,
            Customer = customer,
            Order = order
        });
        _context.SubmitChanges();
    }
    
    public static List<IInvoiceService> GetInvoices()
    {
        var context = new PetStoreDataContext();
        var invoices = context.Invoices.ToList();
        var invoiceServices = new List<IInvoiceService>();
        foreach (var invoice in invoices)
        {
            var products = new List<IProductService>();
            foreach (var product in invoice.Order.Products)
            {
                products.Add(new ProductService(product.Id, 
                    product.Name, 
                    product.Description, 
                    product.Brand, 
                    (Category)product.Category, 
                    product.Price, 
                    (PetType)product.PetType));
            }
            invoiceServices.Add(new InvoiceService(invoice.Id,
                new CustomerService(invoice.Customer.Id,
                    invoice.Customer.Email,
                    invoice.Customer.Phone,
                    invoice.Customer.Address,
                    invoice.Customer.FirstName,
                    invoice.Customer.LastName,
                    invoice.Customer.DateOfBirth),
                new OrderService(invoice.Order.Id,
                    products,
                    invoice.Order.PromoCode,
                    invoice.Order.ShippingCost,
                    invoice.Order.Total)));
        }
        return invoiceServices;
    }
    
    public static IInvoiceService GetInvoice(Guid id)
    {
        var context = new PetStoreDataContext();
        var invoice = context.Invoices.First(i => i.Id == id);
        if (invoice == null)
        {
            throw new Exception("Invoice not found");
        }
        var products = new List<IProductService>();
        foreach (var product in invoice.Order.Products)
        {
            products.Add(new ProductService(product.Id, 
                product.Name, 
                product.Description, 
                product.Brand, 
                (Category)product.Category, 
                product.Price, 
                (PetType)product.PetType));
        }
        return new InvoiceService(invoice.Id, 
            new CustomerService(
                invoice.Customer.Id, 
                invoice.Customer.Email, 
                invoice.Customer.Phone, 
                invoice.Customer.Address, 
                invoice.Customer.FirstName, 
                invoice.Customer.LastName, 
                invoice.Customer.DateOfBirth), 
            new OrderService(
                invoice.Order.Id, 
                products, 
                invoice.Order.PromoCode, 
                invoice.Order.ShippingCost, 
                invoice.Order.Total));
    }
}