using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace GPreviatti.Util.JsonResourceAttribute;
public sealed class ResourceReader(Assembly assembly)
{
    private readonly Assembly _thisAssembly = assembly;
    private string[] _resourceNames;

    private string[] ResourceNames => _resourceNames ??= _thisAssembly.GetManifestResourceNames();

    public string GetString(string resourceName, params object[] args)
    {
        return args is null || args.Length == 0
            ? LoadEmbeddedResource(FindResourceName(resourceName) ?? resourceName)
            : string.Format(
                CultureInfo.InvariantCulture,
                LoadEmbeddedResource(FindResourceName(resourceName) ?? resourceName),
                args);
    }

    private string FindResourceName(string partialName) =>
        Array.Find(ResourceNames, n => n.EndsWith(partialName, StringComparison.Ordinal));

    private string LoadEmbeddedResource(string resourceName)
    {
        using var stream = _thisAssembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new ArgumentException(
                $"Could not find embedded resource {resourceName}. " +
                $"Available names: {string.Join(", ", ResourceNames)}.");
        }

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
