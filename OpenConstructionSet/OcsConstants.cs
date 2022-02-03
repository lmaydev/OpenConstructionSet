using static System.Environment;

namespace OpenConstructionSet;

/// <summary>
/// Useful constants for working with the OCS.
/// </summary>
public static class OcsConstants
{
    /// <summary>
    /// The names of the game's data and mod files.
    /// </summary>
    public static readonly string[] BaseMods = new string[] { "gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod" };

    /// <summary>
    /// The default location of the save folder.
    /// </summary>
    public static readonly string DefaultSaveFolder = Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "kenshi", "save");

    /// <summary>
    /// The name of the file that stores the enabled mods and load order.
    /// </summary>
    public static readonly string EnabledModFile = "mods.cfg";

    /// <summary>
    /// The valid tags for a mod's info file.
    /// </summary>
    public static readonly string[] InfoTags = new string[]
    {
            "Buildings",
            "Characters",
            "Cheats",
            "Clothing/Armour",
            "Environment/Map",
            "Factions",
            "Gameplay",
            "Graphical",
            "GUI",
            "Items/Weapons",
            "Races",
            "Research",
            "Total Overhaul",
            "Translation"
    };
}
