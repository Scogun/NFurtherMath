using System;
using System.Collections.Generic;
using FluentAssertions;
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
            matrix.ToString().Should().Be("11 12\r\n21 22");
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
            sum.ToString().Should().Be("5 5\r\n5 5");
            Matrix biggerMatrix = new Matrix(2, 3);
            Func<Matrix> func = () => firstMatrix + biggerMatrix;
            func.Should().Throw<MatrixOperationException>();
        }

        /// <summary>
        /// The scalar multiplication.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplication()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2 }, new double[] { 3, 4 } });
            Matrix result = 2 * matrix;
            result.ToString().Should().Be("2 4\r\n6 8");
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
            sum.ToString().Should().Be("-1 1\r\n2 2\r\n3 3");
            Matrix biggerMatrix = new Matrix(3, 2);
            Func<Matrix> func = () => firstMatrix * biggerMatrix;
            func.Should().Throw<MatrixOperationException>();
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
            subtraction.ToString().Should().Be("4 4\r\n4 4");
            Matrix biggerMatrix = new Matrix(2, 3);
            Func<Matrix> func = () => firstMatrix - biggerMatrix;
            func.Should().Throw<MatrixOperationException>();
        }

        /// <summary>
        /// The transposition.
        /// </summary>
        [TestMethod]
        public void Transposition()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });
            matrix.Transposition().ToString().Should().Be("1 4\r\n2 5\r\n3 6");
        }

        /// <summary>
        /// The minor.
        /// </summary>
        [TestMethod]
        public void Minor()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 } });
            Matrix minor = matrix.Minor(0, 0);
            minor.ToString().Should().Be("5 6");
            Func<Matrix> func = () => minor.Minor(0, 0);
            func.Should().Throw<MatrixSizeException>();
        }

        /// <summary>
        /// The determinant.
        /// </summary>
        [TestMethod]
        public void Determinant()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            matrix.Determinant().Should().Be(69);
            matrix = new Matrix(
                new List<double[]>
                    {
                        new double[] { 3, 3, -1 },
                        new double[] { 4, 1, 3 },
                        new double[] { 1, -2, -2 }
                    });
            matrix.Determinant().Should().Be(54);
            matrix = new Matrix(
                new List<double[]>
                    {
                        new double[] { -2, 1, 3, 2 },
                        new double[] { 3, 0, -1, 2 },
                        new double[] { -5, 2, 3, 0 },
                        new double[] { 4, -1, 2, -3 }
                    });
            matrix.Determinant().Should().Be(-80);
            Func<double> func = () => new Matrix(2, 3).Determinant();
            func.Should().Throw<MatrixSizeException>();
        }

        /// <summary>
        /// The adjugate.
        /// </summary>
        [TestMethod]
        public void Adjugate()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 1 }, new double[] { 1, 2 } });
            matrix.Adjugate().ToString().Should().Be("2 -1\r\n-1 1");
            matrix = new Matrix(new List<double[]>
                                    {
                                        new double[] { 1, 0, 2 },
                                        new double[] { 2, -1, 1 },
                                        new double[] { 1, 3, -1 }
                                    });
            matrix.Adjugate().ToString().Should().Be("-2 3 7\r\n6 -3 -3\r\n2 3 -1");
        }

        /// <summary>
        /// The inverted.
        /// </summary>
        [TestMethod]
        public void Inverted()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 1, 1 }, new double[] { 1, 2 } });
            matrix.Inverted().ToString().Should().Be("2 -1\r\n-1 1");
            matrix = new Matrix(new List<double[]>
                                    {
                                        new double[] { 1, 0, 2 },
                                        new double[] { 2, -1, 1 },
                                        new double[] { 1, 3, -1 }
                                    });
            (matrix * matrix.Inverted()).Should().Be(Matrix.MakeIdentity(3));
        }

        /// <summary>
        /// The equals.
        /// </summary>
        [TestMethod]
        public void Equals()
        {
            Matrix firstMatrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            Matrix secondMatrix = new Matrix(new List<double[]> { new double[] { 11, -2 }, new double[] { 7, 5 } });
            firstMatrix.Should().Be(secondMatrix);
            secondMatrix[0, 0] = 10;
            firstMatrix.Should().NotBe(secondMatrix);
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
            (a + b + c).Should().Be(a + (b + c));
            (a + b).Should().Be(b + a);
            (a * b * c).Should().Be(a * (b * c));
            (a * b).Should().NotBe(b * a);
            (a * (b + c)).Should().Be(a * b + a * c);
            a.Transposition().Transposition().Should().Be(a);
            (a * b).Transposition().Should().Be(b.Transposition() * a.Transposition());
            a.Inverted().Transposition().Should().Be(a.Transposition().Inverted());
            (a + b).Transposition().Should().Be(a.Transposition() + b.Transposition());
            a.Determinant().Should().Be(a.Transposition().Determinant());
        }
    }
}
