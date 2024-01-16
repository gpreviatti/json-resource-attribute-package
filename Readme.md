# Json Resource Attribute Package

[![Publish in Nuget.org](https://github.com/gpreviatti/json-resource-attribute-package/actions/workflows/publish.yml/badge.svg)](https://github.com/gpreviatti/json-resource-attribute-package/actions/workflows/publish.yml)

[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=bugs)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=coverage)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=gpreviatti_json-resource-attribute-package&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=gpreviatti_json-resource-attribute-package)

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

[The samples of how to use the json resource attribute are available in test project of package](https://github.com/gpreviatti/json-resource-attribute-package/blob/main/tests/GPreviatti.Util.JsonResourceAttribute.Tests/JsonResourceDataTests.cs)
