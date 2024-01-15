# Json Resource Attribute Package

This simple package that exposes an attribute to helps testing with json files.

## How to use



## Configuration

Add this block in your test csproj file in order to copy your json files into the debug folder

```xml
<ItemGroup>
	<None Remove="**\*.json" />
	<EmbeddedResource Include="**\*.json" Exclude="bin\**;obj\**" />
</ItemGroup>
```