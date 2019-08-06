using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//In this exercise you're asked to create several methods.
//It is up to you to create test cases in Main() method to test your solutions.
//Note: you are NOT allowed to use List<> in this exercise.

//* Part 1: +
//Create method with the following signature:
//public int[] Concatenate(int[] a1, int[] a2) { }
//Return an array that is a concatenation of the two arrays passed.
//Example: if I pass { 2, 7, 8}
//and { -2, 9} I will receive back array
//{ 2, 7, 8, -2, 9 }

//* Part 2: +
//Write a method with the following signature:
//public static void PrintDups(int[] a1, int a2[]) { }
//That method will print out only values that appear both in a1 and a2.
//If a1 contains multiple values that are the same you may print them out multiple times.
//For arrays:
//a1: 1, 3, 7, 8, 2, 7, 9, 11
//a2: 3, 8, 7, 5, 13, 5, 12
//Output is:
//3
//7
//8
//7

//* Part 3 -
//Create method with the following signature:
//public int[] RemoveDups(int[] a1, int[] a2) { }
//Return a copy of a1, except elements that are also present in a2 are removed.
//Note: returned array must be of exactly the needed size, not larger.
//Example: removeDups({ 2, 3, 5, 7, 3, 2}, {3, 9, 7}) 
//will return array of two elements exactly: {2, 5, 2}

//* Part 4
//Write a method with the following signature:
//public static void PrintDups(int[,] a1, int a2[,]) { }
//That method will print out only values that appear both in a1 and a2.
//If a1 contains multiple values that are the same you may print them out multiple times.
//NOTE: In this case both arrays are TWO DIMENSIONAL.

namespace Day01ArrayContains
{
    class Program
    {
        static public int[] Concatenate(int[] a1, int[] a2)
        {                        
            var z = new int[a1.Length + a2.Length];
            a1.CopyTo(z, 0);
            a2.CopyTo(z, a1.Length);
            //int[] q = z.Distinct().ToArray(); // убирает дубликаты

            Console.WriteLine("Concatenate array value is: ");
            for (int j = 0; j < z.Length; j++)
            {
                Console.Write($"{z[j]} ");
            }
            Console.WriteLine();
            return z;
        }

        public static void PrintDups(int[] a1, int [] a2)
        {
            Console.WriteLine("Dublicate array value is: ");
            for (int ar1=0; ar1< a1.Length; ar1++)
            {
                for (int ar2=0; ar2 < a2.Length; ar2++)
                {
                    if (a1[ar1] == a2[ar2])
                    {
                        Console.Write($"{a1[ar1]} ");
                    }
                }
            }
            Console.WriteLine();
        }

        //public static void PrintDups(int[,] a1, int[,] a2)
        //{
        //    Console.WriteLine("Dublicate 2d array value is: ");
        //    for (int ar1 = 0; ar1 < a1.Length; ar1++)
        //    {
        //        for (int ar2 = 0; ar2 < a2.Length; ar2++)
        //        {
        //            if (a1[ar1,ar1] == a2[ar2,ar2])
        //            {
        //                Console.Write($"{a1[ar1,ar1]} ");
        //            }
        //        }
        //    }
        //    Console.WriteLine();
        //}


        public static void PrintDups(int[,] a1, int[,] a2)
        {
            Console.WriteLine("Duplicates: ");
            List<int> uniqueList = new List<int>();
            foreach (int v1 in a1)
            {
                foreach (int v2 in a2)
                {
                    if (v1 == v2)
                    {
                        // Console.Write($"{v1}, ");
                        // only add it to the list if it's not in it already
                        if (!uniqueList.Contains(v1))
                        {
                            uniqueList.Add(v1);
                        }
                        else
                        {
                            Console.WriteLine("Rejected dup: " + v1);
                        }
                    }
                }
            }
            //
            foreach (int v in uniqueList)
            {
                Console.Write($"{v}, ");
            }
        }


        //int[,] q = a1.Distinct().ToArray();


        static public int[] RemoveDups(int[] a1, int[] a2)
        {
            Console.WriteLine("Remove Dups array value is: ");            

            for (int ar1 = 0; ar1 < a1.Length; ar1++)
            {
                for (int ar2 = 0; ar2 < a2.Length; ar2++)
                {
                    if (a1[ar1] != a2[ar2])
                    {
                        Console.Write($"{a1[ar1]} ");
                        //break;                        
                    }                    
                }
            }
            Console.WriteLine();
            return a1;
        }



        static void Main(string[] args)
        {
            //int[] arr1 = { 2, 7, 8 };
            //int[] arr2 = { -2, 9 };
            //Concatenate(arr1, arr2);

            //For arrays:
            //a1: 1, 3, 7, 8, 2, 7, 9, 11
            //a2: 3, 8, 7, 5, 13, 5, 12
            //Output is:
            //3
            //7
            //8
            //7
            //int[] arr1 = { 1, 3, 7, 8, 2, 7, 9, 11 };
            //int[] arr2 = { 3, 8, 7, 5, 13, 5, 12 };
            //PrintDups(arr1, arr2);

            //int[] arr1 = { 2, 3, 5, 7, 3, 2 };
            //int[] arr2 = { 3, 9, 7 };

            //Example: removeDups({ 2, 3, 5, 7, 3, 2}, {3, 9, 7}) 
            //will return array of two elements exactly: {2, 5, 2}
            //RemoveDups(arr1, arr2);

            //int[,] arr1 = {{ 2, 3, 5, 7, 3, 2 },{ 2, 3, 5, 7, 3, 2 } };
            //int[,] arr2 = { { 3, 9, 7 }, { 3, 9, 7 } };
            //PrintDups(arr1, arr2);

            int[,] arr1 = { { 2, 3 }, { 7, 8 }, { 3, 17 } };
            int[,] arr2 = { { 64, 3, 7 }, { 1, 8, 11 } };
            PrintDups(arr1, arr2);

            

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
