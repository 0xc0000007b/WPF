using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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

    #region GrupCollection

    public ObservableCollection<Group> Groups { get; set; }

    #region Gruop Selection

    private Group _selectedGroup;

    public Group SelectedGroup
    {
        get => _selectedGroup;

        set => SetField(ref _selectedGroup, value);
    }

    #endregion

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
        #region Commands

        ExitCommand = new Command(OnExitCommand,CanExitCommand);
        ChangeTabIndex = new Command(OnChangeTabIndexCommandExecuted, CanChangeTabIndex);

        #endregion

        #region Gropus

        var student = 1;
        var students = Enumerable.Range(1, 10).Select(s => new Students
        {
            Name = $"Name {student}",
            Surname = $"Surname {student}",
            Patronymic = $"patronymic {student}",
            Birthday = DateTime.Now,
            Rating = new Random().NextDouble(),
            Description = $"student {student++} description"
        });
        
        var groups = Enumerable.Range(1, 20).Select(g => new Group
        {
            Name = $"Group {g}",
            StudentsCount = new ObservableCollection<Students>(students)
        });
        Groups = new ObservableCollection<Group>(groups);
        
        
        

        #endregion
        
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
