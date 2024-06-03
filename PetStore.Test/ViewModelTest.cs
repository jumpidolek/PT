using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Model.Users;
using PetStore.Test.DataGeneration;
using PetStore.ViewModel;

namespace PetStore.Test;

[TestClass]
public class ViewModelTest
{
    [TestMethod]
    public void TestChangeMode()
    {
        var vm = new MainViewModel();
        Assert.IsTrue(vm.IsEnabled);
        vm.ChangeModeCommand.Execute(null);
        Assert.IsFalse(vm.IsEnabled);
    }
    
    [TestMethod]
    public void TestGetListObjects()
    {
        List<Customer> c = [
            new Customer { FirstName = "Maddy", LastName = "Chaplin" },
            new Customer { FirstName = "John", LastName = "Doe" }
        ];
        var vm = new MainViewModel(c);
        Assert.IsNotNull(vm.ListObjects);
    }
    
    [TestMethod]
    public void TestGetListObjectsBogus()
    {
        List<Customer> c = BogusDataGeneration.CreateCustomers();
        var vm = new MainViewModel(c);
        Assert.IsNotNull(vm.ListObjects);
    }
    
    [TestMethod]
    public void TestGetListObjectsManual()
    {
        List<Customer> c = ManualDataGeneration.GenerateCustomers();
        var vm = new MainViewModel(c);
        Assert.IsNotNull(vm.ListObjects);
    }
}