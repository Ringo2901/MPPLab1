namespace FloatConverter;

public class TestClass
{
    public static void Main(string[] args)
    {
        float number = float.Parse(Console.ReadLine());

        string binaryString = FloatToBinaryConverter.Convert(number);
        Console.WriteLine(binaryString);
    }
}