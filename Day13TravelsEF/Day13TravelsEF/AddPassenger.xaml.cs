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
using System.Windows.Shapes;

namespace Day13TravelsEF
{
    /// <summary>
    /// Interaction logic for AddPassenger.xaml
    /// </summary>
    public partial class AddPassenger : Window
    {
        MainWindow mw;

        public AddPassenger(MainWindow owner)
        {
            mw = owner;
            Owner = owner;
            InitializeComponent();
        }

        private void Add_ButtonClick(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string gender = tbGender.Text;
            var ctx = new TravelDbContext();

            //Console.Write("Enter make/model: ");
            //string makeModel = Console.ReadLine();
            //Console.Write("Enter year of production: ");
            //int yop = int.Parse(Console.ReadLine()); // FIXME
            Passenger passenger = new Passenger() { Name = name, Gender = gender };
            ctx.Passengers.Add(passenger);
            ctx.SaveChanges();            

            DialogResult = true; // close dialog
        }
    }
}
