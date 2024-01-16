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

    [Theory(DisplayName = nameof(Should_Validate_Email))]
    [JsonResourceData("json-resource-data-attribute.json", "email")]
    public void Should_Validate_Email(Person person, bool expected)
    {
        // Arrange, Act
        var result = person.IsValidEmail();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = nameof(People_Should_Have_Major_Age))]
    [JsonResourceData("json-resource-data-attribute.json", "majorAge")]
    public void People_Should_Have_Major_Age(Person[] people, bool expected)
    {
        // Arrange, Act
        var result = people.Any(p => p.IsMajorAge().Equals(expected));

        // Assert
        Assert.True(result);
    }
}