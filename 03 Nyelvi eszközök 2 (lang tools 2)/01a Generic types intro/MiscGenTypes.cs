using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    struct Point<T>
    {
        public T X;
        public T Y;
    }

    class UsePoint
    {
        void F()
        {
            Point<float> point;
            point.X = 1.2f;
            point.Y = 3.4f;
        }
    }


    class Util
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp; temp = lhs; lhs = rhs; rhs = temp;
        }
    }

    class UseSwap
    {
        void F()
        {
            int a = 2, b = 3;
            Util.Swap<int>(ref a, ref b);
            // Equivalent to the previous line, no need to provide the type, the compiler infers it from the context
            Util.Swap(ref a, ref b);
        }
    }


}
