namespace OpenConstructionSet.Models;

public sealed record Reference(string TargetId, ReferenceValues Values, string Category)
{
    private string? key = null;

    public string Key => key ??= Category + TargetId;
}