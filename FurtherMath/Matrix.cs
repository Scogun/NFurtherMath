using System;
using System.Collections.Generic;
using System.Text;

using FurtherMath.Exceptions;

namespace FurtherMath
{
    /// <summary>
    /// The matrix.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// The structure.
        /// </summary>
        private readonly double[,] structure;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rowNumber">
        /// The row number.
        /// </param>
        /// <param name="colNumber">
        /// The col number.
        /// </param>
        public Matrix(int rowNumber, int colNumber)
        {
            structure = new double[rowNumber, colNumber];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        public Matrix(List<double[]> rows)
        {
            int colNumber = rows[0].Length;
            structure = new double[rows.Count, colNumber];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < Math.Max(rows[i].Length, colNumber); j++)
                {
                    structure[i, j] = rows[i][j];
                }
            }
        }

        /// <summary>
        /// Gets the row count.
        /// </summary>
        public int RowCount => structure.GetLength(0);

        /// <summary>
        /// Gets the column count.
        /// </summary>
        public int ColCount => structure.GetLength(1);

        /// <summary>
        /// Gets the rows.
        /// </summary>
        public List<double[]> Rows
        {
            get
            {
                List<double[]> rows = new List<double[]>(RowCount);
                for (int i = 0; i < RowCount; i++)
                {
                    double[] row = new double[ColCount];
                    for (int j = 0; j < ColCount; j++)
                    {
                        row[j] = this[i, j];
                    }

                    rows.Add(row);
                }

                return rows;
            }
        }

        /// <summary>
        /// The precision.
        /// </summary>
        internal static double Precision => 1 * Math.Pow(10, -15);

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="rowIndex">
        /// The row index.
        /// </param>
        /// <param name="colIndex">
        /// The col index.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double this[int rowIndex, int colIndex]
        {
            get => structure[rowIndex, colIndex];

            set => structure[rowIndex, colIndex] = value;
        }

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="firstMatrix">
        /// The first matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second matrix.
        /// </param>
        /// <returns>
        /// The sum.
        /// </returns>
        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.RowCount != secondMatrix.RowCount || firstMatrix.ColCount != secondMatrix.ColCount)
            {
                throw new MatrixOperationException("For sum operation both matrix must have the same dimensions!");
            }

            List<double[]> data = new List<double[]>(firstMatrix.RowCount);
            for (int i = 0; i < firstMatrix.RowCount; i++)
            {
                double[] row = new double[firstMatrix.ColCount];
                for (int j = 0; j < firstMatrix.ColCount; j++)
                {
                    row[j] = firstMatrix[i, j] + secondMatrix[i, j];
                }

                data.Add(row);
            }

            return new Matrix(data);
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="firstMatrix">
        /// The first matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second matrix.
        /// </param>
        /// <returns>
        /// The subtraction.
        /// </returns>
        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix negativeMatrix = -1 * secondMatrix;
            return firstMatrix + negativeMatrix;
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <param name="scalar">
        /// The scalar.
        /// </param>
        /// <returns>
        /// The multiplication.
        /// </returns>
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            List<double[]> rows = matrix.Rows;
            foreach (double[] row in rows)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    row[i] *= scalar;
                }
            }

            return new Matrix(rows);
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="scalar">
        /// The scalar.
        /// </param>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <returns>
        /// The multiplication.
        /// </returns>
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return matrix * scalar;
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="firstMatrix">
        /// The first matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second matrix.
        /// </param>
        /// <returns>
        /// The multiplication.
        /// </returns>
        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.ColCount != secondMatrix.RowCount)
            {
                throw new MatrixOperationException("For multiplication first matrix column count must be equal to second matrix row count!");
            }

            Matrix result = new Matrix(firstMatrix.RowCount, secondMatrix.ColCount);
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = 0; j < result.ColCount; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < firstMatrix.ColCount; k++)
                    {
                        sum += firstMatrix[i, k] * secondMatrix[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// The transposition.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public static Matrix Transposition(Matrix matrix)
        {
            List<double[]> rows = new List<double[]>(matrix.ColCount);
            for (int j = 0; j < matrix.ColCount; j++)
            {
                double[] row = new double[matrix.RowCount];
                for (int i = 0; i < matrix.RowCount; i++)
                {
                    row[i] = matrix[i, j];
                }

                rows.Add(row);
            }

            return new Matrix(rows);
        }

        /// <summary>
        /// The minor.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <param name="rowIndex">
        /// The row index.
        /// </param>
        /// <param name="colIndex">
        /// The col index.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        /// <exception cref="MatrixSizeException">
        /// Matrix is too small to take a minor.
        /// </exception>
        public static Matrix Minor(Matrix matrix, int rowIndex, int colIndex)
        {
            if (matrix.RowCount < 2 || matrix.ColCount < 2)
            {
                throw new MatrixSizeException("For take a minor matrix must have size 2x2 or bigger!");
            }

            List<double[]> rows = new List<double[]>(matrix.RowCount - 1);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                if (i == rowIndex)
                {
                    continue;
                }

                double[] row = new double[matrix.ColCount - 1];
                for (int j = 0, k = 0; j < matrix.ColCount; j++)
                {
                    if (j == colIndex)
                    {
                        continue;
                    }

                    row[k++] = matrix[i, j];
                }

                rows.Add(row);
            }

            return new Matrix(rows);
        }

        /// <summary>
        /// The determinant.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="MatrixSizeException">
        /// Matrix is not square.
        /// </exception>
        public static double Determinant(Matrix matrix)
        {
            if (matrix.RowCount != matrix.ColCount)
            {
                throw new MatrixSizeException("Determinant is available only for square matrix!");
            }

            if (matrix.RowCount == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double result = 0;
            for (int i = 0; i < matrix.ColCount; i++)
            {
                result += Math.Pow(-1, i) * matrix[0, i] * matrix.Minor(0, i).Determinant();
            }

            return result;
        }

        /// <summary>
        /// The adjugate.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        /// <exception cref="MatrixSizeException">
        /// Matrix is not square.
        /// </exception>
        public static Matrix Adjugate(Matrix matrix)
        {
            if (matrix.RowCount != matrix.ColCount)
            {
                throw new MatrixSizeException("Adjugate matrix is available only for square matrix!");
            }            

            Matrix result = new Matrix(matrix.RowCount, matrix.ColCount);
            if (matrix.RowCount == 2)
            {
                result[0, 0] = matrix[1, 1];
                result[0, 1] = -matrix[0, 1];
                result[1, 0] = -matrix[1, 0];
                result[1, 1] = matrix[0, 0];
            }
            else
            {
                for (int i = 0; i < matrix.RowCount; i++)
                {
                    for (int j = 0; j < matrix.ColCount; j++)
                    {
                        result[i, j] = Math.Pow(-1, i + j) * matrix.Minor(i, j).Determinant();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// The inverted.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        /// <exception cref="MatrixSizeException">
        /// Matrix is not square.
        /// </exception>
        /// <exception cref="MatrixOperationException">
        /// Matrix is degenerate.
        /// </exception>
        public static Matrix Inverted(Matrix matrix)
        {
            double determinant;
            try
            {
                determinant = matrix.Determinant();
            }
            catch (MatrixSizeException)
            {
                throw new MatrixSizeException("Only for square matrix possible to find inverse matrix!");
            }

            if (Math.Abs(determinant) < Precision)
            {
                throw new MatrixOperationException("There is not inverted matrix for degenerate matrix!");
            }

            return 1 / determinant * matrix.Adjugate().Transposition();
        }

        /// <summary>
        /// The make identity.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public static Matrix MakeIdentity(int size)
        {
            Matrix result = new Matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = i == j ? 1 : 0;
                }
            }

            return result;
        }

        /// <summary>
        /// The transposition.
        /// </summary>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix Transposition()
        {
            return Transposition(this);
        }

        /// <summary>
        /// The minor.
        /// </summary>
        /// <param name="rowIndex">
        /// The row Index.
        /// </param>
        /// <param name="colIndex">
        /// The col Index.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix Minor(int rowIndex, int colIndex)
        {
            return Minor(this, rowIndex, colIndex);
        }

        /// <summary>
        /// The determinant.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Determinant()
        {
            return Determinant(this);
        }

        /// <summary>
        /// The adjugate.
        /// </summary>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix Adjugate()
        {
            return Adjugate(this);
        }

        /// <summary>
        /// The inverted.
        /// </summary>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix Inverted()
        {
            return Inverted(this);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            Matrix otherMatrix = obj as Matrix;
            if (otherMatrix == null)
            {
                return false;
            }

            if (RowCount != otherMatrix.RowCount || ColCount != otherMatrix.ColCount)
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    if (Math.Abs(this[i, j] - otherMatrix[i, j]) > Precision)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return structure != null ? structure.GetHashCode() : 0;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int rowCount = RowCount;
            int colCount = ColCount;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    builder.Append(structure[i, j]);
                    if (j < colCount - 1)
                    {
                        builder.Append(" ");
                    }
                }

                if (i < rowCount - 1)
                {
                    builder.Append("\r\n");
                }
            }

            return builder.ToString();
        }
    }
}