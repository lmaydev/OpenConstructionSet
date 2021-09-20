using OpenConstructionSet.IO;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

public interface IOcsFileService
{
    bool Delete(ModFile file);
    bool Delete(ModFolder folder, string mod);
    string GetPath(ModFolder folder, string modName);
    Header ReadHeader(OcsReader reader);
    bool TryReadHeader(OcsReader reader, [MaybeNullWhen(false)] out Header header);
    void Write(OcsWriter writer, Header? header, int lastId, IEnumerable<Item> items);
}