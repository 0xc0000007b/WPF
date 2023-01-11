using System;
using System.Windows.Input;

namespace WpfApp2.Infrastructure.Commands.Base;

public abstract class CommandBase : ICommand
{
     
    public abstract bool CanExecute(object? parameter = null);

    public abstract void Execute(object? parameter);

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}