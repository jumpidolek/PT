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
        ChangeModeCommand = new RelayCommand(ChangeMode);
        SaveChangesCommand = new RelayCommand(SaveChanges);
    }
    
    #region values

    private List<Customer> _listObjects = [];
    public List<Customer> ListObjects
    {
        get => _listObjects = Task.Run(() => new UserService(ConnectionString).GetCustomers()).Result;
        set => SetField(ref _listObjects, value);
    }
    
    private Customer _selectedObject;
    public Customer SelectedObject
    {
        get => _selectedObject;
        set => SetField(ref _selectedObject, value);
    }

    private int _selectedIndex = -1;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => SetField(ref _selectedIndex, value);
    }
    
    private bool _isEnabled = true;
    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetField(ref _isEnabled, value);
    }

    private string _stateText = "Edit";
    public string StateText
    {
        get => _stateText;
        set => SetField(ref _stateText, value);
    }

    #endregion
    
    #region commands
    
    public ICommand ChangeModeCommand { get; set; }
    private void ChangeMode(object obj)
    {
        IsEnabled = !IsEnabled;
        StateText = !IsEnabled ? "New" : "Edit";
        SelectedIndex = -1;
        SelectedObject = new Customer
        {
            Id = Guid.NewGuid()
        };
    }
    
    public ICommand SaveChangesCommand { get; set; }
    private void SaveChanges(object obj)
    {
        if (IsEnabled) Task.Run(() => new UserService(ConnectionString).UpdateCustomer(SelectedObject));
        else
        {
            Task.Run(() => new UserService(ConnectionString).AddCustomer(SelectedObject));
            Task.Run(() => ListObjects = new UserService(ConnectionString).GetCustomers());
        }
    }
    
    #endregion
}