using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
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
