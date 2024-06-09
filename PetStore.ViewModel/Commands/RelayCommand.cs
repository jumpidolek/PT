using System.Windows.Input;

namespace PetStore.ViewModel.Commands;

public class RelayCommand(Action<object> execute, Predicate<object> canExecute = null) : ICommand
{
    private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }
    
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}