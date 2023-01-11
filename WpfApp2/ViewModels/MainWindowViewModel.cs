using System.Windows;
using System.Windows.Input;
using WpfApp2.Infrastructure.Commands;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _name;

    public string Name
    {
        get => _name; 
        set => SetField(ref _name, value);
    }
    public MainWindowViewModel()
    {
        ExitCommand = new Command(OnExitCommand,CanExitCommand);
    }

    public ICommand ExitCommand { get; }

    private void OnExitCommand(object e)
    {
        Application.Current.Shutdown();
    }

    private bool CanExitCommand(object e) => true;
}