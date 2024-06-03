using System.Collections.Generic;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Data;
using PetStore.Model.Inventory;
using Customer = PetStore.Model.Users.Customer;
using Product = PetStore.Model.Inventory.Product;

namespace PetStore.Test;

[TestClass]
public class ServiceTest
{
    private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;";
    
    [TestMethod]
    public void TestDbObjectConverter()
    {
        Customer c = new Customer
        {
            FirstName = "Maddy",
            LastName = "Chaplin"
        };
        
        Data.Customer dbCustomer = PetStore.Service.Conversions.ToDbObjectConverter.ToDb(c);
        
        Assert.AreEqual(c.FirstName, dbCustomer.FirstName);
        Assert.AreEqual(c.LastName, dbCustomer.LastName);
    }
    
    [TestMethod]
    public void TestModelObjectConverter()
    {
        Data.Customer dbCustomer = new Data.Customer
        {
            FirstName = "Maddy",
            LastName = "Chaplin"
        };
        
        Customer c = PetStore.Service.Conversions.ToModelObjectConverter.ToModel(dbCustomer);
        
        Assert.AreEqual(dbCustomer.FirstName, c.FirstName);
        Assert.AreEqual(dbCustomer.LastName, c.LastName);
    }

    [TestMethod]
    public void TestEventServiceAddOrder()
    {
        Model.Events.Order o = new Model.Events.Order
        {
            Products = [new Product { Name = "Dog Food", Price = 10 }],
        };
        
        new Service.EventService(ConnectionString).AddOrder(o);
    }
    
    [TestMethod]
    public void TestEventServiceAddInvoice()
    {
        Model.Events.Order o = new Model.Events.Order
        {
            Products = [new Product { Name = "Dog Food", Price = 10 }],
        };
        Model.Events.Invoice i = new Model.Events.Invoice
        {
            Order = o
        };
        
        new Service.EventService(ConnectionString).AddInvoice(i);
    }
    
    [TestMethod]
    public void TestEventServiceAddShipment()
    {
        Product p = new Product
        {
            Name = "Dog Food",
            Price = 10
        };
        Model.Inventory.CurrentStock cs = new Model.Inventory.CurrentStock
        {
            Product = p,
            Amount = 10
        };
        Model.Events.Shipment s = new Model.Events.Shipment
        {
            Products = new List<Model.Inventory.Product> { p },
            Supplier = new Model.Users.Supplier { Name = "PetCo" }
        };
        
        new Service.EventService(ConnectionString).AddShipment(s);
    }
}