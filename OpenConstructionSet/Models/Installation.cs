namespace OpenConstructionSet.Models;

/// <summary>
/// POCO representing an installation of the game.
/// </summary>
public sealed record Installation(string Game, string[] EnabledMods, ModFolder Data, ModFolder Mod, ModFolder? Content, SaveFolder? Save)
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
    /// <returns>The folders in an array.</returns>
    public ModFolder[] ToModFolderArray() => array ??= CreateArray();
}