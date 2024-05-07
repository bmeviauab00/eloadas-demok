using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    [AttributeUsage(AttributeTargets.Class)]
    class StorableClassAttribute:System.Attribute
    {
        public StorableClassAttribute() { }
    }
}
