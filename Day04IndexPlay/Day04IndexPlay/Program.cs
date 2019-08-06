/*
 * 
 TASK 1 - Indexer exercise
-------------------------

Create new console program Day04IndexPlay.

In it create new class String10Storage with indexer getter/setts that accepts integer as index value and returns / takes string.

Implement that class as a storage for 10 string values.

Internally store strings in this array:

private string [] data = new string[10];

Write code to test your indexer by putting 5 strings of data into it then printing out all 10 positions of the indexer storage in a for loop.

LATER:

Create a new class similar to String10Storage called TenStorage that is a generic class that can store any type.



TASK 2 - indexer again
----------------------

In the same program create class PrimeArray with indexer method.

The indexer method will only have a getter taking an integer as index value and returning a boolean.

The value returned will signify whether the index value is a prime number or not.

PA[1] returns true
PA[4] return false
PA[5] returns true
PA[6] returns false

If index value is 0 or less throw an exception of your choice.

WHEN DONE - MAKE THE FOLLOWING MODIFICATION.

Make the indexer return a long value instead. The value returned for index N is the Nth prime number.

PA[1] returns 1
PA[2] returns 2
PA[3] returns 3
PA[4] returns 5
PA[5] returns 7
PA[6] returns 11
PA[7] returns 13



TASK 3: - Add Delegates
-----------------------

Continue working with the previous solution/project.

+ In PrimeArray class define a delegate type named LoggerDelegateType. That type will take three parameters types int, long and string and return void. 

+ In PrimeArray class define a field of delegate type named Logger type LoggerDelegateType. Make this field public.

In PrimeArray the delegate Logger must be called (only if not null) every time you need to compute a new prime. 
In that case first parameter is the N (index), second prime number returned and other message "computed new number".

In your main class define two static methods:

static void DisplayMessage(int n, long prime, string msg) { ... }
static void SaveMessage(int n, long prime, string msg) { ... }

The first one will display n, prime, message on the screen in a single line.

The second one will write the same information to a file named @"..\..\records.txt" prefixed with a timestamp yyyy-mm-dd hh:mm:ss. Make sure you use a valid date format for DotNet.


In your Main method you will randomly (in 50% of cases) add SisplayMessage to PrimeArray's delegate field.

In your Main method you will randomly (in 50% of cases) add SaveMessage to PrimeArray's delegate field.

After that you will ask PrimeArray instance for a few fibonacci numbers and make sure logging works.


 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04PrimeIndexer
{
    public class TenStorage<T> // создаем класс для женерика
    {
        private T[] strArr = new T[10]; // создаем массив с универсальным типом Т

        public T this[int index] // создаем Indexer
        {
            get
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                return strArr[index];
            }
            set
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                strArr[index] = value;
            }
        }
    }


    public class String10Storage
    {
        private string[] strArr = new string[10];

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                return strArr[index];
            }
            set
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");

                strArr[index] = value;
            }
        }
    }

    public class PrimeArray
    {
        private int[] strArr = new int[150];
        private bool prime;

        public bool this[int index]
        {
            get
            {
                if (index <= 0)
                    throw new IndexOutOfRangeException("index value must be greater 0");

                int i, m = 0, flag = 0;
                
                //Console.Write("Enter the Number to check Prime: ");
                m = index / 2;
                for (i = 2; i <= m; i++)
                {
                    if (index % i == 0)
                    {
                        //Console.Write("Number is not Prime.");
                        prime = false;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                    //Console.Write("Number is Prime.");
                    prime = true;

                return prime;
            }
            

        }
    }
       

    public class PrimeArrayMod
    {
        private int[] strArr = new int[20];
        public int this[int index] 
        {
            get
            {
                int i, j, count = 1, b = 0;                

                for (i = 3; i > 0; ++i)
                {
                    for (j = 2; j <= i / 2; ++j)
                    {
                        //not prime
                        if (i % j == 0)
                        {
                            b = 1;
                            break;
                        }
                    }
                    //prime
                    if (b == 0)
                    {
                        strArr[count+1] = i;
                        count++;
                    }

                    b = 0;
                    if (count == 12)
                        break;
                }
                strArr[0] = 1;
                strArr[1] = 2;
                return strArr[index];
            }
        }
    }


    public class PrimeArrayModDelegates
    {
        public delegate void LoggerDelegateType(int a, long b, string c);

        public LoggerDelegateType Logger; 

        private int[] strArr = new int[20];
        public int this[int index]
        {
            get
            {
                int i, j, count = 1, b = 0;

                for (i = 3; i > 0; ++i)
                {
                    for (j = 2; j <= i / 2; ++j)
                    {
                        //not prime
                        if (i % j == 0)
                        {
                            b = 1;
                            break;
                        }
                    }
                    //prime
                    if (b == 0)
                    {
                        strArr[count + 1] = i;
                        count++;
                    }

                    b = 0;
                    if (count == 12)
                        break;
                }
                strArr[0] = 1;
                strArr[1] = 2;

                Logger(index, strArr[index], "computed new number");

                return strArr[index];
            }
        }

        
    }



    class Program
    {
        static void DisplayMessage(int n, long prime, string msg)
        {
            Console.WriteLine(n + " " + prime + " " + msg);
        }
        static void SaveMessage(int n, long prime, string msg)
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(@"..\..\messages.txt", $"{dt}  " + msg + Environment.NewLine);
        }

        public class BooleanGenerator // класс для генерации рендомных bool
        {
            Random rnd;

            public BooleanGenerator()
            {
                rnd = new Random();
            }

            public bool NextBoolean()
            {
                return Convert.ToBoolean(rnd.Next(0, 2));
            }
        }

        static void Main(string[] args)
        {
            String10Storage strStore = new String10Storage();

            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";

            strStore[6] = "Seven";

            for (int z = 0; z < 10; z++)
                Console.WriteLine(z+1 + " " + strStore[z]);


            TenStorage<int> tenStoreInts = new TenStorage<int>();
            tenStoreInts[5] = 3443;
            Console.WriteLine(tenStoreInts[5]);
            
            Console.WriteLine("PrimeArray");

            PrimeArray prArr = new PrimeArray();
            Console.WriteLine($"prArr[1] returns {prArr[1]}");
            Console.WriteLine($"prArr[4] returns {prArr[4]}");
            Console.WriteLine($"prArr[5] returns {prArr[5]}");
            Console.WriteLine($"prArr[6] returns {prArr[6]}");
            Console.WriteLine($"prArr[15] returns {prArr[15]}");
            //Console.WriteLine($"prArr[-2] returns {prArr[-2]}");


            Console.WriteLine();
            Console.WriteLine("prArrMod return first Nth prime numbers");            

            PrimeArrayMod prArrMod = new PrimeArrayMod();
            for(int q=0; q<12; q++)
            {
                Console.WriteLine($"prArr[{q}] returns {prArrMod[q]}");
            }
            Console.WriteLine();


            //// рендомное использование bool
            //BooleanGenerator boolGen = new BooleanGenerator();
            //bool value = boolGen.NextBoolean();

            //try
            //{
            //    PrimeArrayModDelegates.LoggerDelegateType logger;
            //    if (value) //true
            //        logger = DisplayMessage;
            //    else
            //        logger = SaveMessage;



            //    //logger?.Invoke("Somthing happened"); //it's a nullable expression = if (logger != null) logger("Somthing happened");

            //}
            //finally
            //{
            //    Console.WriteLine("press");
            //    Console.ReadLine();
            //}


            ////fibonacci numbers:
            //int n1 = 0, n2 = 1, n3, i, number;
            //Console.Write("Enter the number of elements: ");
            //number = int.Parse(Console.ReadLine());
            //Console.Write(n1 + " " + n2 + " "); //printing 0 and 1    
            //for (i = 2; i < number; ++i) //loop starts from 2 because 0 and 1 are already printed    
            //{
            //    n3 = n1 + n2;
            //    Console.Write(n3 + " ");
            //    n1 = n2;
            //    n2 = n3;
            //}

            Console.ReadKey();
        }
    }
}
