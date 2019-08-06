using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Day10Passengers
{
    /// <summary>
    /// Interaction logic for AddPassenger.xaml
    /// </summary>
    public partial class AddPassenger : Window
    {
        MainWindow mw;

        public AddPassenger(MainWindow owner)
        {
            InitializeComponent();
            mw = owner;
            Owner = owner;

            cbDepartTime.Items.Clear();
            for (int hour =0; hour < 24; hour++)
            {
                cbDepartTime.Items.Add($"{hour:00}:00");
                cbDepartTime.Items.Add($"{hour:00}:30");
            }
            //cbDepartTime.SetCurrentValue = "00:00";
        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            

            try
            {   // add/update database records
                string name = tbName.Text;
                string passport = tbPassport.Text;
                string destination = tbDestination.Text;
                DateTime departTime = DateTime.Parse(cbDepartTime.Text);
                DateTime departDate = dpDepartDate.SelectedDate.Value.Date.Add(departTime.TimeOfDay);

                //string timeList = "00:30";
                //Passenger passenger = new Passenger() { TimeList = timeList };

                //DateTime dateOnly;
                //    DateTime timeOnly;
                //    ...
                //    DateTime combined = dateOnly.Date.Add(timeOnly.TimeOfDay); 



                Globals.Db.AddPassenger(new Passenger() { Name = name, Destination = destination, Passport = passport, DepartDate = departDate });
                DialogResult = true; // close dialog
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Internal error: unknown fuel type value");
                return;
            }
        }

        private void Delete_ButtonClick(object sender, RoutedEventArgs e)
        {
            //Globals.Db.DeletePassenger(new Passenger() { Id=id});
            Passenger passenger = mw.lvPassengers.SelectedItem as Passenger;
            if (passenger == null) return; // should never happen
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?\n" + passenger, Globals.AppName, MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    Globals.Db.DeletePassenger(passenger.Id);
                    mw.lvPassengers.ItemsSource = Globals.Db.GetAllPassengers();
                }
                catch (SqlException ex)
                { // TODO: make message box nicer
                    MessageBox.Show("Database error:\n" + ex.Message);
                }
            }
        }
    }
}
