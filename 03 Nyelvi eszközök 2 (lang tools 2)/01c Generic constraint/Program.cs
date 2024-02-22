// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

// Remove "where T: IComparable" from the line below to see
// why this constraint is important (will get compilation error)
class SortableCollection<T> where T : IComparable
{
    private T[] items;

    public void Sort()
    {

        for (int i = 1; i < items.Length; i++)
        {
            for (int j = items.Length - 1; j >= i; j--)
            {
                if (items[i].CompareTo(items[i + 1]) > 0)
                {
                    T tmp = items[j];
                    items[j] = items[j - 1];
                    items[j - 1] = tmp;
                }
            }
        }
    }

    // ...
}

