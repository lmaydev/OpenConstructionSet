namespace OpenConstructionSet.IO;

/// <summary>
/// POCO for the game's folders.
/// </summary>
public class ModFolders
{
    public DirectoryInfo Game {  get; set; }
    /// <summary>
    /// The game's data folder.
    /// </summary>
    public ModFolder? Data { get; set; }

    /// <summary>
    /// The game's mod folder.
    /// </summary>
    public ModFolder? Mod { get; set; }

    /// <summary>
    /// The game's content folder.
    /// </summary>
    public ModFolder? Content { get; set; }

    public ModFolders(DirectoryInfo game, ModFolder? data, ModFolder? mod, ModFolder? content)
    {
        Game = game;
        Data = data;
        Mod = mod;
        Content = content;
    }

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