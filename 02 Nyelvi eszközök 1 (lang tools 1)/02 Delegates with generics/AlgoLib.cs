using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    delegate bool FirstIsSmallerDelegate<T>(T a, T b);

    class Sorter
    {
        public static void HyperSort<T>(List<T> list, FirstIsSmallerDelegate<T> fis)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = list.Count - 1; j >= i; j--)
                {
                    if (fis(list[j], list[j - 1]))
                    {
                        T tmp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = tmp;
                    }
                }
            }
        }
    }
}
