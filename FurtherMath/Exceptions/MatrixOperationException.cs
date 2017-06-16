using System;

namespace FurtherMath.Exceptions
{
    /// <summary>
    /// The matrix operation exception.
    /// </summary>
    public class MatrixOperationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixOperationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public MatrixOperationException(string message) : base(message)
        {
        }
    }
}