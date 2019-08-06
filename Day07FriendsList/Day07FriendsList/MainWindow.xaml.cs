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

namespace Day07FriendsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Friend> friendsList = new List<Friend>();

        public MainWindow()
        {
            InitializeComponent();
            lvFriends.ItemsSource = friendsList;
        }

        private void AddFriend_ButtonClick(object sender, RoutedEventArgs e)
        {
            //lvFriends.Items.Add(tbName.Text);

            string name = tbName.Text;
            int age = int.Parse(tbAge.Text);
            Friend friend = new Friend() { Name = name, Age = age };
            friendsList.Add(friend);
            lvFriends.Items.Refresh();
        }

        private void SaveDataToFile()
        {

        }

        private void LoadDataFromFile()
        {

        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbErrorName.Visibility = Friend.IsNameValid(tbName.Text) ? Visibility.Hidden : Visibility.Visible;
        }

        private void tbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lbErrorAge.Visibility = Friend.IsNameValid(tbAge.Text) ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
