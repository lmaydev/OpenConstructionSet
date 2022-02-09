using OpenConstructionSet.Installations;

namespace OpenConstructionSet.Mods.Context
{
    /// <summary>
    /// Options used to build a mod context.
    /// </summary>
    public class ModContextOptions
    {
        /// <summary>
        /// Creates a new <see cref="ModContextOptions"/> from the provided values.
        /// </summary>
        /// <param name="name">The name of the active mod.</param>
        /// <param name="installation">The installation to work against.</param>
        /// <param name="activeMods">Optional collection of mod names, filenames or paths to load into the active mod.</param>
        /// <param name="baseMods">Optional collection of mod names, filenames or paths to load as base data.</param>
        /// <param name="header">Optional header to use for the active mod.</param>
        /// <param name="info">Optional .info file data to use for the active mod.</param>
        /// <param name="loadEnabledMods">Determines if/how the enabled mods will be loaded.</param>
        /// <param name="loadGameFiles">Determines if/how the game's base data files will be loaded.</param>
        public ModContextOptions(string name,
                                 IInstallation installation,
                                 IEnumerable<string>? activeMods = null,
                                 IEnumerable<string>? baseMods = null,
                                 Header? header = null,
                                 ModInfoData? info = null,
                                 ModLoadType loadEnabledMods = ModLoadType.None,
                                 ModLoadType loadGameFiles = ModLoadType.None)
        {
            Name = name;
            Installation = installation;
            ActiveMods = activeMods;
            BaseMods = baseMods;
            Header = header;
            Info = info;
            LoadEnabledMods = loadEnabledMods;
            LoadGameFiles = loadGameFiles;
        }

        /// <summary>
        /// A collection of mod names, filenames or paths to load into the active mod.
        /// </summary>
        public IEnumerable<string>? ActiveMods { get; set; }

        /// <summary>
        /// A collection of mod names, filenames or paths to load as base data.
        /// </summary>
        public IEnumerable<string>? BaseMods { get; set; }

        /// <summary>
        /// The header to use for the active mod.
        /// </summary>
        public Header? Header { get; set; }

        /// <summary>
        /// The .info file data to use for the active mod.
        /// </summary>
        public ModInfoData? Info { get; set; }

        /// <summary>
        /// The installation to work against.
        /// </summary>
        public IInstallation Installation { get; set; }

        /// <summary>
        /// Determines if/how the enabled mods will be loaded.
        /// </summary>
        public ModLoadType LoadEnabledMods { get; set; }

        /// <summary>
        /// Determines if/how the game's base data files will be loaded.
        /// </summary>
        public ModLoadType LoadGameFiles { get; set; }

        /// <summary>
        /// The name of the active mod.
        /// </summary>
        public string Name { get; set; }
    }
}
