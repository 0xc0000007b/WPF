using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupCollection_OnFilter(object sender, FilterEventArgs e)
        {
            if(!(e.Item is Group g)) return;
            if(g.Name is null) return;
            var filterText = FilterBox.Text;
            if (filterText.Length == 0) return;
            if(g.Name.Contains(filterText,StringComparison.OrdinalIgnoreCase))return;
            if(g.Description != null && g.Description.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            e.Accepted = false;
        }

        private void OnGroupFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var collection = (CollectionViewSource)textBox.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}