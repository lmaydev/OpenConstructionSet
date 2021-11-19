namespace OpenConstructionSet.Models;

/// <summary>
/// A collection of references grouped by a category name.
/// </summary>
/// <param name="Name">The name of the category.</param>
/// <param name="References">The references contained within this category.</param>
public sealed record ReferenceCategory(string Name, List<Reference> References)
{
    /// <summary>
    /// Copy constructor.
    /// Creates a new instance from the original.
    /// </summary>
    /// <param name="category">Item to copy values from.</param>
    public ReferenceCategory(ReferenceCategory category)
    {
        Name = category.Name;

        References = category.References.ToList();
    }

    /// <summary>
    /// Creates a new <c>ReferenceCategory</c> from the provided item's values.
    /// </summary>
    /// <param name="category">Item to get values from.</param>
    /// 
    public ReferenceCategory(DataReferenceCategory category) : this(category.Name, category.Select(r => new Reference(r.Value)).ToList())
    {
    }
}
