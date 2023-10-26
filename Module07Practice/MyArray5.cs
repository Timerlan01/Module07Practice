using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    public class MyArray5
    {
        public int[] array;

        public MyArray5(int[] arr)
        {
            array = arr;
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

        public static MyArray operator +(MyArray a, MyArray b)
        {
            int[] result = new int[a.array.Length + b.array.Length];
            a.array.CopyTo(result, 0);
            b.array.CopyTo(result, a.array.Length);
            return new MyArray(result);
        }
    }


public class Decimal
    {
        private char[] digits; // Array of decimal digits

        public Decimal(string value)
        {
            if (value.Length != 100)
                throw new InvalidOperationException("Value must have exactly 100 decimal digits.");
            digits = value.ToCharArray();
        }

        public static Decimal operator +(Decimal a, Decimal b)
        {
            // Add the digits of both Decimal values and handle carry
            char[] result = new char[100];
            int carry = 0;
            for (int i = 99; i >= 0; i--)
            {
                int sum = (a.digits[i] - '0') + (b.digits[i] - '0') + carry;
                result[i] = (char)((sum % 10) + '0');
                carry = sum / 10;
            }

            return new Decimal(new string(result));
        }

        public static Decimal operator -(Decimal a, Decimal b)
        {
            // Subtract the digits of b from a and handle borrow
            char[] result = new char[100];
            int borrow = 0;
            for (int i = 99; i >= 0; i--)
            {
                int diff = (a.digits[i] - '0') - (b.digits[i] - '0') - borrow;
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                result[i] = (char)(diff + '0');
            }

            return new Decimal(new string(result));
        }

        public static Decimal operator *(Decimal a, Decimal b)
        {
            // Perform long multiplication
            Decimal result = new Decimal("0");
            for (int i = 99; i >= 0; i--)
            {
                Decimal temp = MultiplyByDigit(a, b.digits[i] - '0');
                temp = ShiftLeft(temp, 99 - i);
                result = result + temp;
            }
            return result;
        }

        public static Decimal operator /(Decimal a, Decimal b)
        {
            // Perform long division
            Decimal result = new Decimal("0");
            Decimal remainder = a;

            for (int i = 0; i < 100; i++)
            {
                int divisor = b.digits[i] - '0';
                int quotientDigit = 0;

                while (remainder >= b)
                {
                    remainder = remainder - b;
                    quotientDigit++;
                }

                result.digits[i] = (char)(quotientDigit + '0');
                remainder = ShiftLeft(remainder, 1);
            }

            return result;
        }

        private static Decimal MultiplyByDigit(Decimal a, int digit)
        {
            // Multiply a Decimal by a single digit (0-9)
            char[] result = new char[100];
            int carry = 0;

            for (int i = 99; i >= 0; i--)
            {
                int product = (a.digits[i] - '0') * digit + carry;
                result[i] = (char)((product % 10) + '0');
                carry = product / 10;
            }

            return new Decimal(new string(result));
        }

        private static Decimal ShiftLeft(Decimal a, int count)
        {
            // Shift a Decimal left by count positions
            char[] result = new char[100];

            for (int i = 0; i < 100 - count; i++)
            {
                result[i] = a.digits[i + count];
            }

            for (int i = 100 - count; i < 100; i++)
            {
                result[i] = '0';
            }

            return new Decimal(new string(result));
        }
    }

}
