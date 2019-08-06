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

namespace Day6Hello
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

        private void ButtonSayHelloWithMB_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string greeting = $"Hello {name}, nice to meet you!";
            MessageBoxResult result = MessageBox.Show(greeting, "Title of MessageBox", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Hello to you too!", "My App");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }
        }

        private void ButtonSayHelloWithLabel_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            lblGreeting.Content = $"Hello {name}, nice to meet you!";
        }
    }
}
