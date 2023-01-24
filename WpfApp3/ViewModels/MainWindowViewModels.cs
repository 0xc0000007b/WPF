using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PhonesBook;
using WpfApp3.Commands;

namespace WpfApp3.ViewModels;

public class MainWindowViewModels : ViewModelBase
{
    private string _name;

    public string Name
    {
        get => _name;

        set => SetField(ref _name, value);
    }

    private string _surName;

    public string Surname
    {
        get => _name;

        set => SetField(ref _name, value);
    }

    private string _phoneNumber;

    public string PhoneNumber
    {
        get => _name;

        set => SetField(ref _name, value);
    }
    public ObservableCollection<PhoneBook> PhoneBook { get; set; }
    private PhoneBookDbContext _db;
    public ICommand AddPhoneToDB { get; }

    private void OnAddPhone(object e)
    {
        PhoneBook phone = new PhoneBook
        {

            Name = Name,
            Surname = Surname,
            PhoneNumber = PhoneNumber
        };
            
           _db.Add(phone);
            _db.SaveChanges();
       
        
       
    }

    private bool CanAddPhoneToBase(object e) => true;

    public ICommand DeletePhone { get; }

    private void OnDeletePhone(object e)
    {
        PhonesBook.PhoneBook phone = _db.Phones.FirstOrDefault();
        if (phone != null)
        {
            _db.Remove(phone);
            _db.SaveChanges();
        }
    }

    public ICommand ExportDataBaseToCSV { get; }

    private void OnExportDataBaseToCSV(object e)
    {
    }

    private bool CanExportDataBaseToCSV(object e) => true;

    private bool CanDeletePhone(object e) => true;

    
    public MainWindowViewModels()
    {
        _db = new PhoneBookDbContext();
        AddPhoneToDB = new Command(OnAddPhone, CanAddPhoneToBase);
        DeletePhone = new Command(OnDeletePhone, CanDeletePhone);
    }
}