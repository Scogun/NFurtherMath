using FurtherMath;

using Xunit;

namespace FurtherMathTests
{
    /// <summary>
    /// The quaternion tests.
    /// </summary>
    public class QuaternionTests
    {
        /// <summary>
        /// The multiplication.
        /// </summary>
        /// <param name="firstReal">
        /// The first Real.
        /// </param>
        /// <param name="firstIImaginary">
        /// The first I Imaginary.
        /// </param>
        /// <param name="firstJImaginary">
        /// The first J Imaginary.
        /// </param>
        /// <param name="firstKImaginary">
        /// The first K Imaginary.
        /// </param>
        /// <param name="secondReal">
        /// The second Real.
        /// </param>
        /// <param name="secondIImaginary">
        /// The second I Imaginary.
        /// </param>
        /// <param name="secondJImaginary">
        /// The second J Imaginary.
        /// </param>
        /// <param name="secondKImaginary">
        /// The second K Imaginary.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        [Theory]
        [InlineData(2, 3, 4, 5, 1, 1, 1, 1, "-10+4i+8j+6k")]
        [InlineData(2, 3, 4, 5, 6, 7, 8, 9, "-86+28i+48j+44k")]
        [InlineData(2, 1, 4, 0, 6, 7, 0, 9, "5+56i+15j-10k")]
        public void Multiplication(double firstReal, double firstIImaginary, double firstJImaginary, double firstKImaginary, double secondReal, double secondIImaginary, double secondJImaginary, double secondKImaginary, string result)
        {
            Quaternion firstQuaternion = new Quaternion(firstReal, firstIImaginary, firstJImaginary, firstKImaginary);
            Quaternion secondQuaternion = new Quaternion(secondReal, secondIImaginary, secondJImaginary, secondKImaginary);
            Quaternion thirdQuaternion = firstQuaternion * secondQuaternion;
            Assert.Equal(result, thirdQuaternion.ToString());
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        [Fact]
        public void ToMatrix()
        {
            Quaternion quaternion = new Quaternion(1, 2, 3, 4);
            Assert.Equal("1 -2 -3 -4\r\n2 1 -4 3\r\n3 4 1 -2\r\n4 -3 2 1", quaternion.ToMatrix().ToString());
        }

        /// <summary>
        /// The norm.
        /// </summary>
        [Fact]
        public void Abs()
        {
            Quaternion quaternion = new Quaternion(2, 2, 2, 2);
            Assert.Equal(4, quaternion.Abs());
        }

        /// <summary>
        /// The operations.
        /// </summary>
        [Fact]
        public void Operations()
        {
            Quaternion firstQuaternion = new Quaternion(2, 3, 4, 5);
            Quaternion secondQuaternion = new Quaternion(6, 7, 8, 9);
            Assert.Equal(
                (firstQuaternion * secondQuaternion).Conjugate(),
                secondQuaternion.Conjugate() * firstQuaternion.Conjugate());
        }
    }
}
