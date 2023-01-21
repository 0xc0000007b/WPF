using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp2.Infrastructure.Commands;
using WpfApp2.Models;
using WpfApp2.Services;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class StatisticsViewModel : ViewModelBase
{

    private DataService _dataService;
    private  MainWindowViewModel _mainWindowViewModel { get; }

    #region Commands

    public ICommand RefreshStatistics { get; }

    private void OnRefreshStatistics(object e)
    {
        Countries = _dataService.GetData();
    }

    private bool CanRefreshStatistics(object e) => true;

    #endregion

    private IEnumerable<Country> _countries;

    public IEnumerable<Country> Countries
    {
        get => _countries;

        private set => SetField(ref _countries, value);
    }
    
    public StatisticsViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _dataService = new DataService();
        RefreshStatistics = new Command(OnRefreshStatistics, CanRefreshStatistics);
    }
}