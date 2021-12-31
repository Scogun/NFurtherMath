using System;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurtherMath.Tests
{
    /// <summary>
    /// The complex tests.
    /// </summary>
    [TestClass]
    public class ComplexTests
    {
        /// <summary>
        /// The sum.
        /// </summary>
        [TestMethod]
        public void Sum()
        {
            Complex firstComplex = new Complex(1, 1);
            Complex secondComplex = new Complex(2, 2);
            Complex thirdComplex = firstComplex + secondComplex;
            thirdComplex.ToString(ComplexDisplay.Algebraic).Should().Be("3+3i");
        }

        /// <summary>
        /// The subtraction.
        /// </summary>
        [TestMethod]
        public void Subtraction()
        {
            Complex firstComplex = new Complex(3, 4);
            Complex secondComplex = new Complex(2, 2);
            Complex thirdComplex = firstComplex - secondComplex;
            thirdComplex.ToString(ComplexDisplay.Algebraic).Should().Be("1+2i");
        }

        /// <summary>
        /// The multiplication.
        /// </summary>
        /// <param name="firstReal">
        /// The first Real.
        /// </param>
        /// <param name="firstImaginary">
        /// The first Imaginary.
        /// </param>
        /// <param name="secondReal">
        /// The second Real.
        /// </param>
        /// <param name="secondImaginary">
        /// The second Imaginary.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        [DataTestMethod]
        [DataRow(1, 1, 2, 2, "4i")]
        [DataRow(0, 1, 0, 1, "-1")]
        public void Multiplication(int firstReal, int firstImaginary, int secondReal, int secondImaginary, string result)
        {
            Complex firstComplex = new Complex(firstReal, firstImaginary);
            Complex secondComplex = new Complex(secondReal, secondImaginary);
            Complex thirdComplex = firstComplex * secondComplex;
            thirdComplex.ToString(ComplexDisplay.Algebraic).Should().Be(result);
        }

        /// <summary>
        /// The division.
        /// </summary>
        /// <param name="firstReal">
        /// The first Real.
        /// </param>
        /// <param name="firstImaginary">
        /// The first Imaginary.
        /// </param>
        /// <param name="secondReal">
        /// The second Real.
        /// </param>
        /// <param name="secondImaginary">
        /// The second Imaginary.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        [DataTestMethod]
        [DataRow(1, 1, 2, 2, "0.5")]
        [DataRow(2, 2, 1, 1, "2")]
        [DataRow(5, 10, 4, 2, "2+1.5i")]
        public void Division(int firstReal, int firstImaginary, int secondReal, int secondImaginary, string result)
        {
            Complex firstComplex = new Complex(firstReal, firstImaginary);
            Complex secondComplex = new Complex(secondReal, secondImaginary);
            Complex thirdComplex = firstComplex / secondComplex;
            thirdComplex.ToString(ComplexDisplay.Algebraic).Should().Be(result.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        [TestMethod]
        public void Conjugate()
        {
            Complex complex = new Complex(5, 6);
            Complex.Conjugate(complex).ToString(ComplexDisplay.Algebraic).Should().Be("5-6i");
            complex.Conjugate().ToString(ComplexDisplay.Algebraic).Should().Be("5-6i");
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        [TestMethod]
        public void ToMatrix()
        {
            Complex complex = new Complex(1, 2);
            complex.ToMatrix().ToString().Should().Be("1 -2\r\n2 1");
        }

        /// <summary>
        /// The abs.
        /// </summary>
        /// <param name="real">
        /// The real.
        /// </param>
        /// <param name="imaginary">
        /// The imaginary.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        [DataTestMethod]
        [DataRow(3, 4, 5)]
        public void Abs(int real, int imaginary, double result)
        {
            Complex complex = new Complex(real, imaginary);
            complex.Abs().Should().Be(result);
        }

        /// <summary>
        /// The argument.
        /// </summary>
        /// <param name="real">
        /// The real.
        /// </param>
        /// <param name="imaginary">
        /// The imaginary.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        [DataTestMethod]
        [DataRow(1, 1, Math.PI / 4)]
        public void Arg(int real, int imaginary, double result)
        {
            Complex complex = new Complex(real, imaginary);
            complex.Arg().Should().Be(result);
        }

        /// <summary>
        /// The trigonometric display.
        /// </summary>
        [TestMethod]
        public void TrigonometricDisplay()
        {
            Complex complex = new Complex(3, 4);
            complex.ToString(ComplexDisplay.Trigonometric).Should().Be("5*(cos(0.9272952180016122) + i*sin(0.9272952180016122))".Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
        }

        /// <summary>
        /// The equals.
        /// </summary>
        [TestMethod]
        public void Equals()
        {
            Complex firstComplex = new Complex(1, 4);
            Complex relinkComplex = firstComplex;
            Complex secondComplex = new Complex(1, 4);
            firstComplex.Equals(secondComplex).Should().BeTrue();
            (firstComplex == relinkComplex).Should().BeTrue();
            (firstComplex == secondComplex).Should().BeTrue();
            (firstComplex != secondComplex).Should().BeFalse();
        }

        /// <summary>
        /// The properties.
        /// </summary>
        [TestMethod]
        public void Properties()
        {
            Complex a = new Complex(1, 4);
            Complex b = new Complex(2, 5);
            Complex c = a + b;
            (a + b).Should().Be(b + a);
            (a * b).Should().Be(b * a);
            (a * (b + c)).Should().Be(a * b + a * c);
        }
    }
}
