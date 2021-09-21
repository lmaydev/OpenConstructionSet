namespace OpenConstructionSet.Data;

public interface IOcsDataContextBuilder
{
    OcsDataContext Build(string name, bool throwIfMissing = true, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null, IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, ModLoadType loadGameFiles = ModLoadType.None);
}