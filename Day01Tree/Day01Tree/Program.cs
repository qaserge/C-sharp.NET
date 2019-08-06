using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Tree

//Create a program that will ask the user:
//How big does your tree needs to be?
//Then using '*' character display a tree of wanted size.
//Example session:
//How big does your tree needs to be? 4
//   *
//  ***
// *****
//*******
//Suggestion first try to display a triangle of wanted size:
//*
//**
//***
//****
//*****
//Then display the reverse triangle
//   *
//  **
// ***
//****
//Then combine your solutions.

{
    class Program
    {      

            static void Main(string[] args)

            {

            Console.WriteLine("How big does your tree needs to be? ");
            string bigStr = Console.ReadLine();
            int big = int.Parse(bigStr);

            int spaces = big;
            int asterix = 1;
            for (int i = 0; i < big; i++)
            {
                for (int j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < asterix; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
                asterix++;
                spaces--;
            }
            Console.ReadLine();             

            }

        }

    
}
