using System;
using System.Globalization;

using FurtherMath;

using Xunit;

namespace FurtherMathTests
{
    /// <summary>
    /// The complex tests.
    /// </summary>
    public class ComplexTests
    {
        /// <summary>
        /// The sum.
        /// </summary>
        [Fact]
        public void Sum()
        {
            Complex firstComplex = new Complex(1, 1);
            Complex secondComplex = new Complex(2, 2);
            Complex thirdComplex = firstComplex + secondComplex;
            Assert.Equal("3+3i", thirdComplex.ToString());
        }

        /// <summary>
        /// The subtraction.
        /// </summary>
        [Fact]
        public void Subtraction()
        {
            Complex firstComplex = new Complex(3, 4);
            Complex secondComplex = new Complex(2, 2);
            Complex thirdComplex = firstComplex - secondComplex;
            Assert.Equal("1+2i", thirdComplex.ToString());
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
        [Theory]
        [InlineData(1, 1, 2, 2, "4i")]
        [InlineData(0, 1, 0, 1, "-1")]
        public void Multiplication(int firstReal, int firstImaginary, int secondReal, int secondImaginary, string result)
        {
            Complex firstComplex = new Complex(firstReal, firstImaginary);
            Complex secondComplex = new Complex(secondReal, secondImaginary);
            Complex thirdComplex = firstComplex * secondComplex;
            Assert.Equal(result, thirdComplex.ToString());
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
        [Theory]
        [InlineData(1, 1, 2, 2, "0.5")]
        [InlineData(2, 2, 1, 1, "2")]
        [InlineData(5, 10, 4, 2, "2+1.5i")]
        public void Division(int firstReal, int firstImaginary, int secondReal, int secondImaginary, string result)
        {
            Complex firstComplex = new Complex(firstReal, firstImaginary);
            Complex secondComplex = new Complex(secondReal, secondImaginary);
            Complex thirdComplex = firstComplex / secondComplex;
            Assert.Equal(result.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator), thirdComplex.ToString());
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        [Fact]
        public void Conjugate()
        {
            Complex complex = new Complex(5, 6);
            Assert.Equal("5-6i", Complex.Conjugate(complex).ToString());
            Assert.Equal("5-6i", complex.Conjugate().ToString());
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        [Fact]
        public void ToMatrix()
        {
            Complex complex = new Complex(1, 2);
            Assert.Equal("1 -2\r\n2 1", Complex.ToMatrix(complex).ToString());
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
        [Theory]
        [InlineData(3, 4, 5)]
        public void Abs(int real, int imaginary, double result)
        {
            Complex complex = new Complex(real, imaginary);
            Assert.Equal(result, complex.Abs());
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
        [Theory]
        [InlineData(1, 1, Math.PI / 4)]
        public void Arg(int real, int imaginary, double result)
        {
            Complex complex = new Complex(real, imaginary);
            Assert.Equal(result, complex.Arg());
        }

        /// <summary>
        /// The equals.
        /// </summary>
        [Fact]
        public void Equals()
        {
            Complex firstComplex = new Complex(1, 4);
            Complex relinkComplex = firstComplex;
            Complex secondComplex = new Complex(1, 4);
            Assert.True(firstComplex.Equals(secondComplex));
            Assert.True(firstComplex == relinkComplex);
            Assert.True(firstComplex == secondComplex);
            Assert.False(firstComplex != secondComplex);
        }
    }
}
