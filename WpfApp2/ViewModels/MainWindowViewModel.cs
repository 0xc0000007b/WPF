using System.Windows;
using System.Windows.Input;
using WpfApp2.Infrastructure.Commands;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region ViewProperties

    private string _name;

    public string Name
    {
        get => _name; 
        set => SetField(ref _name, value);
    }
    
    private string _status = "Loading...";

    public string Status
    {
        get => _status; 
        set => SetField(ref _status, value);
    }
    
    #endregion

    #region Commands

    public ICommand ExitCommand { get; }

    private void OnExitCommand(object e)
    {
        Application.Current.Shutdown();
    }

    private bool CanExitCommand(object e) => true;

    #endregion
    public MainWindowViewModel()
    {
        ExitCommand = new Command(OnExitCommand,CanExitCommand);
    }
}
