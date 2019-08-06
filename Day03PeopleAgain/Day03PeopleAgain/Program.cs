using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03PeopleAgain
{

    public class InvalidParameterException : Exception //создаем класс (произвольное имя) и наследуем от Exception
    {
        public InvalidParameterException() { } //перехватываем все ексепшены
        public InvalidParameterException(string msg) : base(msg) { } // делаем стринг переменную, наследуем от родителя
        public InvalidParameterException(string msg, Exception orig) : base(msg, orig) { } // вваливаемся на один уровень вверх по ексепшену для получения более детального (подексепшен)
    }

    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            // 1-50 characters, no semicolons
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    throw new InvalidParameterException("Name must be 1-50 characters long, no semicolons");
                }
                _name = value;
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            // 0-150
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new InvalidParameterException("Age must be 0-150");
                }
                _age = value;
            }
        }
        public Person(string dataLine) // конструктор для парсинга строки
        {
            string[] data = dataLine.Split(';'); // создаем массив стринг и ставим разделитель
            if (data.Length != 3) // если недостаточно элементов (ex:Person;Jerry;23) в строке выдавать эксепшен
            {
                throw new InvalidParameterException("Line for Person must have exactly 3 values");
            }
            if (data[0] != "Person") //проверка если первый элемент в распарсенной строке не равен Person
            { // this check is redundant and we still want to have it
                throw new InvalidParameterException("Line must be for Person type");
            }

            Name = data[1]; // присваиваем распарсенное значение строки массиву data с id1
            string ageStr = data[2]; // возраст в id2
            try
            {
                Age = int.Parse(ageStr); //пробуем перевести возраст в int
            }
            catch (Exception ex) // если не получилось выставляем 2 ексепшена
            {
                if (ex is FormatException | ex is OverflowException) // или или, выдаст один из эксепшенов
                { // exception chaining (translate one exception into another)
                    throw new InvalidParameterException("Integer value expected", ex);
                }
                else throw ex; // в данной конструкции else обязателен
            }
        }
        public Person(string name, int age) : base() // создаем конструктор дефолтный, и делаем его наследником
        {
            Name = name;
            Age = age;
        }

        protected Person() { } // создаем пустой конструктор чтобы классы Teacher и Student не выдавали ошибки в конструкторах наследниках 

        public virtual string ToDataString() // создаем виртуальный метод, чтобы в классах наследниках его можно было бы перезаписать
        {
            return $"Person;{Name};{Age}";
        }

        public override string ToString() // перезаписываем метод
        {
            return $"Person {Name} is {Age}";
        }
    }

    public class Teacher : Person
    {
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            // 1-50 characters, no semicolons
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    throw new InvalidParameterException("Subject must be 1-50 characters long, no semicolons");
                }
                _subject = value;
            }
        }
        private int _yoe;
        public int YearsOfExperience
        {
            get { return _yoe; }
            // 0-100
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new InvalidParameterException("Years of Experience must be 0-100");
                }
                _yoe = value;
            }
        }

        public Teacher(string dataLine) : base()
        {

            string[] data = dataLine.Split(';');
            if (data.Length != 5) //Teacher;Randy;66;PhysEd;33
            {
                throw new InvalidParameterException("Line for Person must have exactly 3 values");
            }
            if (data[0] != "Teacher") // первый элемент в распарсенной строке должен быть Teacher
            { // this check is redundant and we still want to have it
                throw new InvalidParameterException("Line must be for Person type");
            }

            try
            {
                Name = data[1];
                Age = int.Parse(data[2]);
                Subject = data[3];
                YearsOfExperience = int.Parse(data[4]);
            }
            catch (Exception ex)
            {
                if (ex is FormatException | ex is OverflowException)
                { // exception chaining (translate one exception into another)
                    throw new InvalidParameterException("Integer value expected", ex);
                }
                else throw ex;
            }

        }
        public Teacher(string name, int age, string subject, int yoe) : base(name, age)
        {
            Subject = subject;
            YearsOfExperience = yoe;
        }
        public override string ToDataString() // перезаписывает ToDataString метод
        {
            return $"Teacher;{Name};{Age};{Subject};{YearsOfExperience}";
        }

        public override string ToString() // перезаписывает ToString метод
        {
            return $"Teacher {Name} is {Age}, teaches {Subject} since {YearsOfExperience} years";
        }
    }

    public class Student : Person
    {
        private string _program;
        public string Program
        {
            get { return _program; }
            // 1-50 characters, no semicolons
            set
            {
                if (value.Length < 1 || value.Length > 50 || value.Contains(";"))
                {
                    throw new InvalidParameterException("Program must be 1-50 characters long, no semicolons");
                }
                _program = value;
            }
        }
        private double _gpa;
        public double GPA
        {
            get { return _gpa; }
            // 0-100
            set
            {
                if (value < 0 || value > 4.3)
                {
                    throw new InvalidParameterException("GPA must be 0-4.3");
                }
                _gpa = value;
            }
        }

        public Student(string dataLine)
        {

            string[] data = dataLine.Split(';');
            if (data.Length != 5) //Student;Mary;34;Nursing;3.8
            {
                throw new InvalidParameterException("Line for Person must have exactly 3 values");
            }
            if (data[0] != "Student")
            { // this check is redundant and we still want to have it
                throw new InvalidParameterException("Line must be for Person type");
            }
            try
            {
                Name = data[1];
                Age = int.Parse(data[2]);
                Program = data[3];
                GPA = double.Parse(data[4]);
            }
            catch (Exception ex)
            {
                if (ex is FormatException | ex is OverflowException)
                { // exception chaining (translate one exception into another)
                    throw new InvalidParameterException("Integer value expected", ex);
                }
                else throw ex;
            }
        }

        public Student(string name, int age, string program, double gpa) : base(name, age) //наследует name, age от Person
        {
            Program = program;
            GPA = gpa;
        }
        public override string ToDataString()
        {
            return $"Student;{Name};{Age};{Program};{GPA}";
        }

        public override string ToString()
        {
            return $"Student {Name} is {Age}, studies {Program} with {GPA:0.00} GPA";
        }
    }


    class Program
    {
        static List<Person> peopleList = new List<Person>(); // расширяемый список peopleList

        static void ReadDataFromFile()
        {
            // open file and parse items, add to list
            string[] linesArray = File.ReadAllLines(@"..\..\people.txt"); // читает все строки из файла
            foreach (string line in linesArray) // loop по полученным строкам
            {
                try // критический ексепшен если не прочитает файл
                {
                    string typeName = line.Split(';')[0]; // проверяем первый элемент в распарсенной строке
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

        private static void ProcessingDisplayTasks()//метод для отображения с условиями
        {
            // display all as is
            Console.WriteLine("\nAll items:");
            foreach (Person p in peopleList)
            {
                Console.WriteLine(p);
            }
            // display only students
            Console.WriteLine("\nOnly Students items:");
            foreach (Person p in peopleList)
            {
                if (p is Student)
                {
                    Console.WriteLine(p);
                }
            }
            // display only teacher
            Console.WriteLine("\nOnly Teachers items:");
            foreach (Person p in peopleList)
            {
                if (p is Teacher)
                {
                    Console.WriteLine(p);
                }
            }
            // display only students
            Console.WriteLine("\nOnly Person items:");
            foreach (Person p in peopleList)
            {
                if (p.GetType() == typeof(Person)) // универсальная запись, можно использовать тип чтобы навернка быть увереным что будет использован тот элемент
                {
                    Console.WriteLine(p);
                }
            }
        }

        static void ProcessingAveragesTasks() // метод для подсчета AVG
        {
            // использование LINQ
            var studentsCollection = from p in peopleList where p is Student select p as Student;
            // where p is Student select p as Student - значит что если точно p is Student, то только тогда p as Student 
            if (studentsCollection.Count() == 0) //если вообще нет студентов
            {
                Console.WriteLine("No Students found to compute averages on");
                return;
            }
            // compute average
            double avg = studentsCollection.Average(s => s.GPA); // лямда
            Console.WriteLine($"Average GPA is: {avg:0.00}"); // формат для double :0.00

            // compute median 
            // использование LINQ
            List<double> GPASortedList = (from s in studentsCollection orderby s.GPA select s.GPA)
                                    .ToList<double>(); // конвертация в лист double
            double medianGPA;
            if (GPASortedList.Count() % 2 == 0)
            { // even
                double v1 = GPASortedList[GPASortedList.Count() / 2 - 1];
                double v2 = GPASortedList[GPASortedList.Count() / 2];
                medianGPA = (v1 + v2) / 2;
            }
            else
            { // odd
                medianGPA = GPASortedList[GPASortedList.Count() / 2];
            }
            Console.WriteLine($"Median is: {medianGPA:0.00}");

            // compute stdandard deviation
            double sumOfSquares = 0;
            foreach (double gpa in GPASortedList)
            {
                sumOfSquares += (gpa - avg) * (gpa - avg);
            }
            double stddev = Math.Sqrt(sumOfSquares / GPASortedList.Count());
            Console.WriteLine($"Standard deviation is {stddev:0.00}");
        }

        static void Main(string[] args)
        {
            try
            {
                ReadDataFromFile();
                // insert some fake data so we can test it
                /*
                peopleList.Add(new Person(...));
                peopleList.Add(new Person(...));
                peopleList.Add(new Person(...));
                peopleList.Add(new Person(...)); */
                ProcessingDisplayTasks();
                ProcessingAveragesTasks();

                /*
                Person p = new Person("");
                Object o = p;

                Student s = (Student)p; // causes Casting exception

                if (p is Student) // check the type
                {
                    Student s2 = (Student)p; // this cast is always safe after if-is
                }

                Student s3 = p as Student; // if cast is impossible s3 is null
                if (s3 != null) { ... }
                */



            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to finish");
                Console.ReadKey();
            }




        }


    }
}
