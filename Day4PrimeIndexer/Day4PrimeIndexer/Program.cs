using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4PrimeIndexer
{
    public class String10Storage
    {
        private string[] strArr = new string[10]; // internal data storage

        public string this[int index]
        {
            get
            {
                if (index < 0 && index >= strArr.Length)
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

    public class TenStorage<T>
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            String10Storage strStore = new String10Storage();

            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";
            strStore[4] = "Five";
            strStore[8] = "Nine";


            for (int i = 0; i < 10; i++)
                Console.WriteLine($"{i+1} = {strStore[i]}");

            Console.ReadLine();
        }
    }
}
