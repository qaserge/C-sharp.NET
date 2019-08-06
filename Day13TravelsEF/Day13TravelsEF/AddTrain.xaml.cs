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
    /// Interaction logic for AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Window
    {
        MainWindow mw;

        public AddTrain(MainWindow owner)
        {
            mw = owner;
            Owner = owner;
            InitializeComponent();
        }

        private void Add_ButtonClick(object sender, RoutedEventArgs e)
        {            
            int number = int.Parse(tbNumber.Text);
            DateTime date = DateTime.Parse(dpDate.Text);
            var ctx = new TravelDbContext();

            Train train = new Train() { Number = number, Date = date };
            ctx.Trains.Add(train);
            ctx.SaveChanges();

            DialogResult = true; // close dialog
        }
    }
}
