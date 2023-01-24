
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PhonesBook;


namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private PhonesBook.PhoneBookDbContext _phoneBook;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddNumber_OnClick(object sender, RoutedEventArgs e)
        {
            PhoneBook phone = new PhoneBook
            {

                Name = Name.Text,
                Surname = Surname.Text,
                PhoneNumber = this.phone.Text
            };
            
            if (phone.Name != null && phone.Surname != null && phone.PhoneNumber.Length > 6)
            {
                _phoneBook.Add(phone);
                _phoneBook.SaveChanges();
            }
            else
            {
                MessageBox.Show("Имя, Фамилия и номер пользователя\nне соответвуютствуют разрешенным", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
                MessageBox.Show("Имя и Фамилия не могут быть пустыми\nМинимальная длина номера 6 знаков", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ButtonDeleteNumber_OnClick(object sender, RoutedEventArgs e)
        {
            PhoneBook? phone = _phoneBook.Phones.FirstOrDefault();
            if (phone != null)
            {
                _phoneBook.Phones.Remove(phone);
                _phoneBook.SaveChanges();
            }

            dGrid.ItemsSource = _phoneBook.Phones.Local.ToObservableCollection();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            _phoneBook = new PhoneBookDbContext();
            _phoneBook.Phones.Load();
            dGrid.ItemsSource = _phoneBook.Phones.Local.ToObservableCollection();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string fullpath = @"files.csv";
            dGrid.SelectAllCells();
 
            dGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dGrid);
 
            dGrid.UnselectAllCells();
            string result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
 
            File.AppendAllText(fullpath, result, UnicodeEncoding.Default);
            MessageBox.Show("Я подебил", "All Done", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

    
     
    }
}
