using System.ComponentModel;
using System.Data.Linq;
using PetStore.Data;

namespace DataTest;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TestCustomer()
    {
        Customer customer = new Customer();
        customer.FirstName = "John";
        customer.LastName = "Doe";
        customer.Email = "email";
        customer.Phone = "1234567890";
        customer.Address = "123 Main";
        customer.DateOfBirth = new DateTime(2000, 1, 1);
        Assert.AreEqual("John", customer.FirstName);
        Assert.AreEqual("Doe", customer.LastName);
        Assert.AreEqual("email", customer.Email);
        Assert.AreEqual("1234567890", customer.Phone);
        Assert.AreEqual("123 Main", customer.Address);
        Assert.AreEqual(new DateTime(2000, 1, 1), customer.DateOfBirth);
    }
    
    [TestMethod]
    public void TestProduct()
    {
        Product product = new Product();
        product.Name = "Dog Food";
        product.Price = 10;
        product.Description = "Food for dogs";
        product.Category = 1;
        Assert.AreEqual("Dog Food", product.Name);
        Assert.AreEqual(10.0, product.Price);
        Assert.AreEqual("Food for dogs", product.Description);
        Assert.AreEqual(1, product.Category);
    }
    
    [TestMethod]
    public void TestOrder()
    {
        Order order = new Order
        {
            Id = Guid.NewGuid(),
            Products = new EntitySet<Product>
            {
                new Product
                {
                    Name = "Dog Food",
                    Price = 10,
                    Description = "Food for dogs",
                    Category = 1
                }
            },
            PromoCode = "PROMO",
            ShippingCost = 5,
            Total = 15
        };
        Assert.AreEqual(1, order.Products.Count);
        Assert.AreEqual("Dog Food", order.Products[0].Name);
        Assert.AreEqual(10.0, order.Products[0].Price);
        Assert.AreEqual("Food for dogs", order.Products[0].Description);
        Assert.AreEqual(1, order.Products[0].Category);
        Assert.AreEqual("PROMO", order.PromoCode);
        Assert.AreEqual(5.0, order.ShippingCost);
        Assert.AreEqual(15.0, order.Total);
    }
}