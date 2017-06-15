using System.Collections.Generic;

using FurtherMath;

using Xunit;

namespace FurtherMathTests
{
    /// <summary>
    /// The matrix tests.
    /// </summary>
    public class MatrixTests
    {
        /// <summary>
        /// The to string.
        /// </summary>
        [Fact]
        public void String()
        {
            Matrix matrix = new Matrix(new List<double[]> { new double[] { 11, 12 }, new double[] { 21, 22 } });
            Assert.Equal(matrix.ToString(), "11 12 \r\n21 22 \r\n");
        }
    }
}
