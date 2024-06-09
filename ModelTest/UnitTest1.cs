using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PetStore.Model.Models.Users;

namespace ModelTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Customer.Add(new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                DateOfBirth = DateTime.Now.AddYears(-22),
                Email = "Test",
                Phone = "Test",
                Address = "Test"
            });
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            var c = Customer.GetAll();
            foreach (var VARIABLE in c)
            {
                Console.WriteLine(VARIABLE.FirstName + VARIABLE.LastName);
            }
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            
        }
    }
}
