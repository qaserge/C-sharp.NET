using System;
using System.Collections.Generic;

namespace Day01Names
    //Create new project in called Day01Names.
    //Declare List<Strings> as nameList.
    //In a loop ask user for a name.
    //If name is not empty add name to the list and continue to next iteration of the loop.
    //If name is empty - exit the loop.
    //After loop is done print out all the names, one per line.
{
    public class Name
    {
        public string Names { get; set; }

        public override string ToString()
        {
            return " Name: " + Names;
        }
    }
    public class Test
    {
        public static void Main()
        {
            // создаем лист имен names.
            List<Name> names = new List<Name>();

            // Add names to the list.
            //names.Add(new Name() { Names = "Tom" });

            Console.WriteLine(" Enter name: ");
            //Console.ReadLine();
            String theName = Console.ReadLine();

            while (theName != "")
            {
                //theName = Console.ReadLine();
                names.Add(new Name() { Names = theName });
                Console.WriteLine();
                foreach (Name aName in names)
                {
                    Console.WriteLine(aName);
                }
                Console.WriteLine();
                Console.WriteLine(" Enter new name: ");
                //Console.ReadLine();
                theName = Console.ReadLine();

            }
            //else break;            

            // Write out the names in the list. This will call the overridden ToString method in the Name class.
            //Console.WriteLine();
            //foreach (Name aName in names)
            //{
            //    Console.WriteLine(aName);
            //}
            //Console.ReadLine();
        }
    }
}
   