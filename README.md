
# The Open Construction Set

The OCS is a modding SDK for [Kenshi](https://lofigames.com/) written in C#

It provides services for dealing with the various folders and data files used by the game.
As well as providing a managed context for loading multiple mods for editing (Similar to FCS)

[Documentation](docs/index.md)

A single cs file example patcher for [SCAR's pathfinding fix](https://www.nexusmods.com/kenshi/mods/602) can be found [here](https://github.com/lmaydev/OpenConstructionSet/blob/main/OpenConstructionSet.Example.Scar.PathFindingFix/Program.cs).

## Features

 - Load, edit and save the game's various data files.
 - Read and edit the enabled mods (Ticked in the launcher) and the load order.
 - Locate Steam and Gog installations of the game and their folders. Including Steam's Workshop content folder and the old save folder.
 - Discover the structure of mod and save folders as well as the files contained within.
 - Load multiple base and/or active mods into an `OcsDataContext` for editing and saving.

## Thanks
Massive shout out to [SCARaw](https://www.nexusmods.com/kenshi/users/16691049) for his help throughout the project.

## Introduction
### Project Setup
Add a reference to the main nuget (https://www.nuget.org/packages/OpenConstructionSet/)

Optionally add the dependency injection nuget (https://www.nuget.org/packages/OpenConstructionSet.DependencyInjection/)

### Accessing the Services

#### Using Dependency Injection
Once you have a reference to the dependency injection assembly simple add OCS to your services.

```csharp
    services.UseOpenContructionSet();
```

This will setup `IOcsDiscoverService`, `IOcsIOService` and `IOcsDataContextBuilder` for injection.

#### Using the "Default" system
While the project is designed to be used with dependency injection there is a secondary system for use if that isn't desirable.

All services provide a static lazy initialized singleton property called Default.

This property when first accessed will in turn access the Default property of it's dependencies to build an instance.
After this first call all subsequent calls will return the same instance.

```csharp
OcsDiscoverService.Default.FindAllInstallations();
```

### Finding Installations and Discovering Game Folders

The `OcsDiscoverService` provides methods for finding and exploring the game's folder structure.

#### Find the first locatable installation
By default the order of searching is Steam, Gog and Local.

```csharp
Installation? installation = OcsDiscoverService.Default.FindInstallation();
    
if (installation is null)
{
    // Game could not be located
}
```

#### Find a specific installation
```csharp
Installation? steam = OcsDiscoverService.Default.FindInstallation("Steam");
    
if (steam is null)
{
    // Game could not be located
}
```   
#### Find all installations

```csharp
Dictionary<string, Installation> installations = OcsDiscoverService.Default.FindAllInstallations();
if (installations.TryGetValue("Gog", out var gog))
{
    // GOG installation located
}
```

#### The Installation object

The `Installation` object will contain information about the installations folder and structure.

The `EnabledMods` property contains the enabled mods in load order.

It will contain up to 4 folders depending on which exist.

 - `Data` - The data folder stores the game's base data files and configuration files.
 - `Mods` - The standard mod folder.
 - `Content` (Optional) - Currently used for storing the Steam Workshop content folder.
 - `Save` (Optional) - This refers to old style save directory located in the game's root folder.

The first 3 are represented as `ModFolder` objects. These contain information about the mods within the folder. Including header, info and full path.

The `Save` property is a `SaveFolder` object and contains information about the contained saves and their folder structure.

### Structure of a Data File.
 - Type - Integer indicating the type of the file. Currently 15 (save) and 16 (mod) are supported.
 - LastId - The last number used to generate a StringID for an item e.g. 17-gamedata.quack for Greenlander.
 - Header - Only included in mod files (Type 16) contains the meta data that is displayed in the launcher.
 - Items - Collection of data items representing all in game entities. i.e. Building, Stats, Race etc.

### The OcsDataContext

Once built allows editing of the data and saving any changes to a mod.

It works similar to FCS. You can load any number of base or active mods for editing.

#### Building

To get an `OcsDataContext` instance you must use the `IOcsDataContextBuilder` (or `OcsDataContextBuilder.Default`)

##### OcsDataContexOptions

This object contains all information required to build an `OcsDataContext`.
 - Name - (Required) The name of the new mod.
 - ThrowIfMissing - If `true` missing mod files will generate exceptions. Otherwise they will be ignored.
 - Installation - An `Installation` object to use when searching for a mods full path and used later by the `OcsDataContext`. If `null` discovery will be attempted.
 - BaseMods - A collection of mod names, file names or paths to load as base data. The base data will be loaded before applying the active mods on top.
 - ActiveMods - A collection of mod names, file names or paths to load as active. These mods will be applied on top of the base data and will form part of the changes saved to the new mod.
 - Header - Contains the meta data shown in the launcher (i.e. author, version, dependencies etc)
 - Info - Contains additional information about the mod. This takes the form of the .info file that is used for Steam Workshop et al.
 - LoadGameFiles - If set to `ModLoadType.Active` or `ModLoadType.Base` the game's data files will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.
 - LoadEnabledMods - As above but it will load the enabled mods in load order.

##### Using the builder

To build an `OcsDataContext` you must call the `IOcsDataContextBuilder.Build` method with an `OcsDataContextOptions` object.

The following example loads the game's base data files and enabled mods as base data with a new mod called example active.

```csharp
var installation = OcsDiscoverService.Default.FindInstallation() ?? throw new Exception("Game not found");
    
var options = new OcsDataContexOptions(
    "example",
    Installation: installation,
    LoadGameFiles: ModLoadType.Base,
    LoadEnabledMods: ModLoadType.Base,
    Header: new Header(1, "LMayDev", "Description"));

var context = OcsDataContextBuilder.Default.Build(options);
    
// edit context.Items here
    
// Saves to the installations Mod folder
context.Save();
```

### Loading Files

#### Data Files
This includes all type 15 (Save) and 16 (Mod) files.

```csharp
if (OcsIOService.Default.TryReadDataFile("path/to/data/file", out var data))
{
    data = data with { LastId = data.LastId + 1 };

    OcsIOService.Default.Write("path/to/data/file", data);
}
```

#### Enabled Mods
These are the ticked mods from the launcher. They are saved in `[game folder]/data/mods.cfg` file.
```csharp
if (OcsIOService.Default.TryReadEnabledMods("path/to/mods.cfg", out var enabledMods))
{
    enabledMods.Add("example.mod");

    OcsIOService.Default.Write("path/to/mods.cfg", enabledMods);
}
```

You can also edit them directly on an Installation object and save through the `IOcsIOService`.

```csharp
installation.EnabledMods.Add("example.mod");
OcsIOService.Default.SaveEnabledMods(installation);
```

#### Headers
Read the header from a Mod (Type 16) file.
```csharp
if (!OcsIOService.Default.TryReadHeader("path/to/mod/file", out var header))
{
    throw new Exception("File missing or not a valid Mod");
}
```

#### Info Files
Many mods come with a matching .info file.
This stores data used by Steam Workshop.
```csharp
if (OcsIOService.Default.TryReadInfo("path/to/info/file", out var info))
{
    info.LastUpdate = DateTime.Now;

    OcsIOService.Default.Write("path/to/info/file", info);
}
```