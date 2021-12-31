using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FurtherMath
{
    /// <summary>
    /// The complex display.
    /// </summary>
    public enum ComplexDisplay
    {
        /// <summary>
        /// The default.
        /// </summary>
        Default,

        /// <summary>
        /// The algebraic.
        /// </summary>
        Algebraic,

        /// <summary>
        /// The trigonometric.
        /// </summary>
        Trigonometric
    }

    public static class ComplexExtensions
    {
        /// <summary>
        /// The precision.
        /// </summary>
        internal static double Precision => 1 * Math.Pow(10, -15);

        public static Complex Conjugate(this Complex complex)
        {
            return Complex.Conjugate(complex);
        }

        public static double Abs(this Complex complex)
        {
            return Complex.Abs(complex);
        }

        public static double Arg(this Complex complex)
        {
            return Math.Atan(complex.Imaginary / complex.Real);
        }

        public static string ToString(this Complex complex, ComplexDisplay format)
        {
            return format switch
            {
                ComplexDisplay.Algebraic => AlgebraicDisplay(complex),
                ComplexDisplay.Trigonometric => TrigonometricDisplay(complex),
                _ => complex.ToString()
            };
        }

        public static Matrix ToMatrix(this Complex complex)
        {
            return new Matrix(
                new List<double[]>
                {
                    new[] { complex.Real, -complex.Imaginary },
                    new[] { complex.Imaginary, complex.Real }
                });
        }

        /// <summary>
        /// The algebraic display.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string AlgebraicDisplay(Complex complex)
        {
            StringBuilder builder = new StringBuilder();
            if (Math.Abs(complex.Real) > Precision)
            {
                builder.Append(complex.Real);
            }

            if (Math.Abs(complex.Real) > Precision && Math.Abs(complex.Imaginary) > Precision)
            {
                if (complex.Imaginary > 0)
                {
                    builder.Append("+");
                }
            }

            if (Math.Abs(complex.Imaginary) > Precision)
            {
                builder.Append($"{complex.Imaginary}i");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The algebraic display.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string TrigonometricDisplay(Complex complex)
        {
            double abs = Abs(complex);
            if (abs > Precision)
            {
                double arg = Arg(complex);
                return $"{abs}*(cos({arg}) + i*sin({arg}))";
            }

            return "0";
        }
    }
}
