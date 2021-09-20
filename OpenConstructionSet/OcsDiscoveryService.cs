using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet
{
    public class OcsDiscoveryService : IOcsDiscoveryService
    {
        private static IEnumerable<IFolderLocator> GetFolderLocators() =>
            new IFolderLocator[] { LocalFolderLocator.Default, SteamFolderLocator.Default, GogFolderLocator.Default };

        private static readonly Lazy<OcsDiscoveryService> _default = new(() => new(GetFolderLocators(), OcsModInfoService.Default, OcsFileService.Default));

        public static OcsDiscoveryService Default { get => _default.Value; }

        private readonly List<IFolderLocator> locators;
        private readonly IOcsModInfoService modInfoService;
        private readonly IOcsFileService fileService;

        private string[] SupportedFolderLocators { get; }

        public OcsDiscoveryService(IEnumerable<IFolderLocator> locators, IOcsModInfoService modInfoService, IOcsFileService fileService)
        {
            this.locators = locators.ToList();

            SupportedFolderLocators = locators.Select(l => l.Id).ToArray();
            this.modInfoService = modInfoService;
            this.fileService = fileService;
        }

        public Dictionary<string, ModFolders> TryFindAllGameFolders()
        {
            var result = new Dictionary<string, ModFolders>();

            foreach (var locator in SupportedFolderLocators)
            {
                if (TryFindGameFolders(locator, out var folders))
                {
                    result.Add(locator, folders);
                }
            }

            return result;
        }

        public bool TryFindGameFolders(string locatorId, [MaybeNullWhen(false)] out ModFolders folders)
        {
            var locator = locators.Find(l => l.Id == locatorId) ?? throw LocatorNotFound(locatorId);

            if (!locator.TryFind(out var folderPaths))
            {
                folders = null;
                return false;
            }

            if (!TryDiscoverFolder(folderPaths.Data, out var data) ||
                !TryDiscoverFolder(folderPaths.Mod, out var mod))
            {
                folders = null;
                return false;
            }

            if (folderPaths.Content is null || !TryDiscoverFolder(folderPaths.Content, out var content))
            {
                content = null;
            }

            folders = new(data, mod, content);
            return true;

            static Exception LocatorNotFound(string locatorId)
            {
                return new ArgumentException($"LocatorId \"{locatorId}\" was not found", nameof(locatorId));
            }
        }

        public bool TryFindGameFolders([MaybeNullWhen(false)] out ModFolders folders)
        {
            foreach (var locatorId in SupportedFolderLocators)
            {
                if (TryFindGameFolders(locatorId, out folders))
                {
                    return true;
                }
            }

            folders = null;
            return false;
        }

        public ModFolder? Discover(DirectoryInfo folder)
        {
            if (!folder.Exists)
            {
                return null;
            }

            var result = new ModFolder(folder.FullName);

            AddRange(folder.GetFiles("*.base").Select(Discover));
            AddRange(folder.GetFiles("*.mod").Select(Discover));
            AddRange(folder.GetDirectories().SelectMany(d => d.GetFiles("*.mod").Select(Discover)));

            void AddRange(IEnumerable<ModFile?> mods)
            {
                foreach (var mod in mods)
                {
                    if (mod is null)
                    {
                        continue;
                    }

                    result.Mods.Add(mod.Name, mod);
                }
            }

            return result;
        }

        public ModFile? Discover(FileInfo file)
        {
            if (!file.Exists)
            {
                return null;
            }

            using var reader = new OcsReader(file.FullName);

            if (!fileService.TryReadHeader(reader, out var header))
            {
                return null;
            }

            return new()
            {
                Name = file.Name,
                FullName = file.FullName,
                Header = header,
                Info = modInfoService.Read(file.FullName, true),
            };
        }

        public IEnumerable<ModFolder> Discoverfolders(IEnumerable<string> folders) => folders.Select(f =>
            Discover(new DirectoryInfo(f)) ?? throw new Exception($"Discovery failed for folder \"{f}\""));

        public IEnumerable<ModFile> DiscoverFiles(IEnumerable<string> files) => files.Select(f =>
            Discover(new FileInfo(f)) ?? throw new Exception($"Discovery failed for file \"{f}\"))"));

        public bool TryDiscoverFile(string path, [MaybeNullWhen(false)] out ModFile modFile) => TryDiscoverFile(new FileInfo(path), out modFile);

        private bool TryDiscoverFile(FileInfo file, [MaybeNullWhen(false)] out ModFile modFile)
        {
            try
            {
                modFile = Discover(file);

                if (modFile is not null)
                {
                    return true;
                }
            }
            catch
            {
            }

            modFile = null;
            return false;
        }

        public bool TryDiscoverFolder(string folder, [MaybeNullWhen(false)] out ModFolder modFolder)
           => TryDiscoverFolder(new DirectoryInfo(folder), out modFolder);

        /// <summary>
        /// Search the given folder for mods.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <returns>A <c>ModFolder</c> containing all discovered mods.</returns>
        public bool TryDiscoverFolder(DirectoryInfo folder, [MaybeNullWhen(false)] out ModFolder modFolder)
        {
            try
            {
                modFolder = Discover(folder);

                if (modFolder is not null)
                {
                    return true;
                }
            }
            catch
            {
            }

            modFolder = null;
            return false;
        }
    }
}
