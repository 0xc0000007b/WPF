using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Data;
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

    #region GroupCollection

    public ObservableCollection<Group> Groups { get; set; }

    #region Gruop Selection

    private Group _selectedGroup;

    public Group SelectedGroup
    {
        get => _selectedGroup;

        set
        {
            if (!SetField(ref _selectedGroup,value))return;
            _collectionViewStudents.Source = value?.Students;
            OnPropertyChanged(nameof(SelectedGroupStudents));
        }
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

        #region Add Or delete group from list

        public ICommand CreateNewGroupCommand { get; }


        private void OnCreateNewGroupCommand(object e)
        {
            var maxGroupCount = Groups.Count + 1;
            var newGroup = new Group
            {
                Name = $"group {maxGroupCount}",
                Students = new ObservableCollection<Students>()
            };
            Groups.Add(newGroup);
        }

        private bool CanCreateNewGroupCommand(object e) => true;


        public ICommand DeleteGroupCommand { get; }

        private void OnDeleteGroupCommand(object e)
        {
            if (!(e is Group group)) return;
            var index = Groups.IndexOf(group);
            Groups.Remove(group);
            if (index < Groups.Count) SelectedGroup = Groups[index];
           
        }

        private bool CanDeleteGroupCommand(object e) => e is Group group  && Groups.Contains(group);
        

        #endregion
    #endregion
    
    public ICommand ExitCommand { get; }

    private void OnExitCommand(object e)
    {
        Application.Current.Shutdown();
    }

    private bool CanExitCommand(object e) => true;

    #endregion

    #region Selected Student View


    private string _studentsFiltertext;

    public string StudentFilterText
    {
        get => _studentsFiltertext;

        set
        {
            if(!SetField(ref _studentsFiltertext, value)) return;
            _collectionViewStudents.View.Refresh();
            
        }
    }

    private readonly CollectionViewSource _collectionViewStudents = new CollectionViewSource();
    
    public ICollectionView SelectedGroupStudents => _collectionViewStudents?.View;
    
    
    
    private void OnStuderntsFilter(object sender, FilterEventArgs e)
    {
        
        if(!(e.Item is Students student))
        {
            e.Accepted = false;
            return;
        }
        var textFilter = _studentsFiltertext;
        if (string.IsNullOrWhiteSpace(textFilter))return;
        if (student.Name is null || student.Surname is null || student.Patronymic is null)
        {
            e.Accepted = false;
            return;
        }

        if (student.Name.Contains(textFilter, StringComparison.OrdinalIgnoreCase) || student.Surname.Contains(textFilter, StringComparison.OrdinalIgnoreCase) || student.Patronymic.Contains(textFilter, StringComparison.OrdinalIgnoreCase))return;
        e.Accepted = false;

    }

   
    
    #endregion

    #region Some crap

    public IEnumerable<Students> Students =>  
        Enumerable.Range(0,App.IsDesignMode ? 10 : 10000).Select(i => new Students
        {
            Name = $"{i}",
            Surname = $"{i}"
        });

    #endregion

    #region Statistics

    public  StatisticsViewModel CountryStatistic { get; }
    

    #endregion
    
    public MainWindowViewModel()
    {
        #region Commands

        ExitCommand = new Command(OnExitCommand,CanExitCommand);
        ChangeTabIndex = new Command(OnChangeTabIndexCommandExecuted, CanChangeTabIndex);
        CreateNewGroupCommand = new Command(OnCreateNewGroupCommand, CanCreateNewGroupCommand);
        DeleteGroupCommand = new Command(OnDeleteGroupCommand, CanDeleteGroupCommand);

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
            Students = new ObservableCollection<Students>(students),
            Description = $"group {g}"
        });
        Groups = new ObservableCollection<Group>(groups);
        
        
        

        #endregion

        #region Data Types

        var dataPoints = new List<DataPoints>((int)(360 / 0.5));
        for (var x = 0d; x <= 360; x+= .1)
        {
            const double rad = Math.PI / 100; 
            var y = Math.Sin( x  * rad);
            
            dataPoints.Add(new DataPoints{XValue = x, YValue = y});
        }

        _testData = dataPoints;

        #endregion


        #region Country statistic

        CountryStatistic = new StatisticsViewModel(this);

        #endregion
       
        
        
        _collectionViewStudents.Filter += OnStuderntsFilter;
       // _collectionViewStudents.SortDescriptions.Add(new SortDescription("Surname", ListSortDirection.Descending));
    }

   
}
