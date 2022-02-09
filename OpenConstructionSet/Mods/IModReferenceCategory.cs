namespace OpenConstructionSet.Mods;

public interface IModReferenceCategory : IReferenceCategory, IKeyedItem<string>
{
    IKeyedCollection<string, ModReference> References { get; }
}
