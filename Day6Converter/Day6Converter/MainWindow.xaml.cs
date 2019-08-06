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

namespace Day6Converter
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

        private void btConvert(object sender, RoutedEventArgs e)
        {            
            string celStr = tbCelsius.Text;   
                if (!double.TryParse(tbCelsius.Text, out double cel))
                {
                    MessageBox.Show("Error double parsing", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
                }
                double far = (cel * 9) / 5 + 32;
                lblFahrenheit.Content = $"{cel} Celsius = {far:0.00} fahrenheit"; 
        }
    }
}
