using System;

//Declare two arrays:

//String namesArray = new String[4];
//int agesArray = new int[4];

//Ask user for names and ages of for people and save the information in the arrays.

//Find the youngest person and display their name and age.

//Example session:
//Enter name of person #1: Jerry
//Enter age  of person #1: 33
//Enter name of person #2: Tom
//Enter age  of person #2: 22
//Enter name of person #3: Marianna
//Enter age  of person #3: 56
//Enter name of person #4: Lucy
//Enter age  of person #4: 27

//Youngest person is 22 and their name is Tom

namespace Day01People
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] namesArray = new string[4];
            int [] agesArray = new int[4];

            for (int n = 0; n< namesArray.Length; n++)
            {
                Console.WriteLine("What is your name? ");
                namesArray[n] = Console.ReadLine();
                Console.WriteLine("How old are you? ");
                string age = Console.ReadLine();
                agesArray[n] = int.Parse(age);
            }

            for (int n = 0; n < namesArray.Length; n++)
            {
                Console.WriteLine($"name is {namesArray[n]}");
                Console.WriteLine($"age is {agesArray[n]}");
            }

            int minAge = agesArray[0];
            int id = 0; 
            for (int n = 0; n < namesArray.Length; n++)
            {
                if (minAge > agesArray[n])
                {
                    minAge = agesArray[n];
                    id = n;
                }                    
            }
            Console.WriteLine($"Youngest person is {minAge} and their name is {namesArray[id]}");

            Console.ReadLine();


        }
    }
}
