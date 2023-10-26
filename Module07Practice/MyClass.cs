using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    /// <summary>
    /// Task1
    /// </summary>
    public class MyClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public static bool operator ==(MyClass a, MyClass b)
        {
            return a.Property1 == b.Property1 && a.Property2 == b.Property2;
        }

        public static bool operator !=(MyClass a, MyClass b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is MyClass other)
            {
                return this == other;
            }
            return false;
        }
    }

}
