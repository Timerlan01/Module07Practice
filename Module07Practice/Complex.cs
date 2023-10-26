using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    public struct Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imaginary);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
            return new Complex(real, imaginary);
        }

        public static implicit operator Complex(double d)
        {
            return new Complex(d, 0);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is Complex other)
            {
                return Real == other.Real && Imaginary == other.Imaginary;
            }
            return false;
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !a.Equals(b);
        }
    }

}
