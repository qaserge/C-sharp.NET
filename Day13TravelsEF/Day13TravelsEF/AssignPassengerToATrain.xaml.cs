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
    /// Interaction logic for AssignPassengerToATrain.xaml
    /// </summary>
    public partial class AssignPassengerToATrain : Window
    {
        MainWindow mw;

        public AssignPassengerToATrain(MainWindow owner)
        {
            mw = owner;
            Owner = owner;
            InitializeComponent();
        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            var ctx = new TravelDbContext();
            //// 1. show all the cars with their Ids, choose a car
            //ListAllCarsAndTheirOwners();
            //Console.Write("Enter Id of a car: ");
            int passengerId = int.Parse(tbPassengerId.Text); // FIXME
            // Car car = (from c in ctx.Cars where c.Id == carId select c).FirstOrDefault<Car>();
            Passenger passenger = ctx.Passengers.Find(passengerId);
            if (passenger == null)
            {
                MessageBox.Show("Passenger not found");
                return;
            }
            // 2. show all owners, choose an owner, empty means set owner to null
            //ListAllOwnersAndTheirCars();
            //Console.Write("Enter Id of an owner, -1 to set null: ");
            int trainId = int.Parse(tbTrainId.Text); // FIXME
            Train train = null;
            if (trainId != -1)
            {
                train = ctx.Trains.Find(trainId);
                if (train == null)
                {
                    MessageBox.Show("Train not found");
                    return;
                }
            }
            //
            passenger.Train = train; // modify the entity
            ctx.SaveChanges();
            //Console.WriteLine("owner change saved");
            DialogResult = true; // close dialog
        }
    }
}
