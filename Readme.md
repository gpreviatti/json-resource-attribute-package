# Json Resource Attribute Package

This simple package that exposes an attribute to helps testing with json files.

## How to use

Install package in test project and add this block in your csproj file in order to copy your json files into the debug folder

```xml
<ItemGroup>
	<None Remove="**\*.json" />
	<EmbeddedResource Include="**\*.json" Exclude="bin\**;obj\**" />
</ItemGroup>
```

You should create a json file and add the node with a name that will be identified by the test in the example the name is `majorAge`

Decorate your test method with `JsonResourceData` attribute, add the json file reference and test node name

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

## Samples

The samples of how to use the json resource attribute are available in test project of package
