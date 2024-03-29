﻿#if NET6_0_OR_GREATER
using System.Numerics;
#endif
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurtherMath.Tests
{
    /// <summary>
    /// The quaternion tests.
    /// </summary>
    [TestClass]
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
        [DataTestMethod]
        [DataRow(2, 3, 4, 5, 1, 1, 1, 1, "3+4i+5j+6k")]
        [DataRow(2, 3, 4, 5, 6, 7, 8, 9, "8+10i+12j+14k")]
        [DataRow(2, 1, 4, 0, 6, 7, 0, 9, "8+8i+4j+9k")]
        public void Sum(float firstReal, float firstIImaginary, float firstJImaginary, float firstKImaginary, float secondReal, float secondIImaginary, float secondJImaginary, float secondKImaginary, string result)
        {
            Quaternion firstQuaternion = new Quaternion(firstIImaginary, firstJImaginary, firstKImaginary, firstReal);
            Quaternion secondQuaternion = new Quaternion(secondIImaginary, secondJImaginary, secondKImaginary, secondReal);
            Quaternion thirdQuaternion = firstQuaternion + secondQuaternion;
            thirdQuaternion.ToString(QuaternionDisplay.Algebraic).Should().Be(result);
        }

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
        [DataTestMethod]
        [DataRow(2, 3, 4, 5, 1, 1, 1, 1, "1+2i+3j+4k")]
        [DataRow(2, 3, 4, 5, 6, 7, 8, 9, "-4-4i-4j-4k")]
        [DataRow(2, 1, 4, 0, 6, 7, 0, 9, "-4-6i+4j-9k")]
        public void Subtraction(float firstReal, float firstIImaginary, float firstJImaginary, float firstKImaginary, float secondReal, float secondIImaginary, float secondJImaginary, float secondKImaginary, string result)
        {
            Quaternion firstQuaternion = new Quaternion(firstIImaginary, firstJImaginary, firstKImaginary, firstReal);
            Quaternion secondQuaternion = new Quaternion(secondIImaginary, secondJImaginary, secondKImaginary, secondReal);
            Quaternion thirdQuaternion = firstQuaternion - secondQuaternion;
            thirdQuaternion.ToString(QuaternionDisplay.Algebraic).Should().Be(result);
        }

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
        [DataTestMethod]
        [DataRow(2, 3, 4, 5, 1, 1, 1, 1, "-10+4i+8j+6k")]
        [DataRow(2, 3, 4, 5, 6, 7, 8, 9, "-86+28i+48j+44k")]
        [DataRow(2, 1, 4, 0, 6, 7, 0, 9, "5+56i+15j-10k")]
        public void Multiplication(float firstReal, float firstIImaginary, float firstJImaginary, float firstKImaginary, float secondReal, float secondIImaginary, float secondJImaginary, float secondKImaginary, string result)
        {
            Quaternion firstQuaternion = new Quaternion(firstIImaginary, firstJImaginary, firstKImaginary, firstReal);
            Quaternion secondQuaternion = new Quaternion(secondIImaginary, secondJImaginary, secondKImaginary, secondReal);
            Quaternion thirdQuaternion = firstQuaternion * secondQuaternion;
            thirdQuaternion.ToString(QuaternionDisplay.Algebraic).Should().Be(result);
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        [TestMethod]
        public void ToMatrix()
        {
            Quaternion quaternion = new Quaternion(2, 3, 4, 1);
            quaternion.ToMatrix().ToString().Should().Be("1 -2 -3 -4\r\n2 1 -4 3\r\n3 4 1 -2\r\n4 -3 2 1");
        }

        /// <summary>
        /// The norm.
        /// </summary>
        [TestMethod]
        public void Norm()
        {
            Quaternion quaternion = new Quaternion(2, 2, 2, 2);
            quaternion.Norm().Should().Be(16);
        }

        /// <summary>
        /// The absolute.
        /// </summary>
        [TestMethod]
        public void Abs()
        {
            Quaternion quaternion = new Quaternion(2, 2, 2, 2);
            quaternion.Abs().Should().Be(4);
        }

        /// <summary>
        /// The operations.
        /// </summary>
        [TestMethod]
        public void Operations()
        {
            Quaternion firstQuaternion = new Quaternion(3, 4, 5, 2);
            Quaternion secondQuaternion = new Quaternion(7, 8, 9, 6);
            (firstQuaternion * secondQuaternion).Conjugate().Should().Be(secondQuaternion.Conjugate() * firstQuaternion.Conjugate());
        }
    }
}
