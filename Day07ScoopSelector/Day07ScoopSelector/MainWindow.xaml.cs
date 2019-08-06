using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day07ScoopSelector
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

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            CopyListViewItems(lvLeft, lvRight);

            lblError.Visibility = Visibility.Visible;

            //ListViewItem item = lvLeft.SelectedItem as ListViewItem;
            ////Console.WriteLine("Item selected is: " + item);
            //lvRight.Items.Add(item.Content); // add string to right list

        }

        private void DeleteScoop_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteListViewItems(lvRight);
        }

        private void ClearAll_Button_Click(object sender, RoutedEventArgs e)
        {
            //myListView.DataSource = null;
            lvRight.Items.Clear();
        }

        private void AddNewItem_Button_Click(object sender, RoutedEventArgs e)
        {
            lvLeft.Items.Add(tbFlavour.Text);
        }

        private void CopyListViewItems(ListView from, ListView to)
        {
            if (from.HasItems && from.SelectedItems != null)
            {
                var selected = from.SelectedItems.Cast<Object>().ToList();
                foreach (var item in selected)
                {
                    to.Items.Add(item.ToString());
                    //from.Items.Remove(item);
                }
            }
        }
        private void DeleteListViewItems(ListView from)
        {
            if (from.HasItems && from.SelectedItems != null)
            {
                var selected = from.SelectedItems.Cast<Object>().ToList();
                foreach (var item in selected)
                {
                    //to.Items.Add(item.ToString());
                    from.Items.Remove(item);
                }
            }
        }
    }
}
