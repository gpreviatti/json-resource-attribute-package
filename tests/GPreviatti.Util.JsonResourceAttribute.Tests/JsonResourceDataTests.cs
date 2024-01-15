namespace GPreviatti.Util.JsonResourceAttribute.Tests;

public sealed class JsonResourceDataTests
{
    private readonly MathSample _mathSample = new();

    [Theory(DisplayName = nameof(Should_Sum_With_Success))]
    [JsonResourceData("json-resource-data-attribute.json", "sum")]
    public void Should_Sum_With_Success(int number1, int number2, int result)
    {
        // Arrange, Act
        var sumResult = _mathSample.Sum(number1, number2);

        // Assert
        Assert.Equal(result, sumResult);
    }
}