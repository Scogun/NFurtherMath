#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Text;
using NQuaternion = System.Numerics.Quaternion;

namespace FurtherMath
{
    public static class QuaternionExtension
    {
        /// <summary>
        /// The precision.
        /// </summary>
        internal static double Precision => 1 * Math.Pow(10, -15);

        public static string ToString(this NQuaternion quaternion, QuaternionDisplay format)
        {
            return format switch
            {
                QuaternionDisplay.Algebraic => ToAlgebraicString(quaternion),
                _ => quaternion.ToString()
            };
        }

        public static string ToAlgebraicString(NQuaternion quaternion)
        {
            StringBuilder builder = new StringBuilder();
            if (Math.Abs(quaternion.W) > Precision)
            {
                builder.Append(quaternion.W);
            }

            AddImaginary(builder, quaternion.X, 'i');
            AddImaginary(builder, quaternion.Y, 'j');
            AddImaginary(builder, quaternion.Z, 'k');

            return builder.ToString();
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        /// <param name="quaternion">
        /// The quaternion.
        /// </param>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public static Matrix ToMatrix(this NQuaternion quaternion)
        {
            return new Matrix(new List<double[]>
                                  {
                                      new double[]
                                          {
                                              quaternion.W, -quaternion.X, -quaternion.Y, -quaternion.Z
                                          },
                                      new double[]
                                          {
                                              quaternion.X, quaternion.W, -quaternion.Z, quaternion.Y
                                          },
                                      new double[]
                                          {
                                              quaternion.Y, quaternion.Z, quaternion.W, -quaternion.X
                                          },
                                      new double[]
                                          {
                                              quaternion.Z, -quaternion.Y, quaternion.X, quaternion.W
                                          }
                                  });
        }

        /// <summary>
        /// The norm.
        /// </summary>
        /// <param name="quaternion">
        /// The quaternion.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double Norm(this NQuaternion quaternion)
        {
            return Math.Pow(quaternion.W, 2) + Math.Pow(quaternion.X, 2) + Math.Pow(quaternion.Y, 2)
                   + Math.Pow(quaternion.Z, 2);
        }

        /// <summary>
        /// The norm.
        /// </summary>
        /// <param name="quaternion">
        /// The quaternion.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double Abs(this NQuaternion quaternion)
        {
            return Math.Sqrt(quaternion.Norm());
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        /// <param name="quaternion">
        /// The quaternion.
        /// </param>
        /// <returns>
        /// The <see cref="Quaternion"/>.
        /// </returns>
        public static NQuaternion Conjugate(this NQuaternion quaternion)
        {
            return new NQuaternion(-quaternion.X,
                -quaternion.Y,
                -quaternion.Z, quaternion.W);
        }

        /// <summary>
        /// The add imaginary.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="imaginary">
        /// The imaginary.
        /// </param>
        /// <param name="imaginaryName">
        /// The imaginary name.
        /// </param>
        private static void AddImaginary(StringBuilder builder, double imaginary, char imaginaryName)
        {
            if (Math.Abs(imaginary) > Precision)
            {
                if (builder.Length > 0 && imaginary > 0)
                {
                    builder.Append("+");
                }

                builder.Append($"{imaginary}{imaginaryName}");
            }
        }

    }
}
#endif