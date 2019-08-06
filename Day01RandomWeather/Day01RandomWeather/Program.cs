using System;
/*
 * Your program will generate a random integer value in the -30 to +30 range(both inclusive). 
 * You will display the value to the user.
Then using if/else/if/else/... chain you will display message depending on the temperature:
* if temperature is below or equal -15 display "Very very cold"
* if temperature is above -15 but below 0 display "Freezing already"
* if temperature is between 0 and 15 (both inclusive) display "Spring or Fall"
* if temperature is above 15 display "That's what I like"
*/

namespace Day01RandomWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            
            Console.WriteLine("Do you wonna generate RandomWeather? y or n");

            while (Console.ReadLine() != "n")
            {
                int temp = rand.Next(-30, 31);
                Console.WriteLine($" temp is: {temp}");
                if (temp <= -15) Console.WriteLine("Very very cold");
                else if (temp > -15 && temp <= 0) Console.WriteLine("Freezing already");
                else if (temp > 0 && temp <= 15) Console.WriteLine("Spring or fall");
                else if (temp > 15) Console.WriteLine("That's what I like");
                Console.WriteLine("One more time? y or n");
            }

            
        }
    }
}
