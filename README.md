# The Open Construction Set

The OCS is a modding SDK for [Kenshi](https://lofigames.com/) written in C#

It provides services for dealing with the various folders and data files used by the game.
As well as providing a managed context for loading multiple mods for editing (Similar to FCS)

[API Docs](docs//api/index.md)

A single cs file example patcher for [SCAR's pathfinding fix](https://www.nexusmods.com/kenshi/mods/602) can be found [here](https://github.com/lmaydev/OpenConstructionSet/blob/main/OpenConstructionSet.Example.Scar.PathFindingFix/Program.cs).

## Features

 - Load, edit and save the game's various data files.
 - Read and edit the enabled mods (Ticked in the launcher) and the load order.
 - Locate Steam and Gog installations of the game and their folders. Including Steam's Workshop content folder and the old save folder.
 - Discover the structure of mod and save folders as well as the files contained within.
 - Load multiple base and/or active mods into a `ModDataContext` for editing and saving.

## Thanks
Massive shout out to [SCARaw](https://www.nexusmods.com/kenshi/users/16691049) for his help throughout the project.

## Introduction
### Project Setup
Add the main nuget (https://www.nuget.org/packages/OpenConstructionSet/)

### Using Dependency Injection
Add OCS to your services.

```csharp
services.UseOpenContructionSet();
```

This will setup the ```IInstallationService``` and the `IContextBuilder`

### Using Services directly

Both services can be contructed normally

```csharp
var installationService = new InstallationService();
var contextBuilder = new ContextBuilder();
```

### Services
- ```IInstallationService``` - Provides functions for locating installations of the game.
- ```IContextBuilder``` - Provides functions for building FCS like Mod Contexts. These allow multiple base and/or active mods to be loaded for editing.