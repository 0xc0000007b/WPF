using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using OxyPlot;
using WpfApp2.Infrastructure.Commands;
using WpfApp2.Models;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Graphic

    private IEnumerable<DataPoints> _testData;

    public IEnumerable<DataPoints> TestData
    {
        get => _testData;

        set => SetField(ref _testData, value);
    }

    #endregion
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

    #region SelectedTabCount

    private int _selectedTabIndex;

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;

        set => SetField(ref _selectedTabIndex, value);
    }

        public ICommand ChangeTabIndex { get; }

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if(p is null) return;
            SelectedTabIndex +=Convert.ToInt32(p);
        }

        private bool CanChangeTabIndex(object e) => true;
   
    #endregion
    
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
        ChangeTabIndex = new Command(OnChangeTabIndexCommandExecuted, CanChangeTabIndex);
        var dataPoints = new List<DataPoints>((int)(360 / 0.5));
        for (var x = 0d; x <= 360; x+= .1)
        {
            const double rad = Math.PI / 100; 
            var y = Math.Sin( x  * rad);
            
        dataPoints.Add(new DataPoints{XValue = x, YValue = y});
        }

        _testData = dataPoints;

    }
}
