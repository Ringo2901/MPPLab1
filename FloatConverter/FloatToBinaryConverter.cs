namespace FloatConverter;

/// <summary>
/// Provides functionality to convert a floating-point number to its binary representation.
/// </summary>
public class FloatToBinaryConverter
{
    /// <summary>
    /// Converts the specified floating-point number to its binary representation.
    /// </summary>
    /// <param name="number">The floating-point number to convert.</param>
    /// <returns>A string representing the binary representation of the input number.</returns>
    public static string Convert(float number)
    {
        int floatBits = BitConverter.SingleToInt32Bits(number);
        char[] binaryChars = new char[32];
        
        for (int i = 0; i < 32; i++)
        {
            binaryChars[i] = ((floatBits >> (31 - i)) & 1) == 1 ? '1' : '0';
        }
        return new string(binaryChars);
    }
}