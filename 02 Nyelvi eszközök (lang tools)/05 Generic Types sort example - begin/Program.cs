﻿using System;
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
            ArrayList list = new ArrayList();
            list.Add(new Complex(3, 2));
            list.Add(new Complex(1, 2));

            Sorter.HyperSort(list, FirstIsSmaller_Complex);
        }

        public static bool FirstIsSmaller_Complex(object a, object b)
        {
            Complex ca = (Complex)a;
            Complex cb = (Complex)b;
            return ca.Re < cb.Re;
        }

    }

}
