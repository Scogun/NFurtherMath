using System;

namespace FurtherMath.Exceptions
{
    /// <summary>
    /// The matrix size exception.
    /// </summary>
    public class MatrixSizeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSizeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public MatrixSizeException(string message) : base(message)
        {
        }
    }
}