using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambdas
{
    // Erre nincs szükség, a beépített generikus Func<> delegate-et használjuk
    // delegate bool FirstIsSmallerDelegate(object a, object b);

    class Sorter2
    {
        // A Func egy generikus delegate, generikus paraméterekben a delegate paramétereket kell 
        // felsorolni, a végén utolsónak a visszatérés típusát. A példánkbank két object paraméter
        // van, a visszatérés bool, így Func<object, object, bool> használandó.
        public static void HyperSort(ArrayList list, Func<object, object, bool> fis)
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
