using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp
{
    public class Person
    {
        // Some properties (covered on upcoming lecture)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\tName: {Name}\tPhone: {Phone}";
        }
    }
}
