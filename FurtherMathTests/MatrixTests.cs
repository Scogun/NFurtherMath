using System.Collections.Generic;

using FurtherMath;
using FurtherMath.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurtherMathTests
{
    /// <summary>
    /// The matrix tests.
    /// </summary>
    [TestClass]
    public class MatrixTests
    {
        /// <summary>
        /// The to string.
        /// </summary>
        [TestMethod]
        public void String()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 11, 12 }, new double[] { 21, 22 } });
            Assert.AreEqual("11 12\r\n21 22", matrix.ToString());
        }

        /// <summary>
        /// The sum.
        /// </summary>
        [TestMethod]
        public void Sum()
        {
            Matrix firstMatrix = new Matrix(new List<double[]> { new double[] { 1, 2 }, new double[] { 3, 4 } });
            Matrix secondMatrix = new Matrix(new List<double[]> { new double[] { 4, 3 }, new double[] { 2, 1 } });
            Matrix sum = firstMatrix + secondMatrix;
            Assert.AreEqual("5 5\r\n5 5", sum.ToString());
            Matrix biggerMatrix = new Matrix(2, 3);
            Assert.ThrowsException<MatrixOperationException>(() => firstMatrix + biggerMatrix);
        }

        /// <summary>
        /// The scalar multiplication.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplication()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2 }, new double[] { 3, 4 } });
            Matrix result = 2 * matrix;
            Assert.AreEqual("2 4\r\n6 8", result.ToString());
        }

        /// <summary>
        /// The multiplication.
        /// </summary>
        [TestMethod]
        public void Multiplication()
        {
            Matrix firstMatrix = new Matrix(
                new List<double[]>
                    {
                        new double[] { 1, -1 },
                        new double[] { 2, 0 },
                        new double[] { 3, 0 }
                    });
            Matrix secondMatrix = new Matrix(new List<double[]> { new double[] { 1, 1 }, new double[] { 2, 0 } });
            Matrix sum = firstMatrix * secondMatrix;
            Assert.AreEqual("-1 1\r\n2 2\r\n3 3", sum.ToString());
            Matrix biggerMatrix = new Matrix(3, 2);
            Assert.ThrowsException<MatrixOperationException>(() => firstMatrix * biggerMatrix);
        }

        /// <summary>
        /// The subtraction.
        /// </summary>
        [TestMethod]
        public void Subtraction()
        {
            Matrix firstMatrix = new Matrix(new List<double[]> { new double[] { 5, 6 }, new double[] { 7, 8 } });
            Matrix secondMatrix = new Matrix(new List<double[]> { new double[] { 1, 2 }, new double[] { 3, 4 } });
            Matrix subtraction = firstMatrix - secondMatrix;
            Assert.AreEqual("4 4\r\n4 4", subtraction.ToString());
            Matrix biggerMatrix = new Matrix(2, 3);
            Assert.ThrowsException<MatrixOperationException>(() => firstMatrix - biggerMatrix);
        }

        /// <summary>
        /// The transposition.
        /// </summary>
        [TestMethod]
        public void Transposition()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });
            Assert.AreEqual("1 4\r\n2 5\r\n3 6", matrix.Transposition().ToString());
        }

        /// <summary>
        /// The minor.
        /// </summary>
        [TestMethod]
        public void Minor()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });
            Matrix minor = matrix.Minor(0, 0);
            Assert.AreEqual("5 6", minor.ToString());
            Assert.ThrowsException<MatrixSizeException>(() => minor.Minor(0, 0));
        }

        /// <summary>
        /// The determinant.
        /// </summary>
        [TestMethod]
        public void Determinant()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            Assert.AreEqual(69, matrix.Determinant());
            matrix = new Matrix(
                new List<double[]>
                    {
                        new double[] { 3, 3, -1 },
                        new double[] { 4, 1, 3 },
                        new double[] { 1, -2, -2 }
                    });
            Assert.AreEqual(54, matrix.Determinant());
            matrix = new Matrix(
                new List<double[]>
                    {
                        new double[] { -2, 1, 3, 2 },
                        new double[] { 3, 0, -1, 2 },
                        new double[] { -5, 2, 3, 0 },
                        new double[] { 4, -1, 2, -3 }
                    });
            Assert.AreEqual(-80, matrix.Determinant());
            Assert.ThrowsException<MatrixSizeException>(() => new Matrix(2, 3).Determinant());
        }

        /// <summary>
        /// The adjugate.
        /// </summary>
        [TestMethod]
        public void Adjugate()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 1 }, new double[] { 1, 2 } });
            Assert.AreEqual("2 -1\r\n-1 1", matrix.Adjugate().ToString());
            matrix = new Matrix(new List<double[]>
                                    {
                                        new double[] { 1, 0, 2 },
                                        new double[] { 2, -1, 1 },
                                        new double[] { 1, 3, -1 }
                                    });
            Assert.AreEqual("-2 3 7\r\n6 -3 -3\r\n2 3 -1", matrix.Adjugate().ToString());
        }

        /// <summary>
        /// The inverted.
        /// </summary>
        [TestMethod]
        public void Inverted()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 1 }, new double[] { 1, 2 } });
            Assert.AreEqual("2 -1\r\n-1 1", matrix.Inverted().ToString());
            matrix = new Matrix(new List<double[]>
                                    {
                                        new double[] { 1, 0, 2 },
                                        new double[] { 2, -1, 1 },
                                        new double[] { 1, 3, -1 }
                                    });
            Assert.AreEqual(Matrix.MakeIdentity(3), matrix * matrix.Inverted());
        }

        /// <summary>
        /// The equals.
        /// </summary>
        [TestMethod]
        public void Equals()
        {
            Matrix firstMatrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            Matrix secondMatrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            Assert.AreEqual(firstMatrix, secondMatrix);
            secondMatrix[0, 0] = 10;
            Assert.AreNotEqual(firstMatrix, secondMatrix);
        }

        /// <summary>
        /// The properties.
        /// </summary>
        [TestMethod]
        public void Properties()
        {
            Matrix a = new Matrix(new List<double[]> { new double[] { 1, 4 }, new double[] { 2, 3 } });
            Matrix b = new Matrix(new List<double[]> { new double[] { 4, 4 }, new double[] { 5, 2 } });
            Matrix c = a + b;
            Assert.AreEqual(a + b + c, a + (b + c));
            Assert.AreEqual(a + b, b + a);
            Assert.AreEqual(a * b * c, a * (b * c));
            Assert.AreNotEqual(a * b, b * a);
            Assert.AreEqual(a * (b + c), a * b + a * c);
            Assert.AreEqual(a, a.Transposition().Transposition());
            Assert.AreEqual((a * b).Transposition(), b.Transposition() * a.Transposition());
            Assert.AreEqual(a.Inverted().Transposition(), a.Transposition().Inverted());
            Assert.AreEqual((a + b).Transposition(), a.Transposition() + b.Transposition());
            Assert.AreEqual(a.Determinant(), a.Transposition().Determinant());
        }
    }
}
