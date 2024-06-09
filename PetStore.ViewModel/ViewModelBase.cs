using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetStore.ViewModel;

public class ViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged
{
    #region property changed

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
    
    #region collection changed

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    private void OnCollectionChanged(NotifyCollectionChangedAction action, object item = null, int index = -1)
    {
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item, index));
    }

    protected bool SetField<T>(ref List<T> field, List<T> value, [CallerMemberName] string propertyName = null)
    {
        if (field == value) return false;
        field = value;
        OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        OnPropertyChanged(propertyName);
        return true;
    }
    
    #endregion
}