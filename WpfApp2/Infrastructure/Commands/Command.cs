using System;
using WpfApp2.Infrastructure.Commands.Base;

namespace WpfApp2.Infrastructure.Commands;

public class Command : CommandBase
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public Command(Action<object> Execute, Func<object, bool> CanExecute = null)
    {
        _execute = Execute;
        _canExecute = CanExecute;
    }

    public override bool CanExecute(object? parameter = null) => _canExecute?.Invoke(parameter) ?? true;

    public override void Execute(object? parameter) => _execute(parameter);
}