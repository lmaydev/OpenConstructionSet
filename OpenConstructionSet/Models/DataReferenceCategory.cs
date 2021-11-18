using OpenConstructionSet.Collections;
using System.ComponentModel.DataAnnotations;

namespace OpenConstructionSet.Models;

public class DataReferenceCategory : OcsList<DataReference>, IDataModel
{
    public string Key => Name;

    public string Name { get; }

    public DataReferenceCategory(string name)
    {
        Name = name;
    }

    public DataReferenceCategory(string name, IEnumerable<DataReference> collection) : base(collection)
    {
        Name = name;
    }

    public DataReferenceCategory(ReferenceCategory category) : this(category.Name, category.References.Select(r => new DataReference(r)))
    {
    }
}