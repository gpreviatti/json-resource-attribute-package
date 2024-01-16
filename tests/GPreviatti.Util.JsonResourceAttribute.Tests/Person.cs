using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace GPreviatti.Util.JsonResourceAttribute.Tests;

[ExcludeFromCodeCoverage]
public sealed class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }

    public bool IsValidEmail()
    {
        string regex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        var emailMatch = Regex.Match(Email, regex);

        if (emailMatch.Success)
            return true;

        return false;
    }

    public bool IsMajorAge()
    {
        var now = DateTime.Now;

        if (now.Year - BirthDate.Year >= 18)
            return true;

        return false;
    }
}
