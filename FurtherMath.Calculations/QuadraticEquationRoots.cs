using System;
using System.Numerics;

namespace FurtherMath.Calculations
{
    public class QuadraticEquationRoots
    {
        private readonly double? firstDoubleRoot;

        private readonly double? secondDoubleRoot;

        private readonly Complex firstComplexRoot;

        private readonly Complex secondComplexRoot;

        public QuadraticEquationRoots(double firstRoot, double secondRoot)
        {
            firstDoubleRoot = firstRoot;
            secondDoubleRoot = secondRoot;
        }

        public QuadraticEquationRoots(Complex firstRoot, Complex secondRoot)
        {
            firstComplexRoot = firstRoot;
            secondComplexRoot = secondRoot;
        }

        public bool IsRealRoots => firstDoubleRoot.HasValue;

        public (double FirstRoot, double SecondRoot) RealRoots
        {
            get
            {
                if (IsRealRoots)
                {
                    return (firstDoubleRoot.Value, secondDoubleRoot.Value);
                }

                throw new ArgumentException("Solution is a complex one.");
            }
        }

        public (Complex FirstRoot, Complex SecondRoot) ComplexRoots
        {
            get
            {
                if (!IsRealRoots)
                {
                    return (firstComplexRoot, secondComplexRoot);
                }

                throw new ArgumentException("Solution is not a complex one.");
            }
        }
    }
}