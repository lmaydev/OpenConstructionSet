namespace OpenConstructionSet.Models;

public class DataReferenceCategory : SortedDictionary<string, DataReference>
{
    public DataReferenceCategory()
    {
    }

    public DataReferenceCategory(IComparer<string>? comparer) : base(comparer)
    {
    }

    public DataReferenceCategory(IDictionary<string, DataReference> dictionary) : base(dictionary)
    {
    }

    public DataReferenceCategory(IDictionary<string, DataReference> dictionary, IComparer<string>? comparer) : base(dictionary, comparer)
    {
    }

    public DataReferenceCategory(ReferenceCategory category)
    {
        foreach (var reference in category.References)
        {
            this[reference.TargetId] = new DataReference(reference);
        }
    }
}