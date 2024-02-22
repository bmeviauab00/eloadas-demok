using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var
{
    class VarTest
    {
        void F()
        {
            int n1 = 10;
            var n2 = 10;

            List<int> list1 = new List<int>();
            var list2 = new List<int>();
            var list3 = list1;
        }

    }
}
