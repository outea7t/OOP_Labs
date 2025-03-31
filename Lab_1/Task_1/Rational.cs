using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_1
{
    public class Rational
    {
        private int Numerator { get; }
        private int Denominator { get; }

        public Rational(int numerator, int denominator) 
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не должен быть равен 0!");
            }

            if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
                return;
            }

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
         
            if (numerator * denominator < 0)
            {
                Numerator = -Math.Abs(numerator);
                Denominator = Math.Abs(denominator);
                return;
            }
            Numerator = Math.Abs(numerator);
            Denominator = Math.Abs(denominator);
        }

        public override string ToString()
        {
            Console.WriteLine(Denominator);
            if (Denominator == 1)
                return $"{Numerator}";
            return $"{Numerator}/{Denominator}";
        }

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

        private int CompareTo(Rational a)
        {
            return (Numerator * a.Denominator).CompareTo(a.Numerator * Denominator);
        }

        private bool Equals(Rational a)
        { 
            return Numerator == a.Numerator && Denominator == a.Denominator;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int num = a.Numerator  * b.Denominator + b.Numerator * a.Denominator;
            int den = a.Denominator * b.Denominator;
            return new Rational(num, den);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int num = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int den = a.Denominator * b.Denominator;
            return new Rational(num, den);
        }

        public static Rational operator *(Rational a, Rational b) 
        {
            Console.WriteLine($"{a.Numerator * b.Numerator}, {a.Denominator * b.Denominator}");
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на 0!");
            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a.Numerator, a.Denominator);
        }
        public static bool operator ==(Rational a, Rational b)
        { 
            return a.Equals(b);
        }
        public static bool operator !=(Rational a, Rational b)
        {   
            return !a.Equals(b);
        }
        public static bool operator <(Rational a, Rational b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator <=(Rational a, Rational b)
        { 
            return a.CompareTo(b) <= 0;
        }
        public static bool operator >(Rational a, Rational b)
        { 
            return a.CompareTo(b) > 0;
        }
        public static bool operator >=(Rational a, Rational b)
        {
            return a.CompareTo(b) >= 0;
        }
    }
}
