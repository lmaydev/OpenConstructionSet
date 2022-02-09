namespace OpenConstructionSet.Mods;

public interface IModContext
{
    IReadOnlyDictionary<string, ModItem> Items { get; }
}
