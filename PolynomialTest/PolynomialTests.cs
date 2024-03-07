using PolynomialConsole;

namespace PolynomialTest;

[TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, ExpectedResult = new double[] { 5, 7, 9 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, ExpectedResult = new double[] { 0, 0, 0 })]
        [TestCase(new double[] { -1, -2, -3 }, new double[] { -4, -5, -6 }, ExpectedResult = new double[] { -5, -7, -9 })]
        public double[] Polynomial_Addition_ReturnsCorrectResult(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = new Polynomial(coefficients1);
            Polynomial polynomial2 = new Polynomial(coefficients2);
            
            Polynomial result = polynomial1 + polynomial2;
            
            return result.Coefficients;
        }

        [TestCase(new double[] { 4, 5, 6 }, new double[] { 1, 2, 3 }, ExpectedResult = new double[] { 3, 3, 3 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, ExpectedResult = new double[] { 0, 0, 0 })]
        [TestCase(new double[] { -4, -5, -6 }, new double[] { -1, -2, -3 }, ExpectedResult = new double[] { -3, -3, -3 })]
        public double[] Polynomial_Subtraction_ReturnsCorrectResult(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = new Polynomial(coefficients1);
            Polynomial polynomial2 = new Polynomial(coefficients2);
            
            Polynomial result = polynomial1 - polynomial2;
            
            return result.Coefficients;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5 }, ExpectedResult = new double[] { 4, 13, 22, 15 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0 }, ExpectedResult = new double[] { 0, 0, 0, 0 })]
        [TestCase(new double[] { -1, -2, -3 }, new double[] { -4, -5 }, ExpectedResult = new double[] { 4, 13, 22, 15 })]
        public double[] Polynomial_Multiplication_ReturnsCorrectResult(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = new Polynomial(coefficients1);
            Polynomial polynomial2 = new Polynomial(coefficients2);
            
            Polynomial result = polynomial1 * polynomial2;
            
            return result.Coefficients;
        }

        [TestCase(new double[] { 4, 13, 22, 15 }, new double[] { 1, 2 }, ExpectedResult = new double[] { 2.875, 7.25, 7.5 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 1 }, ExpectedResult = new double[] { 0, 0, 0 })]
        [TestCase(new double[] { -4, -13, -22, -15 }, new double[] { -1, -2 }, ExpectedResult = new double[] { 2.875, 7.25, 7.5 })]
        [TestCase(new double[] { -4, -13, -22, -15 }, new double[] { 1, 2 }, ExpectedResult = new double[] { -2.875, -7.25, -7.5 })]
        public double[] Polynomial_Division_ReturnsCorrectResult(double[] coefficients1, double[] coefficients2)
        {
            Polynomial dividend = new Polynomial(coefficients1);
            Polynomial divisor = new Polynomial(coefficients2);
            
            (Polynomial quotient, Polynomial remainder) = dividend / divisor;
            
            return quotient.Coefficients;
        }

        [TestCase(new double[] { 1, 2, 3 }, 2, ExpectedResult = new double[] { 2, 4, 6 })]
        [TestCase(new double[] { 0, 0, 0 }, 5, ExpectedResult = new double[] { 0, 0, 0 })]
        [TestCase(new double[] { -1, -2, -3 }, -2, ExpectedResult = new double[] { 2, 4, 6 })]
        public double[] Polynomial_MultiplicationByScalar_ReturnsCorrectResult(double[] coefficients, double scalar)
        {
            Polynomial polynomial = new Polynomial(coefficients);
            
            Polynomial result = polynomial * scalar;
            
            return result.Coefficients;
        }

        [TestCase(new double[] { 2, 4, 6 }, 2, ExpectedResult = new double[] { 1, 2, 3 })]
        [TestCase(new double[] { 0, 0, 0 }, 5, ExpectedResult = new double[] { 0, 0, 0 })]
        [TestCase(new double[] { -2, -4, -6 }, -2, ExpectedResult = new double[] { 1, 2, 3 })]
        public double[] Polynomial_DivisionByScalar_ReturnsCorrectResult(double[] coefficients, double scalar)
        {
            Polynomial polynomial = new Polynomial(coefficients);
            
            Polynomial result = polynomial / scalar;
            
            return result.Coefficients;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { -1, -2, -3 }, new double[] { -1, -2, -3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 0 }, ExpectedResult = false)]
        public bool Polynomial_EqualityCheck_ReturnsCorrectResult(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = new Polynomial(coefficients1);
            Polynomial polynomial2 = new Polynomial(coefficients2);
            
            bool result = polynomial1 == polynomial2;
            
            return result;
        }
    }