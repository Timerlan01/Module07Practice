using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    /// <summary>
    /// Task2
    /// </summary>
    public class MyArray
    {
        private int[] array;

        public MyArray(int[] arr)
        {
            array = arr;
        }

        public static bool operator <(MyArray a, MyArray b)
        {
            return a.array.Sum() < b.array.Sum();
        }

        public static bool operator >(MyArray a, MyArray b)
        {
            return a.array.Sum() > b.array.Sum();
        }
    }

}
