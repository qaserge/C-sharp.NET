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

namespace Day10Passengers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Globals.Db = new Database();
                lvPassengers.ItemsSource = Globals.Db.GetAllPassengers();
            }
            catch (SystemException ex) //(SqlException ex)
            { // TODO: make message box nicer
                MessageBox.Show("Database error:\n" + ex.Message);
                Close(); // Fatal error - exit application
            }
        }

        private void AddPassenger_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddPassenger dialog = new AddPassenger(this);
            if (dialog.ShowDialog() == true)
            {
                lvPassengers.ItemsSource = Globals.Db.GetAllPassengers();
            }
        }
    }
}
