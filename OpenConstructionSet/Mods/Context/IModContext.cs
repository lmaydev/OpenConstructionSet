using OpenConstructionSet.Installations;

namespace OpenConstructionSet.Mods.Context;

/// <summary>
/// An FCS like context that allows the loading of multiple mod's for editing.
/// </summary>
public interface IModContext
{
    /// <summary>
    /// The header to use for this mod.
    /// </summary>
    Header Header { get; set; }

    /// <summary>
    /// The optional data for the mod's .info file.
    /// </summary>
    ModInfoData? Info { get; set; }

    /// <summary>
    /// Editable collection of items.
    /// </summary>
    ModItemCollection Items { get; }

    /// <summary>
    /// The last ID used to generate a new <see cref="IItem.StringId"/>
    /// </summary>
    int LastId { get; set; }

    /// <summary>
    /// The name of the mod to be saved to.
    /// </summary>
    string ModName { get; }

    /// <summary>
    /// Creates a new <see cref="ModItem"/>.
    /// Generates the <see cref="IItem.StringId"/> and increases <see cref="LastId"/> value.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    ModItem NewItem(ItemType type, string name);

    /// <summary>
    /// Saves to the Mods folder with using <see cref="ModName"/> as the name.
    /// </summary>
    /// <returns>An awaitable task.</returns>
    Task SaveAsync();

    /// <summary>
    /// Saves to the given <see cref="IModFolder"/> with the given name.
    /// </summary>
    /// <param name="folder">The folder to save to.</param>
    /// <param name="modName">The mod name to use e.g. example or example.mod</param>
    /// <returns>An awaitable taks.</returns>
    Task SaveAsync(IModFolder folder, string modName);

    /// <summary>
    /// Saves to the given full path.
    /// e.g. \path\to\mod\example.mod
    /// </summary>
    /// <param name="path">The full path to save the mod to.</param>
    /// <returns>An awaitable task.</returns>
    Task SaveAsync(string path);
}
