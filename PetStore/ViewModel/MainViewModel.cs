using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PetStore.Model.Users;
using PetStore.Service;
using PetStore.ViewModel.Commands;

namespace PetStore.ViewModel;

public sealed class MainViewModel : ViewModelBase
{
    private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;";
    
    public MainViewModel()
    {
        ShowListCommand = new RelayCommand(ShowList);
    }
    
    #region values

    private List<Customer> _listObjects = [];
    public List<Customer> ListObjects
    {
        get => _listObjects = new UserService(ConnectionString).GetCustomers();
        set => SetField(ref _listObjects, value);
    }
    
    private Customer _selectedObject;
    public Customer SelectedObject
    {
        get => _selectedObject;
        set
        {
            SetField(ref _selectedObject, value);
            new UserService(ConnectionString).UpdateCustomer(_selectedObject);
        }
    }

    #endregion
    
    #region commands
    
    public ICommand ShowListCommand { get; set; }
    
    private void ShowList(object obj)
    {
        Task.Run(() =>
        {
            ListObjects!.Clear();
            ListObjects.AddRange(new UserService(ConnectionString).GetCustomers());
        });
    }
    
    #endregion
}