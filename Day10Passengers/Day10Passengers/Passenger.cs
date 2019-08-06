using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Day10Passengers
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //{

        //    get { return Name; }
        //    set
        //    {
        //        if (value.Length < 2 || value.Length > 50 || value.Contains(";"))
        //        {
        //            //throw new InvalidDataException("Name must be 2-50 characters long, no semicolons");
        //            MessageBox.Show("Name must be 2-50 characters long, no semicolons");

        //        }
        //        Name = value;
        //    }
        //}


        public string Passport { get; set; }
        public string Destination { get; set; }
        public DateTime DepartDate { get; set; }
        public string DepartTime { get; set; }

        public string TimeList { get; set; }
    }
}
