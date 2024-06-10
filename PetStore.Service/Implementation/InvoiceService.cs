using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class InvoiceService(Guid id, ICustomerService customer, IOrderService order, string connectionString) : IInvoiceService
{
    public Guid Id { get; } = id;
    public ICustomerService Customer { get; } = customer;
    public IOrderService Order { get; } = order;

    private readonly PetStoreDataContext _context = new(connectionString);

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
            Id = Id,
            Customer = customer,
            Order = order
        });
        _context.SubmitChanges();
    }
    
    public static List<IInvoiceService> GetInvoices(string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
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
                    (PetType)product.PetType,
                    connectionString));
            }
            invoiceServices.Add(new InvoiceService(invoice.Id,
                new CustomerService(invoice.Customer.Id,
                    invoice.Customer.Email,
                    invoice.Customer.Phone,
                    invoice.Customer.Address,
                    invoice.Customer.FirstName,
                    invoice.Customer.LastName,
                    invoice.Customer.DateOfBirth,
                    connectionString),
                new OrderService(invoice.Order.Id,
                    products,
                    invoice.Order.PromoCode,
                    invoice.Order.ShippingCost,
                    invoice.Order.Total,
                    connectionString),
                connectionString));
        }
        return invoiceServices;
    }
    
    public static IInvoiceService GetInvoice(Guid id, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
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
                (PetType)product.PetType,
                connectionString));
        }
        return new InvoiceService(invoice.Id, 
            new CustomerService(
                invoice.Customer.Id, 
                invoice.Customer.Email, 
                invoice.Customer.Phone, 
                invoice.Customer.Address, 
                invoice.Customer.FirstName, 
                invoice.Customer.LastName, 
                invoice.Customer.DateOfBirth,
                connectionString), 
            new OrderService(
                invoice.Order.Id, 
                products, 
                invoice.Order.PromoCode, 
                invoice.Order.ShippingCost, 
                invoice.Order.Total,
                connectionString),
            connectionString);
    }
}