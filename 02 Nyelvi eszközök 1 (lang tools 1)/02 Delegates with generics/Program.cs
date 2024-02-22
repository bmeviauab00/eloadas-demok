using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Complex
    {
        public double Re, Im;

        public Complex(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }

        public static bool FirstIsSmaller_Complex(Complex a, Complex b)
        {
            return a.Re < b.Re;
        }
    }

    class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Complex> list = new List<Complex>();
            list.Add(new Complex(3, 2));
            list.Add(new Complex(1, 2));

            // Sorter.HyperSort(list, new FirstIsSmallerDelegate(FirstIsSmaller_Complex));

            Sorter.HyperSort(list, FirstIsSmaller_Complex );

            ComplexComparer complexComparer = new ComplexComparer();
            Sorter.HyperSort(list, complexComparer.FirstIsSmaller);

            var fis = FirstIsSmaller_Complex;
            bool isFIS = fis(new Complex(1, 2), new Complex(1, 2));


            fis += Complex.FirstIsSmaller_Complex;
            isFIS = fis(new Complex(1, 2), new Complex(1, 2));
        }

        public static bool FirstIsSmaller_Complex(Complex a, Complex b)
        {
            return a.Re < b.Re;
        }

        public static bool FirstIsSmaller_Person(object a, object b)
        {
            Person ca = (Person)a;
            Person cb = (Person)b;
            return string.Compare(ca.Name, cb.Name) < 0;
        }

    }

    class ComplexComparer
    {
        public bool FirstIsSmaller(Complex a, Complex b)
        {
            // mint a Program osztályban
            return a.Re < b.Re;
        }
    }
}
