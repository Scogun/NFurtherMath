#if !NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Text;

namespace FurtherMath
{
    /// <summary>
    /// The quaternion.
    /// </summary>
    public class Quaternion
    {
        /// <summary>
        /// The real.
        /// </summary>
        private readonly float real;

        /// <summary>
        /// The i imaginary.
        /// </summary>
        private readonly float iImaginary;

        /// <summary>
        /// The j imaginary.
        /// </summary>
        private readonly float jImaginary;

        /// <summary>
        /// The k imaginary.
        /// </summary>
        private readonly float kImaginary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quaternion"/> class.
        /// </summary>
        /// <param name="iImaginary">
        ///     The i imaginary.
        /// </param>
        /// <param name="jImaginary">
        ///     The j imaginary.
        /// </param>
        /// <param name="kImaginary">
        ///     The k imaginary.
        /// </param>
        /// <param name="real">
        ///     The real.
        /// </param>
        public Quaternion(float iImaginary, float jImaginary, float kImaginary, float real)
        {
            this.real = real;
            this.iImaginary = iImaginary;
            this.jImaginary = jImaginary;
            this.kImaginary = kImaginary;
        }

        /// <summary>
        /// The precision.
        /// </summary>
        internal static double Precision => 1 * Math.Pow(10, -15);

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="firstQuaternion">
        /// The first quaternion.
        /// </param>
        /// <param name="secondQuaternion">
        /// The second quaternion.
        /// </param>
        /// <returns>
        /// The new quaternion.
        /// </returns>
        public static Quaternion operator +(Quaternion firstQuaternion, Quaternion secondQuaternion)
        {
            var newReal = firstQuaternion.real + secondQuaternion.real;
            var newIImaginary = firstQuaternion.iImaginary + secondQuaternion.iImaginary;
            var newJImaginary = firstQuaternion.jImaginary + secondQuaternion.jImaginary;
            var newKImaginary = firstQuaternion.kImaginary + secondQuaternion.kImaginary;
            return new Quaternion(newIImaginary, newJImaginary, newKImaginary, newReal);
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="firstQuaternion">
        /// The first quaternion.
        /// </param>
        /// <param name="secondQuaternion">
        /// The second quaternion.
        /// </param>
        /// <returns>
        /// The new quaternion.
        /// </returns>
        public static Quaternion operator -(Quaternion firstQuaternion, Quaternion secondQuaternion)
        {
            var newReal = firstQuaternion.real - secondQuaternion.real;
            var newIImaginary = firstQuaternion.iImaginary - secondQuaternion.iImaginary;
            var newJImaginary = firstQuaternion.jImaginary - secondQuaternion.jImaginary;
            var newKImaginary = firstQuaternion.kImaginary - secondQuaternion.kImaginary;
            return new Quaternion(newIImaginary, newJImaginary, newKImaginary, newReal);
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="firstQuaternion">
        /// The first quaternion.
        /// </param>
        /// <param name="secondQuaternion">
        /// The second quaternion.
        /// </param>
        /// <returns>
        /// The new quaternion.
        /// </returns>
        public static Quaternion operator *(Quaternion firstQuaternion, Quaternion secondQuaternion)
        {
            var newReal = firstQuaternion.real * secondQuaternion.real
                          - firstQuaternion.iImaginary * secondQuaternion.iImaginary
                          - firstQuaternion.jImaginary * secondQuaternion.jImaginary
                          - firstQuaternion.kImaginary * secondQuaternion.kImaginary;
            var newIImaginary = firstQuaternion.real * secondQuaternion.iImaginary
                                + firstQuaternion.iImaginary * secondQuaternion.real
                                + firstQuaternion.jImaginary * secondQuaternion.kImaginary
                                - firstQuaternion.kImaginary * secondQuaternion.jImaginary;
            var newJImaginary = firstQuaternion.real * secondQuaternion.jImaginary
                                - firstQuaternion.iImaginary * secondQuaternion.kImaginary
                                + firstQuaternion.jImaginary * secondQuaternion.real
                                + firstQuaternion.kImaginary * secondQuaternion.iImaginary;
            var newKImaginary = firstQuaternion.real * secondQuaternion.kImaginary
                                + firstQuaternion.iImaginary * secondQuaternion.jImaginary
                                - firstQuaternion.jImaginary * secondQuaternion.iImaginary
                                + firstQuaternion.kImaginary * secondQuaternion.real;
            return new Quaternion(newIImaginary, newJImaginary, newKImaginary, newReal);
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
        public static Matrix ToMatrix(Quaternion quaternion)
        {
            return new Matrix(new List<double[]>
                                  {
                                      new double[]
                                          {
                                              quaternion.real, -quaternion.iImaginary, -quaternion.jImaginary, -quaternion.kImaginary
                                          },
                                      new double[]
                                          {
                                              quaternion.iImaginary, quaternion.real, -quaternion.kImaginary, quaternion.jImaginary
                                          },
                                      new double[]
                                          {
                                              quaternion.jImaginary, quaternion.kImaginary, quaternion.real, -quaternion.iImaginary
                                          },
                                      new double[]
                                          {
                                              quaternion.kImaginary, -quaternion.jImaginary, quaternion.iImaginary, quaternion.real
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
        public static double Norm(Quaternion quaternion)
        {
            return Math.Pow(quaternion.real, 2) + Math.Pow(quaternion.iImaginary, 2) + Math.Pow(quaternion.jImaginary, 2)
                   + Math.Pow(quaternion.kImaginary, 2);
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
        public static double Abs(Quaternion quaternion)
        {
            return Math.Sqrt(Norm(quaternion));
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
        public static Quaternion Conjugate(Quaternion quaternion)
        {
            return new Quaternion(-quaternion.iImaginary,
                -quaternion.jImaginary,
                -quaternion.kImaginary, quaternion.real);
        }

        /// <summary>
        /// The to matrix.
        /// </summary>
        /// <returns>
        /// The <see cref="Matrix"/>.
        /// </returns>
        public Matrix ToMatrix()
        {
            return ToMatrix(this);
        }

        /// <summary>
        /// The norm.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Norm()
        {
            return Norm(this);
        }

        /// <summary>
        /// The norm.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Abs()
        {
            return Abs(this);
        }

        /// <summary>
        /// The conjugate.
        /// </summary>
        /// <returns>
        /// The <see cref="Quaternion"/>.
        /// </returns>
        public Quaternion Conjugate()
        {
            return Conjugate(this);
        }

        public string ToString(QuaternionDisplay format)
        {
            return ToString();
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            Quaternion quaternion = obj as Quaternion;
            if (quaternion == null)
            {
                return false;
            }

            return Math.Abs(real - quaternion.real) < Precision
                   && Math.Abs(iImaginary - quaternion.iImaginary) < Precision
                   && Math.Abs(jImaginary - quaternion.jImaginary) < Precision
                   && Math.Abs(kImaginary - quaternion.kImaginary) < Precision;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = real.GetHashCode();
                hashCode = (hashCode * 397) ^ iImaginary.GetHashCode();
                hashCode = (hashCode * 397) ^ jImaginary.GetHashCode();
                hashCode = (hashCode * 397) ^ kImaginary.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (Math.Abs(real) > Precision)
            {
                builder.Append(real);
            }

            AddImaginary(builder, iImaginary, 'i');
            AddImaginary(builder, jImaginary, 'j');
            AddImaginary(builder, kImaginary, 'k');

            return builder.ToString();
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
        private void AddImaginary(StringBuilder builder, double imaginary, char imaginaryName)
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