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

namespace Day06AllInputs
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\MyTest.txt";
            
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"Name: {tbName.Text}");
                //sw.WriteLine($"Name is {cmbCont.Text}");


                // radio buttons
                if (rb18.IsChecked == true) 
                sw.WriteLine($"Age: {rb18.Content.ToString()}");
                else if (rb1835.IsChecked == true)
                sw.WriteLine($"Age: {rb1835.Content.ToString()}");
                else if (rb35.IsChecked == true)
                sw.WriteLine($"Age: {rb35.Content.ToString()}");
                else sw.WriteLine($"Age not specified");

                //comboBox
                sw.WriteLine($"Continent: {cmbCont.Text}");

                //check boxes
                List<string> CheckBoxList = new List<string>();
                if (cbCat.IsChecked == true) CheckBoxList.Add(cbCat.Content.ToString());
                if (cbDog.IsChecked == true) CheckBoxList.Add(cbDog.Content.ToString());
                if (cbOther.IsChecked == true) CheckBoxList.Add(cbOther.Content.ToString());                                
                string pets = string.Join(",", CheckBoxList);
                sw.WriteLine($"Pets: {pets}");

                //slider
                sw.WriteLine($"Preferred temperature: {tbTemp.Text}");

                sw.WriteLine($"-------------------------------------------");

            }
            

            tblData.Text = "Registered!";

        }
    }
}
