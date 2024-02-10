using System;
using System.Collections.Generic;
using System.Text;

namespace Generic
{
    // Remove "where T: IComparable" from the line below to see
    // why this constraint is important (will get compilation error)
    class SortableCollection<T> where T: IComparable
    {
        private T[] items;

        public void Sort()
        {
            // ...

            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].CompareTo(items[i + 1]) > 0)
                {
                    // ...
                }
            }

            // ...
        }

        // ...
    }
}
