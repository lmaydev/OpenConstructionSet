﻿namespace OpenConstructionSet.Models;

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
    /// <param name="original"></param>
    public ReferenceCategory(ReferenceCategory original)
    {
        Name = original.Name;

        References = original.References.ToList();
    }
}
