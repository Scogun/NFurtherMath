using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurtherMath.Calculations.Tests
{
    [TestClass]
    public class QuadraticEquationTests
    {
        [DataTestMethod]
        [DataRow(1, 0, -49, "x^2-49=0", 7, -7)]
        [DataRow(1, -8, 12, "x^2-8x+12=0", 6, 2)]
        [DataRow(-1, -2, 15, "-x^2-2x+15=0", -5, 3)]
        [DataRow(1, -6, 9, "x^2-6x+9=0", 3, 3)]
        [DataRow(1, -1, 0, "x^2-x=0", 1, 0)]
        public void RealQuadraticEquation(double a, double b, double c, string stringForm, double firstRoot, double secondRoot)
        {
            var equation = new QuadraticEquation(a, b, c);
            equation.ToString().Should().Be(stringForm);
            var solution = equation.Solution();
            solution.IsRealRoots.Should().BeTrue();
            solution.RealRoots.FirstRoot.Should().Be(firstRoot);
            solution.RealRoots.SecondRoot.Should().Be(secondRoot);
            Assert.ThrowsException<ArgumentException>(() => solution.ComplexRoots);
        }

        [DataTestMethod]
        [DataRow(1, -6, 13, "x^2-6x+13=0", 3, 2, 3, -2)]
        public void ComplexQuadraticEquation(double a, double b, double c, string stringForm, double firstReal, double firstImaginary, double secondReal, double secondImaginary)
        {
            var equation = new QuadraticEquation(a, b, c);
            equation.ToString().Should().Be(stringForm);
            var solution = equation.Solution();
            solution.IsRealRoots.Should().BeFalse();
            solution.ComplexRoots.FirstRoot.Should().Be(new Complex(firstReal, firstImaginary));
            solution.ComplexRoots.SecondRoot.Should().Be(new Complex(secondReal, secondImaginary));
            Assert.ThrowsException<ArgumentException>(() => solution.RealRoots);
        }

        [DataTestMethod]
        [DataRow("x^2-49=0")]
        [DataRow("x^2-8x+12=0")]
        [DataRow("-x^2-2x+15=0")]
        [DataRow("x^2-6x+9=0")]
        [DataRow("x^2-6x+13=0")]
        [DataRow("x^2-x+13=0")]
        [DataRow("x^2-x=0")]
        [DataRow("2x^2+x=0")]
        public void ParseQuadraticEquations(string equation)
        {
            QuadraticEquation.Parse(equation).ToString().Should().Be(equation);
        }
    }
}
