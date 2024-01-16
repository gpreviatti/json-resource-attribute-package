# Json Resource Attribute Package

This simple package that exposes an attribute to helps testing with json files.

## Configuration

Install package in the project and add this block in your test csproj file in order to copy your json files into the debug folder

```xml
<ItemGroup>
	<None Remove="**\*.json" />
	<EmbeddedResource Include="**\*.json" Exclude="bin\**;obj\**" />
</ItemGroup>
```

## How to use

After install the package you have to decorate your test method with attribute and add the json file reference

```csharp
[Theory(DisplayName = nameof(People_Should_Have_Major_Age))]
[JsonResourceData("json-resource-data-attribute.json", "majorAge")]
public void People_Should_Have_Major_Age(Person[] people, bool expected)
{
    // Arrange, Act
    var result = people.Any(p => p.IsMajorAge().Equals(expected));

    // Assert
    Assert.True(result);
}
```

You should create a json file and add the node with a name that will be identified by the test in the example the name is `majorAge`


## Samples

The samples of how to use the json resource attribute are available in test project of package