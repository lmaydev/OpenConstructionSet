namespace OpenConstructionSet.IO;

/// <summary>
/// POCO for the game's folders.
/// </summary>
public record GameFolders(DirectoryInfo Game, ModFolder Data, ModFolder Mod, ModFolder? Content)
{
    /// <summary>
    /// Helper function to get the folders as an array.
    /// </summary>
    /// <returns>The folders in an arrray.</returns>
    public ModFolder[] ToArray()
    {
        var list = new List<ModFolder>();

        if (Data is not null)
        {
            list.Add(Data);
        }

        if (Mod is not null)
        {
            list.Add(Mod);
        }

        if (Content is not null)
        {
            list.Add(Content);
        }

        return list.ToArray();
    }
}