using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    public class MyArray4
    {
        public int[] array;

        public MyArray4(int[] arr)
        {
            array = arr;
        }

        public static MyArray operator *(MyArray a, MyArray b)
        {
            if (a.array.Length != b.array.Length)
                throw new InvalidOperationException("Arrays must have the same length for multiplication.");

            int[] result = new int[a.array.Length];
            for (int i = 0; i < a.array.Length; i++)
            {
                result[i] = a.array[i] * b.array[i];
            }

            return new MyArray(result);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return array[index];
            }
        }

        public int Size()
        {
            return array.Length;
        }

        public static bool operator ==(MyArray a, MyArray b)
        {
            if (a.array.Length != b.array.Length)
                return false;
            for (int i = 0; i < a.array.Length; i++)
            {
                if (a.array[i] != b.array[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(MyArray a, MyArray b)
        {
            return !(a == b);
        }

        public static bool operator <=(MyArray a, MyArray b)
        {
            return a.array.Sum() <= b.array.Sum();
        }
    }

}
