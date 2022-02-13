#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations')
## IInstallation Interface
Representation of an installation of the game.  
```csharp
public interface IInstallation
```

Derived  
&#8627; [Installation](qUACYHb4kFlIhfF0vYagtQ.md 'OpenConstructionSet.Installations.Installation')  

| Properties | |
| :--- | :--- |
| [Content](VKEQAdOHfrAz9LM+N_aqAQ.md 'OpenConstructionSet.Installations.IInstallation.Content') | An Optional content [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/>Currently used for the Steam Workshop folder.<br/> |
| [Data](gJ25JqJ3vRHUz_bgG8Bt+A.md 'OpenConstructionSet.Installations.IInstallation.Data') | A [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for the game's data folder.<br/> |
| [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile') | The path of the file that stores the enabled mods.<br/> |
| [Identifier](2bz7kiw5bF4hYkta5nBf0A.md 'OpenConstructionSet.Installations.IInstallation.Identifier') | Identifier of this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation').<br/> |
| [Mods](kx8wkiX3niD3fGzMkQoPTw.md 'OpenConstructionSet.Installations.IInstallation.Mods') | A [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for the game's mods folder.<br/> |
| [Path](cYPej6JKMNjq7Tv0dX0EUQ.md 'OpenConstructionSet.Installations.IInstallation.Path') | The path of this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s game folder.<br/> |

| Methods | |
| :--- | :--- |
| [GetMods()](6iw_FWhkyp2HKCR6YsPBLw.md 'OpenConstructionSet.Installations.IInstallation.GetMods()') | Search all [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')s for mods.<br/>Searches in the order Data, Mod, Content (if not null).<br/> |
| [ReadEnabledModsAsync(CancellationToken)](R4LECTh0QvGrrvFQG7NAnw.md 'OpenConstructionSet.Installations.IInstallation.ReadEnabledModsAsync(System.Threading.CancellationToken)') | Reads the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile') to get the currently enabled mod's filenames and their load order.<br/>e.g. example.mod<br/> |
| [TryFind(string, IModFile)](VDOcksyhRlDTa+kNkaVJiQ.md 'OpenConstructionSet.Installations.IInstallation.TryFind(string, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in all this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s folders.<br/> |
| [TryFind(string, uint, IModFile)](oSpB2mMulQUN_RxRsvZfWg.md 'OpenConstructionSet.Installations.IInstallation.TryFind(string, uint, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in all this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s folders.<br/> |
| [WriteEnabledModsAsync(IEnumerable&lt;string&gt;, CancellationToken)](fFzRimNFcacL8fMk4nIhQw.md 'OpenConstructionSet.Installations.IInstallation.WriteEnabledModsAsync(System.Collections.Generic.IEnumerable&lt;string&gt;, System.Threading.CancellationToken)') | Writes the provided list of mod filename's to the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile').<br/>e.g. example.mod<br/> |
