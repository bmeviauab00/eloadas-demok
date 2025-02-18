using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Properties
{
    public class Person
    {
        public string Name;
        public int yearOfBirth;

        public Person(string name, int yearOfBirth)
        {
            this.Name = name;
            this.yearOfBirth = yearOfBirth;
        }

        public int GetYearOfBirth()
        {
            return yearOfBirth;
        }

        public void SetYearOfBirth(int yearOfBirth)
        {
            this.yearOfBirth = yearOfBirth;
        }

        // Számított érték
        public int GetAge()
        {
            return DateTime.Now.Year - yearOfBirth;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Joe", 1980);
            p1.SetYearOfBirth(1995);
            Console.WriteLine($"Name: {p1.Name}, Age: {p1.GetAge()}");

            Console.ReadKey();
        }
    }
}
