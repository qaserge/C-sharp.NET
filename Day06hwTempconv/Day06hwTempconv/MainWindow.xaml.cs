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

namespace Day06hwTempconv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var checkedButton = container.Controls.OfType<RadioButton>()
            //                          .FirstOrDefault(r => r.Checked);

            //List<RadioButton> s
            //    list.FirstOrDefault(r => r.Checked)

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;

            // ... Display button content as title.
            this.Title = button.Content.ToString();
        }
    }
}
