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

namespace Day09hwSandwich
{
    /// <summary>
    /// Interaction logic for Ingredients.xaml
    /// </summary>
    public partial class Ingredients : Window
    {      

        public Ingredients(Window owner)
        {
            Owner = owner;
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            Globals.bread = cbBread.Text;

            List<string> vegetablesList = new List<string>();

            if ((cbLettuce.IsChecked == true) || (cbTomatoes.IsChecked == true) || (cbCucumbers.IsChecked == true))
            { 
                if (cbLettuce.IsChecked == true)
                {
                    vegetablesList.Add("Lettuce");
                }
                if (cbTomatoes.IsChecked == true)
                {
                    vegetablesList.Add("Tomatoes");
                }
                if (cbCucumbers.IsChecked == true)
                {
                    vegetablesList.Add("Cucumbers");
                }
                Globals.vegetables = String.Join(",", vegetablesList);
            }
            else
            {
                Globals.vegetables = "not selected";
            }
            
            if (rbBeef.IsChecked == true)
            {
                Globals.meat = rbBeef.Content.ToString();
            }
            else if (rbChiken.IsChecked == true)
            {
                Globals.meat = rbChiken.Content.ToString();
            }
            else if (rbPork.IsChecked == true)
            {
                Globals.meat = rbPork.Content.ToString();
            }
            else
            {
                Globals.meat = "not selected";
            }
            
            DialogResult = true;
        }
    }
}
