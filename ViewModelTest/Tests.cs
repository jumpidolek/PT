using PetStore.ViewModel;
using PetStore.ViewModel.Repository;

namespace ViewModelTest;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TestGetListObjectsBogus()
    {
        var b = new DataGeneration.Bogus();
        IDataRepository repo = b.GetRepository();
        var vm = new MainViewModel(repo);
        Assert.IsNotNull(vm.ListObjects);
        Assert.AreEqual(10, repo.Customers.Count);
    }

    [TestMethod]
    public void TestGetListObjectsManual()
    {
        var m = new DataGeneration.Manual();
        IDataRepository repo = m.GetRepository();
        var vm = new MainViewModel(repo);
        Assert.IsNotNull(vm.ListObjects);
        Assert.AreEqual(3, repo.Customers.Count);
    }
    
    [TestMethod]
    public void TestChangeMode()
    {
        var vm = new MainViewModel(new DataRepository());
        Assert.IsTrue(vm.IsEnabled);
        vm.ChangeModeCommand.Execute(null);
        Assert.IsFalse(vm.IsEnabled);
    }
}