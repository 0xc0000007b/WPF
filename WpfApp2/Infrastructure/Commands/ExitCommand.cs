using System;
using System.Windows;

namespace WpfApp2.Infrastructure.Commands;

public class ExitCommand : Command
{
    public ExitCommand(Action<object> Execute, Func<object, bool> CanExecute = null) : base(Execute, CanExecute)
    {
        Application.Current.Shutdown();
    }
}