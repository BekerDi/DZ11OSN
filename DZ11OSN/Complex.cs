using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11OSN
{
    internal class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex operator + (Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        public static Complex operator - (Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        public static Complex operator * (Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real*b.Imaginary + b.Real * a.Imaginary);

        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if ((object)a == null || (object)b == null)
            {
                return false;
            }
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(Complex a, Complex b)
            => !(a == b);

        public override string ToString()
        {
            if (Imaginary<0)
            {
                return $"{Real} - {-Imaginary}i";
            }
            else
            {
                return $"{Real} + {Imaginary}i";
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {


                Complex C = (Complex)obj;
                return this == C;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Real.GetHashCode()^Imaginary.GetHashCode();
        }


    }

    }

