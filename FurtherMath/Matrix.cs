using System.Collections.Generic;
using System.Text;

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
            structure = new double[rows.Count, rows[0].Length];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    structure[i, j] = rows[i][j];
                }
            }
        }

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
            get
            {
                return structure[rowIndex, colIndex];
            }

            set
            {
                structure[rowIndex, colIndex] = value;
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int rowCount = this.structure.GetLength(0);
            int colCount = this.structure.GetLength(1);
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
