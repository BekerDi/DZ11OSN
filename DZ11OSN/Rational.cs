using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11OSN
{
    internal class Rational
    {
        public int Numerator {  get; set; }
        public int Denominator { get; set; }
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может равняться 0");

            
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }
        //Сокращаем дроби, деля числитель и знаменатель на НОД
        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }
        //Находим этот самый НОД 
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static Rational operator +(Rational a, Rational b) => new Rational(a.Numerator * b.Denominator + b.Numerator *  a.Denominator, a.Denominator * b.Denominator);
        public static Rational operator - (Rational a, Rational b) => new Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static Rational operator * (Rational a, Rational b) => new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static Rational operator / (Rational a, Rational b) => new Rational(a.Numerator * b.Denominator , b.Numerator * a.Denominator);
        public override string ToString() => $"{Numerator}/{Denominator}";

    }

}
