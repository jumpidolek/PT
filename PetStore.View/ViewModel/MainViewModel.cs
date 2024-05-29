using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using PetStore.Model;
using PetStore.Model.Users;
using PetStore.Service;
using PetStore.View.ViewModel.Commands;

namespace PetStore.View.ViewModel;

public class MainViewModel : INotifyPropertyChanged, INotifyCollectionChanged
{
    #region property changed

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T? field, T? value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion

    #region collection changed

    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    
    protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, object? item = null, int index = -1)
    {
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item, index));
    }
    
    protected bool SetField<T>(ref List<T>? field, List<T>? value, [CallerMemberName] string? propertyName = null)
    {
        if (field == value) return false;
        field = value;
        OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        OnPropertyChanged(propertyName);
        return true;
    }
    
    #endregion

    #region values

    private List<Customer>? _listObjects = [];
    public List<Customer>? ListObjects
    {
        get => _listObjects;
        set => SetField(ref _listObjects, value);
    }
    
    private Data.Customer? _selectedObject;
    public Data.Customer? SelectedObject
    {
        get => _selectedObject;
        set => SetField(ref _selectedObject, value);
    }

    private string _id = "";
    public string Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }
    
    private string _firstName = "";
    public string FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }
    
    private string _lastName = "";
    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    private DateTime _birthDate;
    public DateTime BirthDate
    {
        get => _birthDate;
        set => SetField(ref _birthDate, value);
    }
    
    private string _email = "";
    public string Email
    {
        get => _email;
        set => SetField(ref _email, value);
    }
    
    private string _phone = "";
    public string Phone
    {
        get => _phone;
        set => SetField(ref _phone, value);
    }
    
    private string _address = "";
    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }
    
    private string _deliveryAddress = "";
    public string DeliveryAddress
    {
        get => _deliveryAddress;
        set => SetField(ref _deliveryAddress, value);
    }
    
    private string _billingInformation = "";
    public string BillingInformation
    {
        get => _billingInformation;
        set => SetField(ref _billingInformation, value);
    }
    
    #endregion

    #region commands
    
    public ICommand ShowListCommand { get; set; }
    public ICommand ShowObjectCommand { get; set; }
    
    private void ShowList(object obj)
    {
        Task.Run(() =>
        {
            ListObjects!.Clear();
            ListObjects.AddRange(new UserService().GetCustomers());
        });
    }
    
    private void ShowObject(object obj)
    {
        //DockPanelChildren = new List<UcCustomers> { Task.Run(() => new UserService().GetCustomer(SelectedObject.Id)) };
    }
    
    #endregion
    
    public MainViewModel()
    {
        new UserService().AddCustomer(new Customer
        {
            FirstName = "Piotr",
            LastName = "Kowalski",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "aaaa@gmail.com",
            Phone = "123456789",
            Address = "ul. Kowalska 1",
            DeliveryAddress = "ul. Kowalska 1",
            BillingInformation = "credit card"
        });
        
        ShowListCommand = new RelayCommand(ShowList);
        ShowObjectCommand = new RelayCommand(ShowObject);
    }
}