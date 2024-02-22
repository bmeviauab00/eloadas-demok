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
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Complex> list = new List<Complex>();
            list.Add(new Complex(3, 2));
            list.Add(new Complex(1, 2));

            #region Func example

            // We use the built in generic Func instead of our custom FirstIsSmallerDelegate delegate type.
            // FirstIsSmallerDelegate<Complex> fis = (a, b) => a.Re < b.Re;
            Func<Complex, Complex, bool> fis = (a, b) => a.Re < b.Re;
            bool b = fis(new Complex(10, 20), new Complex(1, 2));

            #endregion

            #region Action examples

            // Example 1:
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World"); // Kiírja, hogy "Hello World"

            // Example 2:
            Action<string, string> labelAndTextWriter = (label, text) => Console.WriteLine($"{label}:\t{text}");
            labelAndTextWriter("Név", "Ennio Morricone");
            labelAndTextWriter("Szül. év", "1928");

            #endregion
        }


    }

}
