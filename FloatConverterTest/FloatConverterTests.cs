using FloatConverter;

namespace FloatConverterTest;

[TestFixture]
public class FloatConverterTests
{
    [TestCase(10.75f, "01000001001011000000000000000000")]
    [TestCase(-3.5f, "11000000011000000000000000000000")]
    [TestCase(0.0f, "00000000000000000000000000000000")]
    [TestCase(1.0f, "00111111100000000000000000000000")]
    [TestCase(float.MinValue, "11111111011111111111111111111111")]
    [TestCase(float.MaxValue, "01111111011111111111111111111111")]
    [TestCase(float.Epsilon, "00000000000000000000000000000001")]
    public void FloatToBinary_ValidInput_ReturnsExpectedResult(float number, string expectedBinary)
    {
        string actualBinary = FloatToBinaryConverter.Convert(number);
        Assert.That(expectedBinary, Is.EqualTo(actualBinary));
    }
}