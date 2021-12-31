using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace FurtherMath.Calculations
{
    public class QuadraticEquation
    {
        private readonly double a;

        private readonly double b;

        private readonly double c;

        private static readonly Regex QuadraticCoefficient = new("((?:^|[-+])\\d*)x\\^2", RegexOptions.Compiled);

        private static readonly Regex LinearCoefficient = new("((?:^|[-+])\\d*)x(?!\\^2)", RegexOptions.Compiled);

        private static readonly Regex RestCoefficient = new("((?:^|[-+])\\d+)(?!x)", RegexOptions.Compiled);

        private static readonly Regex[] CoefficientRegexs = { QuadraticCoefficient, LinearCoefficient, RestCoefficient };

        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        private QuadraticEquation(double[] coefficients) : this(coefficients[0], coefficients[1], coefficients[2])
        {
        }

        public double Discriminant => Math.Pow(b, 2) - 4 * a * c;

        public static QuadraticEquation Parse(string equation)
        {
            var coefficients = new double[3];

            for (int i = 0; i < coefficients.Length; i++)
            {
                var match = CoefficientRegexs[i].Match(equation);
                if (match.Success)
                {
                    coefficients[i] = ParseCoefficient(match.Groups[1].Value);
                }
            }

            return new QuadraticEquation(coefficients);
        }

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
                builder.Append('x');
            }

            if (c > 0)
            {
                builder.Append('+');
            }

            if (c != 0)
            {
                builder.Append(c);
            }

            builder.Append("=0");

            return builder.ToString();
        }

        private static double ParseCoefficient(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 1;
            }

            return value switch
            {
                "+" => 1,
                "-" => -1,
                _ => Convert.ToDouble(value)
            };
        }
    }
}
