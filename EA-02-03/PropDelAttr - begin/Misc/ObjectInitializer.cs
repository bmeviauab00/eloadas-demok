using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializer
{
    class Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }

    }

    class TestClass
    {
        public void UsePerson()
        {
            Person person = new Person();
            person.Name = "Joe";
            person.YearOfBirth = 2000;
        }
    }
}