using WpfApp2.Services;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class StatisticsViewModel : ViewModelBase
{

    private DataService _dataService;
    private  MainWindowViewModel _mainWindowViewModel { get; }

    public StatisticsViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _dataService = new DataService();
    }
}