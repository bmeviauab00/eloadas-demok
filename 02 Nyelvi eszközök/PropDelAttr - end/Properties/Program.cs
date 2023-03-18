using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Properties
{
    public class Person
    {
        private string name;
        private int yearOfBirth;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The Name prop. can not be null.");
                name = value;
            }
        }

        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set
            {
                if (value < 1800 || value > 3000)
                    throw new ArgumentException();
                yearOfBirth = value;
            }
        }

        public Person(string name, int yearOfBirth)
        {
            this.name = name;
            this.yearOfBirth = yearOfBirth;
        }

        // Számított érték
        public int Age
        {
            get 
            {
                return DateTime.Now.Year - yearOfBirth;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Joe", 1980);
            p1.YearOfBirth = 1995;
            Console.WriteLine("Name: {0}, Age: {1}", p1.Name, p1.Age);

            //p1.YearOfBirth = -1995;
            //p1.Age = 10;

            Console.ReadKey();
        }
    }
}
