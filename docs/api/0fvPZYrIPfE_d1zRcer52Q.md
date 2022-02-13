#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context')
## ModContextOptions Class
Options used to build a mod context.  
```csharp
public class ModContextOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModContextOptions  

| Constructors | |
| :--- | :--- |
| [ModContextOptions(string, IInstallation, bool, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfoData?, ModLoadType, ModLoadType)](qNIprOvlQ6dGCudtH6i1YA.md 'OpenConstructionSet.Mods.Context.ModContextOptions.ModContextOptions(string, OpenConstructionSet.Installations.IInstallation, bool, System.Collections.Generic.IEnumerable&lt;string&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, OpenConstructionSet.Data.Header?, OpenConstructionSet.Mods.ModInfoData?, OpenConstructionSet.Mods.ModLoadType, OpenConstructionSet.Mods.ModLoadType)') | Creates a new [ModContextOptions](0fvPZYrIPfE_d1zRcer52Q.md 'OpenConstructionSet.Mods.Context.ModContextOptions') from the provided values.<br/> |

| Properties | |
| :--- | :--- |
| [ActiveMods](qUIOcI+dNo6xs15R81Ls+g.md 'OpenConstructionSet.Mods.Context.ModContextOptions.ActiveMods') | A collection of mod names, filenames or paths to load into the active mod.<br/> |
| [BaseMods](G0AhFztA26Se4+V+0qTgUA.md 'OpenConstructionSet.Mods.Context.ModContextOptions.BaseMods') | A collection of mod names, filenames or paths to load as base data.<br/> |
| [Header](VS3GuhFSHyHLevOlycDN1Q.md 'OpenConstructionSet.Mods.Context.ModContextOptions.Header') | The header to use for the active mod.<br/> |
| [Info](lS5XMPcUNV9Gzvvso1Lerg.md 'OpenConstructionSet.Mods.Context.ModContextOptions.Info') | The .info file data to use for the active mod.<br/> |
| [Installation](jZT7Vctd8gamNHC9g51_Kw.md 'OpenConstructionSet.Mods.Context.ModContextOptions.Installation') | The installation to work against.<br/> |
| [LoadEnabledMods](xB6ngPkH5uxu2sdEseocOw.md 'OpenConstructionSet.Mods.Context.ModContextOptions.LoadEnabledMods') | Determines if/how the enabled mods will be loaded.<br/> |
| [LoadGameFiles](epW97g9zuC0ZSOMkLU52rg.md 'OpenConstructionSet.Mods.Context.ModContextOptions.LoadGameFiles') | Determines if/how the game's base data files will be loaded.<br/> |
| [Name](NiehBJptNbVOM_SW_baA4A.md 'OpenConstructionSet.Mods.Context.ModContextOptions.Name') | The name of the active mod e.g. example or example.mod<br/> |
| [ThrowIfMissing](NrySEeSLgzJPcfEcZadD0A.md 'OpenConstructionSet.Mods.Context.ModContextOptions.ThrowIfMissing') | If set to `true` missing mods will cause an exception to be thrown.<br/> |
