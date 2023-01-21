using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using WpfApp2.Infrastructure.Commands;
using WpfApp2.Models;
using WpfApp2.Services;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class StatisticsViewModel : ViewModelBase
{

    private readonly DataService _dataService;
    private  MainWindowViewModel _mainWindowViewModel { get; }

    #region Commands

    public ICommand RefreshStatistics { get; }

    private void OnRefreshStatistics(object e)
    {
        Countries = _dataService.GetData();
    }

    private bool CanRefreshStatistics(object e) => true;

    #endregion

    #region Country Selection

    private Country _selectedCountry;

    public Country  SelectedCountry
    {
        get => _selectedCountry;

        set => SetField(ref _selectedCountry, value);
    }
    

    #endregion


    #region getting countries

    private IEnumerable<Country> _countries;

    public IEnumerable<Country> Countries
    {
        get => _countries;

        private set => SetField(ref _countries, value);
    }
    

    #endregion
    /// <summary>
    /// Debug constructor for designer
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public StatisticsViewModel() : this(null)
    {
        if (App.IsDesignMode) throw new InvalidOperationException("only for MS VS od JB Rider Designer");
        _countries = Enumerable.Range(1, 15).Select(c => new Country
        {
            Name = $"Name {c}",
            Province = Enumerable.Range(1,10).Select(p => new PlaceInfo
            {
                Name = $"Province {p}",
                Location = new Point(1, c),
                Count = Enumerable.Range(1,10).Select(i => new ConfirmrdCounts
                {
                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(150 - i)),
                    Count = i.ToString()
                }).ToArray()
            }).ToArray()
        }).ToArray();
    }
    
    
    public StatisticsViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _dataService = new DataService();
        RefreshStatistics = new Command(OnRefreshStatistics, CanRefreshStatistics);
    }
}