namespace OpenConstructionSet.Models;

public sealed record ReferenceCategory(string Name, ReferenceCollection References)
{
    public ReferenceCategory(ReferenceCategory original)
    {
        Name = original.Name;

        References = new(original.References.Select(r => r with { }));
    }
}
