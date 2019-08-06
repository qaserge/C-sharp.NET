using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02FirstLinq
{
    class Program
    {
        //array list declaration
        static List<string> NamesList = new List<string>();



        static void Main(string[] args)
        {
            try
            {
                // create the loop for puting the names into list
                while (true)
                {
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();
                    // condition if user put impty string
                    if (name == "")
                    {
                        break;
                    }
                    NamesList.Add(name);
                }
                Console.Write("Enter search string: ");
                string search = Console.ReadLine().ToUpper();
                //
                //var foundList = from n in namesList where n.ToUpper().Contains(search) select n;
                //or:
                var foundList = NamesList.Where(n => n.ToUpper().Contains(search));
                Console.WriteLine("Matching names: ");

                foreach(string name in foundList)
                {
                    Console.WriteLine(name);
                }

                //namesList.Sort();
                //Console.WriteLine("sorted list: ");
                //foreach (string name in namesList)
                //{
                //    Console.WriteLine(name);
                //}

                //or

                var sortedList = from n in NamesList orderby n select n;
                Console.WriteLine("Sorted names:");
                foreach (string name in sortedList)
                {
                    Console.WriteLine(name);
                }

            }
            finally
            {
                Console.WriteLine("Press any key for exit");
                Console.ReadLine();
            }
            

        }
    }
}
