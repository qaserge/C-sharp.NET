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

namespace Day08TODOadvancedDB
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
                lvListToDo.ItemsSource = Globals.Db.GetAllToDos();
            }
            catch (SqlException ex)
            { // TODO: make message box nicer
                MessageBox.Show("Database error:\n" + ex.Message);
                Close(); // Fatal error - exit application
            }
        }

        private void AddUpdateToDo_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Boolean isUpdating = (button.Name == "btUpdateToDo");

            string task = tbTask.Text;
            string status;
            if (rbPending.IsChecked == true)
                status = rbPending.Content.ToString();            
            else
                status = rbDone.Content.ToString();                        
            string duedate = datePicker.Text;
            
            try
            {
                if (isUpdating)
                {
                    ToDo todo = lvListToDo.SelectedItem as ToDo;
                    if (todo == null) return; // should never happen - internal error
                    todo.Task = task;
                    todo.Status = status;
                    todo.DueDate = duedate;
                    Globals.Db.UpdateToDo(todo);
                }
                else
                { // adding
                    ToDo todo = new ToDo() { Task = task, Status = status, DueDate=duedate };
                    Globals.Db.AddToDo(todo);
                }
                tbTask.Text = "";
                //if (rbPending.IsChecked == true)
                //    rbPending.Content = "";
                //else
                //rbDone.Content = "";
                datePicker.Text = "";
                lvListToDo.ItemsSource = Globals.Db.GetAllToDos();
            }
            catch (SqlException ex)
            { // TODO: make message box nicer
                MessageBox.Show("Database error:\n" + ex.Message);
            }
        }

        private void BtDeleteToDo_Click(object sender, RoutedEventArgs e)
        {
            ToDo todo = lvListToDo.SelectedItem as ToDo;
            if (todo == null) return; // should never happen - internal error
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?\n" + todo, Globals.AppName, MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    Globals.Db.DeleteToDo(todo.Id);
                    lvListToDo.ItemsSource = Globals.Db.GetAllToDos();
                }
                catch (SqlException ex)
                { // TODO: make message box nicer
                    MessageBox.Show("Database error:\n" + ex.Message);
                }
            }
        }

        private void LvListToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDo todo = lvListToDo.SelectedItem as ToDo;
            if (todo == null)
            {
                // disable update and delete buttons
                btUpdateToDo.IsEnabled = false;
                btDeleteToDo.IsEnabled = false;
                return;
            }
            // enable update and delete buttons, load data
            btUpdateToDo.IsEnabled = true;
            btDeleteToDo.IsEnabled = true;
            lblId.Content = todo.Id;
            tbTask.Text = todo.Task;
            //if (rbPending.IsChecked == true)
            //    rbPending.Content = todo.Status;
            //else
            //rbDone.Content = todo.Status;  
            datePicker.Text = todo.DueDate;
        }
    }
}
