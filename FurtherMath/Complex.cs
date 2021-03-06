﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FurtherMath
{
    /// <summary>
    /// The complex display.
    /// </summary>
    public enum ComplexDisplay
    {
        /// <summary>
        /// The algebraic.
        /// </summary>
        Algebraic,

        /// <summary>
        /// The trigonometric.
        /// </summary>
        Trigonometric
    }

    /// <summary>
    /// The complex number.
    /// </summary>
    public class Complex
    {
        /// <summary>
        /// The real part.
        /// </summary>
        private readonly double real;

        /// <summary>
        /// The imaginary part.
        /// </summary>
        private readonly double imaginary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="real">
        /// The real.
        /// </param>
        /// <param name="imaginary">
        /// The imaginary.
        /// </param>
        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        /// <summary>
        /// The precision.
        /// </summary>
        internal static double Precision => 1 * Math.Pow(10, -15);

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The sum.
        /// </returns>
        public static Complex operator +(Complex firstComplex, Complex secondComplex)
        {
            return new Complex(firstComplex.real + secondComplex.real, firstComplex.imaginary + secondComplex.imaginary);
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The subtraction.
        /// </returns>
        public static Complex operator -(Complex firstComplex, Complex secondComplex)
        {
            return new Complex(firstComplex.real - secondComplex.real, firstComplex.imaginary - secondComplex.imaginary);
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The Multiplication.
        /// </returns>
        public static Complex operator *(Complex firstComplex, Complex secondComplex)
        {
            double realMultiplication = firstComplex.real * secondComplex.real;
            double imaginaryMultiplication = firstComplex.imaginary * secondComplex.imaginary;
            double firstCrosMultiplication = firstComplex.real * secondComplex.imaginary;
            double secondCrosMultiplication = firstComplex.imaginary * secondComplex.real;
            return new Complex(realMultiplication - imaginaryMultiplication, firstCrosMultiplication + secondCrosMultiplication);
        }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The division.
        /// </returns>
        public static Complex operator /(Complex firstComplex, Complex secondComplex)
        {
            double realMultiplication = firstComplex.real * secondComplex.real;
            double imaginaryMultiplication = firstComplex.imaginary * secondComplex.imaginary;
            double realPartNumerator = realMultiplication + imaginaryMultiplication;
            double realPartDenaminator = Math.Pow(secondComplex.real, 2) + Math.Pow(secondComplex.imaginary, 2);
            double realPart = realPartNumerator / realPartDenaminator;
            double firstCrosMultiplication = firstComplex.imaginary * secondComplex.real;
            double secondCrosMultiplication = firstComplex.real * secondComplex.imaginary;
            double imaginaryPartNumerator = firstCrosMultiplication - secondCrosMultiplication;
            double imaginaryPartDenaminator = realPartDenaminator;
            double imaginaryPart = imaginaryPartNumerator / imaginaryPartDenaminator;
            return new Complex(realPart, imaginaryPart);
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The equals.
        /// </returns>
        public static bool operator ==(Complex firstComplex, Complex secondComplex)
        {
            if (ReferenceEquals(firstComplex, secondComplex))
            {
                return true;
            }

            if ((object)firstComplex == null)
            {
                return false;
            }

            return firstComplex.Equals(secondComplex);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="firstComplex">
        /// The first complex.
        /// </param>
        /// <param name="secondComplex">
        /// The second complex.
        /// </param>
        /// <returns>
        /// The unequalled.
        /// </returns>
        public static bool operator !=(Complex firstComplex, Complex secondComplex)
        {
            return !(firstComplex == secondComplex);
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        /// <param name="complex">
        /// The complex.
        /// </param>
        /// <returns>
        /// The <see cref="Complex"/>.
        /// </returns>
        public static Complex Conjugate(Complex complex)
        {
            return new Complex(complex.real, -complex.imaginary);
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        /// <param name="complex">
        /// The complex.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public static Matrix ToMatrix(Complex complex)
        {
            return new Matrix(
                new List<double[]>
                    {
                        new[] { complex.real, -complex.imaginary },
                        new[] { complex.imaginary, complex.real }
                    });
        }

        /// <summary>
        /// The abs.
        /// </summary>
        /// <param name="complex">
        /// The complex.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double Abs(Complex complex)
        {
            return Math.Sqrt(Math.Pow(complex.real, 2) + Math.Pow(complex.imaginary, 2));
        }

        /// <summary>
        /// The argument.
        /// </summary>
        /// <param name="complex">
        /// The complex.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double Arg(Complex complex)
        {
            return Math.Atan(complex.imaginary / complex.real);
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        /// <returns>
        /// The <see cref="Complex"/>.
        /// </returns>
        public Complex Conjugate()
        {
            return Conjugate(this);
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix ToMatrix()
        {
            return ToMatrix(this);
        }

        /// <summary>
        /// The abs.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Abs()
        {
            return Abs(this);
        }

        /// <summary>
        /// The argument.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Arg()
        {
            return Arg(this);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            Complex secondComplex = obj as Complex;
            if (secondComplex == null)
            {
                return false;
            }

            return Math.Abs(real - secondComplex.real) < Precision && Math.Abs(imaginary - secondComplex.imaginary) < Precision;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return (real.GetHashCode() * 397) ^ imaginary.GetHashCode();
            }
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <param name="display">
        /// The display.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ToString(ComplexDisplay display)
        {
            switch (display)
            {
                case ComplexDisplay.Trigonometric:
                    return TrigonometricDisplay();
                default:
                    return AlgebraicDisplay();
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return AlgebraicDisplay();
        }

        /// <summary>
        /// The algebraic display.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string AlgebraicDisplay()
        {
            StringBuilder builder = new StringBuilder();
            if (Math.Abs(real) > Precision)
            {
                builder.Append(real);
            }

            if (Math.Abs(real) > Precision && Math.Abs(imaginary) > Precision)
            {
                if (imaginary > 0)
                {
                    builder.Append("+");
                }
            }

            if (Math.Abs(imaginary) > Precision)
            {
                builder.Append($"{imaginary}i");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The algebraic display.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string TrigonometricDisplay()
        {
            double abs = Abs();
            if (abs > Precision)
            {
                double arg = Arg();
                return $"{abs}*(cos({arg}) + i*sin({arg}))";
            }

            return "0";
        }
    }
}
