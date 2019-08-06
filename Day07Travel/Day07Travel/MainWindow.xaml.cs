using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Day07Travel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Trip> tripsList = new List<Trip>();

        public MainWindow()
        {
            InitializeComponent();
            lvList.ItemsSource = tripsList;
            LoadDataFromFile();
        }

        private void AddTrip_Button_Click(object sender, RoutedEventArgs e)
        {
            string destanation = tbDestanation.Text;
            string name = tbName.Text;
            string passportInfo = tbPassportInfo.Text;
            string departTime = tbDepartTime.Text;
            string returnTime = tbReturnTime.Text;

            // FIXME: handle exception in setters, show message box on error
            Trip trip = new Trip() { Destanation = destanation, Name = name, PassportInfo = passportInfo, DepartTime = departTime, ReturnTime = returnTime };
            tripsList.Add(trip);
            lvList.Items.Refresh();

            AutoClosingMessageBox.Show("Added", "Caption", 1000);
            
        }

        private void SaveSelected_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                //https://stackoverflow.com/questions/2635226/how-to-save-the-listview-contents-to-a-text-file

                using (var tw = new StreamWriter(saveFileDialog.FileName))
                {                    
                    foreach (object item in lvList.Items)
                    {
                        tw.WriteLine(item.ToString());
                    }
                }
            }          




            AutoClosingMessageBox.Show("Saved", "Caption", 1000);

        }

        //private void CopyListViewItems(ListView from, ListView to)
        //{
        //    if (from.HasItems && from.SelectedItems != null)
        //    {
        //        var selected = from.SelectedItems.Cast<Object>().ToList();
        //        foreach (var item in selected)
        //        {
        //            to.Items.Add(item.ToString());
        //            from.Items.Remove(item);
        //        }
        //    }
        //}

        private void SaveDataToFile()
        {
            // TODO
            
        }

        private void LoadDataFromFile()
        {
            // TODO
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SaveDataToFile();
        }

        private void tbDestanation_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbErrorDestanation.Visibility = Trip.IsDestanationValid(tbDestanation.Text) ? Visibility.Hidden : Visibility.Visible;
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbErrorName.Visibility = Trip.IsNameValid(tbName.Text) ? Visibility.Hidden : Visibility.Visible;
        }

        private void tbPassportInfo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbDepartTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbReturnTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
