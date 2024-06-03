using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Data;
using PetStore.Model.Inventory;
using PetStore.Service;
using Customer = PetStore.Model.Users.Customer;

namespace PetStore.Test;

[TestClass]
public class ServiceTest
{
    private string ConnectionString;

    [TestInitialize]
    public void TestInitialize()
    {
        string _DBRelativePath = @"Instrumentation\PetStore.mdf";
        string _TestingWorkingFolder = Environment.CurrentDirectory;
        string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
        ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True;";
    }
    
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
        
        Customer c = Service.Conversions.ToModelObjectConverter.ToModel(dbCustomer);
        
        Assert.AreEqual(dbCustomer.FirstName, c.FirstName);
        Assert.AreEqual(dbCustomer.LastName, c.LastName);
    }

    [TestMethod]
    public void TestGetCustomer()
    {
        foreach (var c in new UserService(ConnectionString).GetCustomers())
        {
            Assert.AreEqual("Ania", c.FirstName);
        }
    }

    [TestMethod]
    public void TestGetProducts()
    {
        foreach (var item in new InventoryService(ConnectionString).GetProducts())
        {
            Assert.AreEqual("Karma", item.Name);
        }
    }

    [TestMethod]
    public void TestGetOrders()
    {
        foreach (var item in new EventService(ConnectionString).GetOrders())
        {
            Assert.AreEqual("dobrakarma", item.PromoCode);
        }
    }
}