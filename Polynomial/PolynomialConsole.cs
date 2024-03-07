namespace PolynomialConsole;

public class PolynomialConsole
{
    public static void Main(string[] args)
    {
        try
        {
            double scalar = 2;
            
            Console.WriteLine("Enter coefficients for the first polynomial:");
            double[] coeffs1 = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            Polynomial polynomial1 = new Polynomial(coeffs1);

            Console.WriteLine("Enter coefficients for the second polynomial:");
            double[] coeffs2 = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            Polynomial polynomial2 = new Polynomial(coeffs2);

            Console.WriteLine("Polynomial 1: " + polynomial1);
            Console.WriteLine("Polynomial 2: " + polynomial2);

            Polynomial sum = polynomial1 + polynomial2;
            Console.WriteLine("Sum: " + sum);

            Polynomial difference = polynomial1 - polynomial2;
            Console.WriteLine("Difference: " + difference);

            Polynomial product = polynomial1 * polynomial2;
            Console.WriteLine("Product: " + product);

            (Polynomial quotient, Polynomial remainder) = polynomial1 / polynomial2;
            Console.WriteLine("Quotient: " + quotient + "   Remainder: "+ remainder);

            bool equal = polynomial1 == polynomial2;
            Console.WriteLine("Polynomial 1 equals Polynomial 2: " + equal);

            bool notEqual = polynomial1 != polynomial2;
            Console.WriteLine("Polynomial 1 does not equal Polynomial 2: " + notEqual);
            
            Polynomial multiplied = polynomial1 * scalar;
            Console.WriteLine("Product with scalar: " + multiplied);
                        
            Polynomial divided = polynomial1 / scalar;
            Console.WriteLine("Quotient with scalar: " + divided);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
