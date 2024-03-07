namespace PolynomialConsole;

using System;
/// <summary>
/// Represents a polynomial with double coefficients.
/// </summary>
public class Polynomial : IEquatable<Polynomial>
{
    private readonly double[] coefficients;
    /// <summary>
    /// Gets the coefficients of the polynomial.
    /// </summary>
    public double[] Coefficients => (double[])coefficients.Clone();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Polynomial"/> class with the specified coefficients.
    /// </summary>
    /// <param name="coeffs">The coefficients of the polynomial.</param>
    public Polynomial(params double[] coeffs)
    {
        coefficients = new double[coeffs.Length];
        coeffs.CopyTo(coefficients, 0);
    }
    /// <summary>
    /// Gets the degree of the polynomial.
    /// </summary>
    public int Degree => coefficients.Length - 1;

    /// <summary>
    /// Gets the coefficient of the term with the specified degree.
    /// </summary>
    /// <param name="index">The degree of the term.</param>
    /// <returns>The coefficient of the term.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified index is out of range.</exception>
    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= coefficients.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            return coefficients[index];
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current polynomial.
    /// </summary>
    /// <param name="other">The polynomial to compare with the current polynomial.</param>
    /// <returns>true if the specified object is equal to the current polynomial; otherwise, false.</returns>
    public bool Equals(Polynomial other)
    {
        if (other == null)
            return false;

        if (coefficients.Length != other.coefficients.Length)
            return false;

        for (int i = 0; i < coefficients.Length; i++)
        {
            if (coefficients[i] != other.coefficients[i])
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current polynomial.
    /// </summary>
    /// <param name="obj">The object to compare with the current polynomial.</param>
    /// <returns>true if the specified object is equal to the current polynomial; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Polynomial))
            return false;

        return Equals((Polynomial)obj);
    }

    /// <summary>
    /// Returns the hash code for the current polynomial.
    /// </summary>
    /// <returns>A hash code for the current polynomial.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var coef in coefficients)
            {
                hash = hash * 23 + coef.GetHashCode();
            }
            return hash;
        }
    }

    /// <summary>
    /// Determines whether two polynomials are equal.
    /// </summary>
    public static bool operator ==(Polynomial left, Polynomial right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two polynomials are not equal.
    /// </summary>
    public static bool operator !=(Polynomial left, Polynomial right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Adds two polynomials.
    /// </summary>
    public static Polynomial operator +(Polynomial left, Polynomial right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        int maxLength = Math.Max(left.coefficients.Length, right.coefficients.Length);
        double[] resultCoeffs = new double[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            double leftCoef = (i < left.coefficients.Length) ? left.coefficients[i] : 0;
            double rightCoef = (i < right.coefficients.Length) ? right.coefficients[i] : 0;
            resultCoeffs[i] = leftCoef + rightCoef;
        }

        return new Polynomial(resultCoeffs);
    }

    /// <summary>
    /// Subtracts one polynomial from another.
    /// </summary>
    public static Polynomial operator -(Polynomial left, Polynomial right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        int maxLength = Math.Max(left.coefficients.Length, right.coefficients.Length);
        double[] resultCoeffs = new double[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            double leftCoef = (i < left.coefficients.Length) ? left.coefficients[i] : 0;
            double rightCoef = (i < right.coefficients.Length) ? right.coefficients[i] : 0;
            resultCoeffs[i] = leftCoef - rightCoef;
        }

        return new Polynomial(resultCoeffs);
    }

    /// <summary>
    /// Multiplies two polynomials.
    /// </summary>
    public static Polynomial operator *(Polynomial left, Polynomial right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        int resultDegree = left.Degree + right.Degree;
        double[] resultCoeffs = new double[resultDegree + 1];

        for (int i = 0; i <= left.Degree; i++)
        {
            for (int j = 0; j <= right.Degree; j++)
            {
                resultCoeffs[i + j] += left.coefficients[i] * right.coefficients[j];
            }
        }

        return new Polynomial(resultCoeffs);
    }

    /// <summary>
    /// Divides one polynomial by another and returns the quotient and remainder.
    /// </summary>
    public static (Polynomial quotient, Polynomial remainder) operator /(Polynomial dividend, Polynomial divisor)
    {
        if (divisor == null || dividend == null)
            throw new ArgumentNullException();

        if (divisor.Degree > dividend.Degree)
            return (new Polynomial(0), new Polynomial(dividend.coefficients));

        double[] resultCoeffs = new double[dividend.Degree - divisor.Degree + 1];
        double[] dividendCoeffs = new double[dividend.coefficients.Length];
        dividend.coefficients.CopyTo(dividendCoeffs, 0);

        for (int i = dividend.Degree - divisor.Degree; i >= 0; i--)
        {
            double coef = dividendCoeffs[i + divisor.Degree] / divisor[divisor.Degree];
            resultCoeffs[i] = coef;

            for (int j = 0; j <= divisor.Degree; j++)
            {
                dividendCoeffs[i + j] -= coef * divisor[j];
            }
        }

        return (new Polynomial(resultCoeffs), new Polynomial(dividendCoeffs));
    }

    /// <summary>
    /// Multiplies a polynomial by a scalar value.
    /// </summary>
    public static Polynomial operator *(Polynomial polynomial, double scalar)
    {
        if (polynomial == null)
            throw new ArgumentNullException();

        double[] resultCoeffs = new double[polynomial.coefficients.Length];
        for (int i = 0; i < polynomial.coefficients.Length; i++)
        {
            resultCoeffs[i] = polynomial.coefficients[i] * scalar;
        }

        return new Polynomial(resultCoeffs);
    }

    /// <summary>
    /// Multiplies a polynomial by a scalar value.
    /// </summary>
    public static Polynomial operator *(double scalar, Polynomial polynomial)
    {
        return polynomial * scalar;
    }

    /// <summary>
    /// Divides a polynomial by a scalar value.
    /// </summary>
    public static Polynomial operator /(Polynomial polynomial, double scalar)
    {
        if (polynomial == null)
            throw new ArgumentNullException();

        if (scalar == 0)
            throw new DivideByZeroException("Division by zero.");

        double[] resultCoeffs = new double[polynomial.coefficients.Length];
        for (int i = 0; i < polynomial.coefficients.Length; i++)
        {
            resultCoeffs[i] = polynomial.coefficients[i] / scalar;
        }

        return new Polynomial(resultCoeffs);
    }
    
    /// <summary>
    /// Returns a string representation of the current polynomial.
    /// </summary>
    public override string ToString()
    {
        string polynomialString = "";
        for (int i = coefficients.Length - 1; i >= 0; i--)
        {
            if (coefficients[i] != 0)
            {
                if (polynomialString != "")
                    polynomialString += " + ";
                if (i == 0)
                    polynomialString += coefficients[i];
                else if (i == 1)
                    polynomialString += coefficients[i] + "x";
                else
                    polynomialString += coefficients[i] + "x^" + i;
            }
        }
        return polynomialString == "" ? "0" : polynomialString;
    }
}