using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Day06Notepad
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

        private void FileExit_MenuClick(object sender, RoutedEventArgs e)
        {
            Close(); // закрывает все окна
            //this.Close(); // закрывает текущее            
        }

        private void FileNew_MenuClick(object sender, RoutedEventArgs e)
        {
            tbEditor.Text = "";            
        }

        private void FileOpen_MenuClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                    tbEditor.Text = File.ReadAllText(openFileDialog.FileName);
                sbStatus.Text = openFileDialog.FileName; // показывает путь файла
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading" + ex.Message);
            }
        }

        private void FileSave_MenuClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, tbEditor.Text);
            sbStatus.Text = saveFileDialog.FileName; // показывает путь файла
        }
    }
}
