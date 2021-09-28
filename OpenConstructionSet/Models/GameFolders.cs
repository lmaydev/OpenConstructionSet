namespace OpenConstructionSet.Models;

/// <summary>
/// POCO for the game's folders.
/// </summary>
public sealed record GameFolders(string Game, ModFolder Data, ModFolder Mod, ModFolder? Content)
{
    private ModFolder[]? array;

    private ModFolder[] CreateArray()
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

    /// <summary>
    /// Helper function to get the folders as an array.
    /// </summary>
    /// <returns>The folders in an arrray.</returns>
    public ModFolder[] ToArray() => array ??= CreateArray();
}