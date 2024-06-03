using System.Collections.Generic;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Data;

namespace PetStore.Test;

[TestClass]
public class DataTest
{
    [TestMethod]
    public void TestOrder()
    {
        Order o = new Order
        {
            Products = [new Product { Name = "Dog Food", Price = 10 }],
        };
        
        Assert.AreEqual(1, o.Products.Count);
    }
    
    [TestMethod]
    public void TestInvoice()
    {
        Order o = new Order
        {
            Products = [new Product { Name = "Dog Food", Price = 10 }],
        };
        Invoice i = new Invoice
        {
            Order = o
        };
        
        Assert.AreEqual(1, i.Order.Products.Count);
    }
    
    [TestMethod]
    public void TestCustomer()
    {
        Customer c = new Customer
        {
            FirstName = "Maddy",
            LastName = "Chaplin"
        };
        
        Assert.AreEqual("Maddy", c.FirstName);
        Assert.AreEqual("Chaplin", c.LastName);
    }
    
    [TestMethod]
    public void TestSupplier()
    {
        Supplier s = new Supplier
        { 
            Name = "PetCo"
        };
        
        Assert.AreEqual("PetCo", s.Name);
    }
    
    [TestMethod]
    public void TestProduct()
    {
        Product p = new Product
        { 
            Name = "Dog Food",
            Price = 10
        };
        
        Assert.AreEqual("Dog Food", p.Name);
        Assert.AreEqual(10, p.Price);
    }
}