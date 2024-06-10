using System.Windows.Input;
using PetStore.Model;
using PetStore.Model.Models.Users;
using PetStore.ViewModel.Commands;
using PetStore.ViewModel.Repository;

namespace PetStore.ViewModel;

public sealed class MainViewModel : ViewModelBase
{
    private readonly IDataRepository _repository;
    
    public MainViewModel( IDataRepository repository )
    {
        _repository = repository;
        _listObjects = _repository.Customers;
        ChangeModeCommand = new RelayCommand(ChangeMode);
        SaveChangesCommand = new RelayCommand(SaveChanges);
    }
    
    #region values

    private List<Customer> _listObjects;
    public List<Customer> ListObjects
    {
        get => _listObjects;
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
        if (IsEnabled)
        {
            if (_repository.GetConnectionString() == "")
                _repository.Customers[_repository.Customers.IndexOf(SelectedObject)] = SelectedObject;
            else
                Customer.Change(SelectedObject, _repository.GetConnectionString());
            
        }
        else
        {
            if (_repository.GetConnectionString() == "")
            {
                _repository.Customers.Add(SelectedObject);
                ListObjects = _repository.Customers;
            }
            else
            {
                Customer.Add(SelectedObject, _repository.GetConnectionString());
                ListObjects = Customer.GetAll(_repository.GetConnectionString());
            }
        }
    }
     
    #endregion
}