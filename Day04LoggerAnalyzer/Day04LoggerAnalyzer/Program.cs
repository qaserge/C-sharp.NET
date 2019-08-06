/**
 TASK 4 - LINQ
-------------

Create a new project Day04LoggerAnalyzer. It will use "messages.txt" file from the previous task.

Define an new class LogMsg as follows.

class LogMsg {
	DateTime Date;
	int N;
	long Prime;
	string Msg;
}

In you Main class define:

static List<LogMsg> LogList = new List<LogMsg>();

And a method

static void ReadLogsFromFile() { }

That method will read records.txt file (created by the previous tasks), parse every line, instantiate LogMsg objects and add them to logList.

You will then use LINQ queries to find out and print out the following:

A) All log messages for prime vales below 100, ordered by date.

B) All log messages ordered by number of seconds (and seconds only) when they were recorded.  
  */


using System;
using System.Collections.Generic;
using System.IO;

namespace Day04LoggerAnalyzer
{

    public class LogMsg
    {
        DateTime Date;
        int N;
        long Prime;
        string Msg;
    }

    class Program
    {
        static List<LogMsg> LogList = new List<LogMsg>();

        static void ReadLogsFromFile()
        {
            // open file and parse items, add to list
            string[] linesArray = File.ReadAllLines(@"..\..\records.txt"); // читает все строки из файла
            foreach (string line in linesArray) // loop по полученным строкам
            {
                try // критический ексепшен если не прочитает файл
                {
                    string typeName = line.Split(';')[0]; // проверяем первый элемент в распарсенной строке
                    LogMsg person = new LogMsg(line); // создаем обьект для персон 
                    LogList.Add(person);


                    switch (typeName) // создаем свитч чтобы разделить использование методов
                    {
                        case "Person":
                            Person person = new Person(line); // создаем обьект для персон 
                            peopleList.Add(person); // добавляем запись по условиям класса персон
                            break;
                        case "Teacher":
                            Teacher teacher = new Teacher(line);
                            peopleList.Add(teacher);
                            break;
                        case "Student":
                            Student student = new Student(line);
                            peopleList.Add(student);
                            break;
                        default: //для всего что невощло в 
                            Console.WriteLine("Error in data line: don't know how to make " + typeName);
                            break;
                    }
                }
                catch (InvalidParameterException ex)
                {
                    Console.WriteLine("Error parsing line: " + ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
