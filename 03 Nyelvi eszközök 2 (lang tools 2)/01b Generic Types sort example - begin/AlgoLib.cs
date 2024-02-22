using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    delegate bool FirstIsSmallerDelegate(object a, object b);

    class Sorter
    {
        public static void HyperSort(ArrayList list, FirstIsSmallerDelegate fis)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = list.Count - 1; j >= i; j--)
                {
                    if (fis(list[j], list[j - 1]))
                    {
                        object tmp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = tmp;
                    }
                }
            }
        }
    }
}
