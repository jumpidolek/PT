using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Model.Events;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Test;
    
[TestClass]
public class ModelTest
{
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
        
    [TestMethod]
    public void TestOrder()
    {
        Product p = new Product
        {
            Name = "Dog Food",
            Price = 10
        };
        Order o = new Order
        {
            Products = new List<Product> { p },
        };
            
        Assert.AreEqual(1, o.Products.Count);
        Assert.AreEqual(p, o.Products[0]);
    }
        
    [TestMethod]
    public void TestInvoice()
    {
        Product p = new Product
        {
            Name = "Dog Food",
            Price = 10
        };
        Order o = new Order
        {
            Products = new List<Product> { p },
        };
        Customer Customer = new Customer
        {
            FirstName = "Maddy",
            LastName = "Chaplin"
        };
        Invoice i = new Invoice
        {
            Order = o,
            Customer = Customer,
        };
            
        Assert.AreEqual(1, i.Order.Products.Count);
        Assert.AreEqual(p, i.Order.Products[0]);
        Assert.AreEqual("Maddy", i.Customer.FirstName);
        Assert.AreEqual("Chaplin", i.Customer.LastName);
    }
}