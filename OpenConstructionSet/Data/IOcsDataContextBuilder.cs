using OpenConstructionSet.IO;

namespace OpenConstructionSet.Data;

public interface IOcsDataContextBuilder
{
    OcsDataContext Build(string name, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null, IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, bool loadGameFiles = false);
}
