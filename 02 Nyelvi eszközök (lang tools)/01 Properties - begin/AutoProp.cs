using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Properties
{
    class Person1
    {
        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    class Person2
    {
        public string Name
        {
            get;
            private set;
        }
    }

}
