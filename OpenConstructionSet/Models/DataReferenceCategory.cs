using OpenConstructionSet.Collections;
using System.ComponentModel.DataAnnotations;

namespace OpenConstructionSet.Models;

/// <summary>
/// Editable representation of a reference category from a data file.
/// </summary>
public class DataReferenceCategory : OcsList<DataReference>, IDataModel
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public string Key => Name;

    /// <summary>
    /// Name of the category.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates a new <c>DataReferenceCategory</c>.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    public DataReferenceCategory(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Creates a new <c>DataReferenceCategory</c> from the provided values.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    /// <param name="collection">Collection of references to store in the category.</param>
    public DataReferenceCategory(string name, IEnumerable<DataReference> collection) : base(collection)
    {
        Name = name;
    }

    /// <summary>
    /// Copy constructor.
    /// </summary>
    /// <param name="category"><c>DataReferenceCategory</c> who's values will be copied. </param>
    public DataReferenceCategory(ReferenceCategory category) : this(category.Name, category.References.Select(r => new DataReference(r)))
    {
    }
}