using System.Windows.Input;
using PetStore.Model.Models.Users;
using PetStore.ViewModel.Commands;

namespace PetStore.ViewModel;

public sealed class MainViewModel : ViewModelBase
{
    private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;";
    private readonly List<Customer> _customers;
    
    public MainViewModel(List<Customer> customers = null)
    {
        ChangeModeCommand = new RelayCommand(ChangeMode);
        SaveChangesCommand = new RelayCommand(SaveChanges);
        _customers = customers;
    }
    
    #region values

    private List<Customer> _listObjects = [];
    public List<Customer> ListObjects
    {
        get => _listObjects = _customers ?? Customer.GetAll(ConnectionString);
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
        if (IsEnabled) Customer.Change(SelectedObject, ConnectionString);
        else
        {
            Customer.Add(SelectedObject, ConnectionString);
            ListObjects = Customer.GetAll(ConnectionString);
        }
    }
    
    #endregion
}