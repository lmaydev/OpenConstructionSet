# The Open Construction Set

The OCS is a modding SDK for [Kenshi](https://lofigames.com/) written in C#

It provides services for dealing with the various folders and data files used by the game.
As well as providing a managed context for loading multiple mods for editing (Similar to FCS)

[Documentation](api/index.html)

## Features

 - Load, edit and save the game's data files. Currently supports .mod, .info, .base, .save, .zone, .platoon, .level.
 - Read and save the current enabled mods and load order.
 - Locate Steam and Gog installations of the game and it's folders. Including Steam's Workshop content folder and save.
 - Discover the structure of mod and save folders as well as the files contained.
 - Load multiple base and/or active mods into an OcsDataContext for editing. 
 - Save the active mod from an OcsDataContext.

## Introduction
### Project Setup
Add a reference to the main nuget (https://www.nuget.org/packages/OpenConstructionSet/)

Optionally add the dependency injection nuget (https://www.nuget.org/packages/OpenConstructionSet.DependencyInjection/)

### Accessing the Services

#### Using Dependency Injection
Once you have a reference to the dependency injection assembly simple add OCS to your services.

    services.UseOpenContructionSet();

This will setup `IOcsService` and `IOcsDataContextBuilder` for injection.

#### Using the "Default" system
While the project is designed to be used with dependency injection there is a secondary system for use if that isn't desirable.

All services provide a static lazy initialized singleton property called Default.
This property when first accessed will in turn access the Default property of it's dependencies to build an instance.
After this first call all subsequent calls will return the same instance.

    OcsService.Default.FindAllInstallations();

### Finding Installations and Discovering Game Folders

The `OcsService` provides methods for finding and exploring the game's folder structure.

#### Find the first locatable installation
By default the order of searching is Steam, Gog and Local.

    Installation? installation = OcsService.Default.FindInstallation();
    
    if (installation is null)
    {
        // Game could not be located
    }

#### Find a specific installation
    Installation? steam = OcsService.Default.FindInstallation("Steam");
    
    if (steam is null)
    {
        // Game could not be located
    }
    
#### Find all installlations

    Dictionary<string, Installation> installations = OcsService.Default.FindAllInstallations();
    if (installations.TryGetValue("Gog", out var gog))
    {
        // GOG installation located
    }

#### The Installation object

The `Installation` object will contain information about the installations folder and structure.

The `EnabledMods` property contains the enabled mods in load order.

It will contain up to 4 folders depending on which exist.

 1. `Data` - The data folder stores the game's base data files and configuration files.
 2. `Mods` - The standard mod folder.
 3. `Content` (Optional) - Currently used for storing the Steam Workshop content folder.
 4. `Save` (Optional) - This refers to old style save directory located in the game's root folder.

The first 3 are represented as `ModFolder` objects.
These contain information about the mods within the folder. Including header, info and full path.

The `Save` property is a `SaveFolder` object and contains information about the contained saves and their folder structure.

### Structure of a Data File.
LastId - the last number used to generate a StringID for an item e.g. 17-gamedata.quack for Greenlander
Header - Only included in mod files (Type 16) contains the meta data that is displayed in the launcher.
Items - collection of data items representing all in game entities. e.g. Building, Stats, Race

When OCS reads data files the Items are returned as a dictionary keyed by their StringID.

### The OcsDataContext

Once built allows editing of the data and saving any changes to a mod.

It works similar to FCS. You can load any number of base or active mods for editing.

#### Building

To get an `OcsDataContext` instance you must use the `IOcsDataContextBuilder` (or `OcsDataContextBuilder.Default`)

##### The Build method

This method takes all the required information and uses it to build a data context.

    OcsDataContext Build(string name, bool throwIfMissing = true, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null, IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, ModLoadType loadGameFiles = ModLoadType.None)

 - name - (Required) The name of the new mod.
 - throwIfMissing - If `true` missing mod files will generate exceptions. Otherwise they will be ignored.
 - folders - A collection of `ModFolder` objects to use when searching for a mods full path. Required if loading the game's data files.
 - basdeMods - A collection of mod names, file names or paths to load as base data. The base data will be loaded before applying the active mods on top.
 - activeMods - A collection of mod names, file names or paths to load as active. These mods will be applied on top of the base data and will form part of the changes saved to the new mod.
 - header - contains the meta data shown in the launcher (i.e. author, version, dependencies etc)
 - info - contains additional information about the mod. This takes the form of the .info file that is used for Steam Workshop et al.
 - loadGameFiles - if set to `ModLoadType.Active` or `ModLoadType.Base` the game's data files will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.

The following example builds the base data from the game's data files and all enabled mods whilst ignoring missing mods.

    var installation = OcsService.Default.FindInstallation() ?? throw new Exception("Game not found");
    
    var enabledMods = OcsService.Default.ReadLoadOrder(installation.Data.FullName);
    
    var context = OcsDataContextBuilder.Default.Build(
	    "Mod Name",
	    throwIfMissing: false,
	    folders: installation.ToModFolderArray(),
	    baseMods: enabledMods,
	    activeMods: new[] { "active.mod" },
	    header: new Header(1, "LMayDev", "Description"),
	    info: new ModInfo(0, "Name", "Title", OcsConstants.InfoTags[1..2], 0, DateTime.Now),
	    loadGameFiles: ModLoadType.Base);
    
    // edit context.Items here
    
    context.Save(installation.Mod);

### Loading Files

#### Save Files (Type 15)
Save files include .save, .zone, .platoon and .level

##### Load
    var (lastId, items) = new OcsReader(File.ReadAllBytes(@"\path\to\file")).ReadSave();
##### Save
    using var stream = File.Create(@"\path\to\file");
    new OcsWriter(stream).WriteSave(lastId, items.Values);

#### Mod files (Type 16)
Mod files include .base and .mod

##### Load
    var (lastId, header, items) = new OcsReader(File.ReadAllBytes(@"\path\to\file")).ReadMod();
##### Save
    using var stream = File.Create(@"\path\to\file");
    new OcsWriter(stream).WriteMod(lastId, header, items.Values);

#### Mod .info file
Many mods come with an additional .info file that contains information used by Steam Workshop and others applications.

##### Load
    using var stream = File.OpenRead(@"\path\to\info\file");
    var info = OcsIOHelper.ReadInfo(stream);

##### Save
    using var stream = File.Create(@"\path\to\info\file");
    info.WriteInfo(stream);

#### Load Order / Enabled mods
This refers to the mods that are ticked in the launcher and their order.
They can be accessed from an `Installation` object or accessed manually as below.

##### Load
    var enabledMods = OcsService.Default.ReadLoadOrder("path/to/game/data/");
##### Save
    OcsService.Default.SaveLoadOrder("path/to/game/data/", enabledMods);