using System;
using System.Collections.Generic;

namespace Day01Numbers

//Ask user how many numbers he/she wants to generate.
//Generate the numbers as random integers in -100 to +100 range, both inclusive.
//Place the numbers in List<int> named numList.
//In a next loop find the numbers that are less or equal to 0 and print them out, one per line.

{
    public class Num
    {
        public int Nums { get; set; }

        public override string ToString()
        {
            return " " + Nums;
        }

        //public static implicit operator int(Num v)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class Test
    {
        public static void Main()
        {            
            List<Num> numList = new List<Num>();

            Random rnd = new Random();            

            Console.WriteLine(" How many numbers do ypu want? ");
            
            String str = Console.ReadLine();
            int numNums = int.Parse(str);

            for (int i = 1; i <= numNums; i++)
            {   
                numList.Add(new Num() { Nums = rnd.Next(-100, 101) });                                            
            }
            foreach (Num aNum in numList)
            {
                Console.Write(aNum);
            }
            
                       
            Console.ReadLine();
           
        }
    }
}
