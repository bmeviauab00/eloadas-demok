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

            // With a lambda expression, we define an anonymous function, that is assignable to a delegate

            // Statement lambda
            Sorter.HyperSort(list, (Complex a, Complex b) => { return a.Re < b.Re; } );

            // Same as previous, just formatted differently: broken into multiple lines
            // (practical format when lambda body has multiple statements)
            Sorter.HyperSort(list,
                (Complex a, Complex b) =>
                {
                    return a.Re < b.Re;
                }
               );

            // Simplification: compiler can infer the parameter types
            Sorter.HyperSort(list, (a, b) => { return a.Re < b.Re; });

            // Simplification: expression lambda syntax (can be used when the body is a single expression)
            Sorter.HyperSort(list, (a, b) => a.Re < b.Re);

            // We can assign lambdas to ANY compatible delegate variable (e.g. to local or
            // member variables as well).
            FirstIsSmallerDelegate<Complex> fis = (a, b) => a.Re < b.Re;
            bool b = fis(new Complex(10, 20), new Complex(1, 2));

        }

        // We have removed this, as we use a lambda above instead
        //public static bool FirstIsSmaller_Complex( Complex a, Complex b)
        //{
        //    return a.Re < b.Re;
        //}

    }

}
