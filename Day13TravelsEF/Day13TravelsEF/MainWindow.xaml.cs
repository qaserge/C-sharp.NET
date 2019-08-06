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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day13TravelsEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static TravelDbContext ctx;

        public MainWindow()
        {
            ctx = new TravelDbContext(); // exceptions?

            InitializeComponent();

            //ListAllPassengersAndTheirTrains
            var passColl = from p in ctx.Passengers select p;
            foreach (Passenger p in passColl)
            {
                //Console.WriteLine(c);
                lvPassengers.Items.Add(p);
            }

            //list of trains
            var trainsColl = from t in ctx.Trains select t;
            foreach (Train t in trainsColl)
            {
                lvTrains.Items.Add(t);
                //Console.WriteLine(o); // display owner information
                //foreach (Passenger c in o.PassengersCollection)
                //{
                //    //Console.WriteLine(c);
                //    lvTrains.Items.Add(c);
                //}
            }




            //using (var ctx = new TravelDbContext())
            //{
            //    var ttrain = new Train() { Number = 112, Date = DateTime.Now };
            //    ctx.Trains.Add(ttrain);
            //    ctx.SaveChanges();

            //    var ppassenger = new Passenger() { Name = "Vasya Pupkin", Gender = "mujik" };
            //    ctx.Passengers.Add(ppassenger);
            //    ctx.SaveChanges();
            //}

        }

        private void AddPassengerNoTrain_MenuItemClick(object sender, RoutedEventArgs e)
        {
            //Console.Write("Enter make/model: ");
            //string makeModel = Console.ReadLine();
            //Console.Write("Enter year of production: ");
            //int yop = int.Parse(Console.ReadLine()); // FIXME
            //Car car = new Car() { MakeModel = makeModel, YearOfProd = yop };
            //ctx.Cars.Add(car);
            //ctx.SaveChanges();
            AddPassenger dialog = new AddPassenger(this);
            if (dialog.ShowDialog() == true)
            { // only refresh if data changed
                lvPassengers.Items.Refresh();
                var passColl = from p in ctx.Passengers select p;
                foreach (Passenger p in passColl)
                {
                    //Console.WriteLine(c);
                    lvPassengers.Items.Remove(p);
                    lvPassengers.Items.Add(p);
                }
            }
        }

        //private void RefreshPassengers_MenuItemClick(object sender, RoutedEventArgs e)
        //{
        //    var passColl = from p in ctx.Passengers select p;
        //    foreach (Passenger p in passColl)
        //    {
        //        //Console.WriteLine(c);
        //        lvPassengers.Items.Remove(p);
        //        lvPassengers.Items.Add(p);
        //    }
        //}

        private void AddTrainNoPassengers_MenuItemClick(object sender, RoutedEventArgs e)
        {
            AddTrain dialog = new AddTrain(this);
            if (dialog.ShowDialog() == true)
            { // only refresh if data changed
                lvTrains.Items.Refresh();
                var trainsColl = from t in ctx.Trains select t;
                foreach (Train t in trainsColl)
                {
                    //Console.WriteLine(c);
                    lvTrains.Items.Remove(t);
                    lvTrains.Items.Add(t);
                }
            }
        }

        private void AssignPassengerToATrain_MenuItemClick(object sender, RoutedEventArgs e)
        {
            AssignPassengerToATrain dialog = new AssignPassengerToATrain(this);
            if (dialog.ShowDialog() == true)
            { // only refresh if data changed
                lvPassengers.Items.Refresh();
                var passColl = from p in ctx.Passengers select p;
                foreach (Passenger p in passColl)
                {
                    //Console.WriteLine(c);
                    lvPassengers.Items.Remove(p);
                    lvPassengers.Items.Add(p);
                }
            }
        }

        private void DeletePassenger_MenuItemClick(object sender, RoutedEventArgs e)
        {
            Passenger passenger = lvPassengers.SelectedItem as Passenger;
            if (passenger == null) return; // should never happen
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?\n" + passenger, "Passenger", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            //if (result == MessageBoxResult.OK)
            //{
            //    try
            //    {
            //        Globals.Db.DeleteTodo(todo.Id);
            //        lvTodos.ItemsSource = Globals.Db.GetAllTodos(sortOrder);
            //        lblStatus.Content = "Todo is Deleted";
            //    }
            //    catch (SqlException ex)
            //    { // TODO: make message box nicer
            //        MessageBox.Show("Database error:\n" + ex.Message);
            //    }
            //}
        }

        private void DeleteTrain_MenuItemClick(object sender, RoutedEventArgs e)
        {
            Train train = lvTrains.SelectedItem as Train;
            if (train == null) return; // should never happen
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?\n" + train, "Train", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    //// 2. show all owners, choose an owner, empty means set owner to null
                    //ListAllOwnersAndTheirCars();
                    //Console.Write("Enter Id of an owner");
                    int trainId = train.Id; // FIXME
                    Train ttrain = ctx.Trains.Find(trainId);
                    if (ttrain == null)
                    {
                        MessageBox.Show("Train not found");
                        return;
                    }
                    //
                    foreach (Passenger c in ttrain.PassengersCollection.ToList<Passenger>())
                    {
                        ctx.Passengers.Remove(c); // schedule for deletion
                    }
                    ctx.Trains.Remove(ttrain);
                    ctx.SaveChanges();
                    MessageBox.Show("Train and their passengers deleted");
                }
                catch (SqlException ex)
                { // TODO: make message box nicer
                    MessageBox.Show("Database error:\n" + ex.Message);
                }   
            }

            //lvTrains.Items.Refresh();
            //lvPassengers.Items.Refresh();

            //---------------------------/

            //var trainsColl = from t in ctx.Trains select t;
            //foreach (Train t in trainsColl)
            //{
            //    //Console.WriteLine(c);
            //    lvTrains.Items.Remove(t);
            //    lvTrains.Items.Add(t);
            //}
            //var passColl = from p in ctx.Passengers select p;
            //foreach (Passenger p in passColl)
            //{
            //    //Console.WriteLine(c);
            //    lvPassengers.Items.Remove(p);
            //    lvPassengers.Items.Add(p);
            //}
        }
    }
}
