using System;
using System.Text;

namespace FurtherMath.Calculations
{
    public class QuadraticEquation
    {
        private readonly double a;

        private readonly double b;

        private readonly double c;

        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Discriminant => Math.Pow(b, 2) - 4 * a * c;

        public QuadraticEquationRoots Solution()
        {
            if (Discriminant >= 0)
            {
                return new QuadraticEquationRoots((-b + Math.Sqrt(Discriminant)) / (2 * a), (-b - Math.Sqrt(Discriminant)) / (2 * a));
            }

            var imaginary = new Complex(0, Math.Sqrt(Math.Abs(Discriminant)));
            return new QuadraticEquationRoots((-b + imaginary) / (2 * a), (-b - imaginary) / (2 * a));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (a < 0)
            {
                builder.Append('-');
            }

            if (a != 0 && Math.Abs(a) != 1)
            {
                builder.Append(a);
            }

            if (a != 0)
            {
                builder.Append("x^2");
            }

            if (b > 0)
            {
                builder.Append('+');
            }
            else if (b == -1)
            {
                builder.Append('-');
            }

            if (b != 0 && Math.Abs(b) != 1)
            {
                builder.Append(b);
            }

            if (b != 0)
            {
                builder.Append("x");
            }

            if (c > 0)
            {
                builder.Append("+");
            }

            if (c != 0)
            {
                builder.Append(c);
            }

            builder.Append("=0");

            return builder.ToString();
        }
    }
}
