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
            Assert.Equal(thirdComplex.ToString(), "3+3i");
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
            Assert.Equal(thirdComplex.ToString(), "1+2i");
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
            Assert.Equal(thirdComplex.ToString(), result);
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
        [InlineData(1, 1, 2, 2, "0,5")]
        [InlineData(2, 2, 1, 1, "2")]
        [InlineData(5, 10, 4, 2, "2+1,5i")]
        public void Division(int firstReal, int firstImaginary, int secondReal, int secondImaginary, string result)
        {
            Complex firstComplex = new Complex(firstReal, firstImaginary);
            Complex secondComplex = new Complex(secondReal, secondImaginary);
            Complex thirdComplex = firstComplex / secondComplex;
            Assert.Equal(thirdComplex.ToString(), result);
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        [Fact]
        public void Conjugate()
        {
            Complex complex = new Complex(5, 6);
            Assert.Equal(Complex.Conjugate(complex).ToString(), "5-6i");
            Assert.Equal(complex.Conjugate().ToString(), "5-6i");
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        [Fact]
        public void ToMatrix()
        {
            Complex complex = new Complex(1, 2);
            Assert.Equal(Complex.ToMatrix(complex).ToString(), "1 -2 \r\n2 1 \r\n");
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
