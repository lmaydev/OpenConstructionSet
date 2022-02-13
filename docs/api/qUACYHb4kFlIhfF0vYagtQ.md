#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations')
## Installation Class
Representation of an installation of the game.  
```csharp
public class Installation :
OpenConstructionSet.Installations.IInstallation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Installation  

Implements [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')  

| Constructors | |
| :--- | :--- |
| [Installation(string, string, string?)](CZFPZ0wKogM6j7BtHq8fAg.md 'OpenConstructionSet.Installations.Installation.Installation(string, string, string?)') | Creates a new [Installation](qUACYHb4kFlIhfF0vYagtQ.md 'OpenConstructionSet.Installations.Installation') from the provided values.<br/> |

| Properties | |
| :--- | :--- |
| [Content](rYCByuP7fBArpwH5GgCWDQ.md 'OpenConstructionSet.Installations.Installation.Content') | An Optional content [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/>Currently used for the Steam Workshop folder.<br/> |
| [Data](V7GrJUZ9G_LRxUMFqVs14Q.md 'OpenConstructionSet.Installations.Installation.Data') | A [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for the game's data folder.<br/> |
| [EnabledModsFile](xVPIDu2MI7FTcL6IqZp4BQ.md 'OpenConstructionSet.Installations.Installation.EnabledModsFile') | The path of the file that stores the enabled mods.<br/> |
| [Identifier](ohskzlAuvytjdymtTVcp6g.md 'OpenConstructionSet.Installations.Installation.Identifier') | Identifier of this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation').<br/> |
| [Mods](SL3nnx9guOiJo0_llOnyBw.md 'OpenConstructionSet.Installations.Installation.Mods') | A [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for the game's mods folder.<br/> |
| [Path](mKbqG3U+vys_I+O2NSNYMg.md 'OpenConstructionSet.Installations.Installation.Path') | The path of this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s game folder.<br/> |

| Methods | |
| :--- | :--- |
| [GetMods()](f3SsraXCHeiqmn7E0ddyiw.md 'OpenConstructionSet.Installations.Installation.GetMods()') | Search all [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')s for mods.<br/>Searches in the order Data, Mod, Content (if not null).<br/> |
| [ReadEnabledModsAsync(CancellationToken)](yQzkcR_CFoh61cQlh5UUDQ.md 'OpenConstructionSet.Installations.Installation.ReadEnabledModsAsync(System.Threading.CancellationToken)') | Reads the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile') to get the currently enabled mod's filenames and their load order.<br/>e.g. example.mod<br/> |
| [ToString()](S75V+HefX1Kk6KUNzxCQHw.md 'OpenConstructionSet.Installations.Installation.ToString()') | Returns a string that represents the current object. |
| [TryFind(string, IModFile)](nnP7Z6YBahj6W_GSzSukJg.md 'OpenConstructionSet.Installations.Installation.TryFind(string, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in all this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s folders.<br/> |
| [TryFind(string, uint, IModFile)](RV9cpX7wWMtzjC_EJfEIEA.md 'OpenConstructionSet.Installations.Installation.TryFind(string, uint, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in all this [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')'s folders.<br/> |
| [WriteEnabledModsAsync(IEnumerable&lt;string&gt;, CancellationToken)](1Lnyh5tM2bf82B8fyEZkdQ.md 'OpenConstructionSet.Installations.Installation.WriteEnabledModsAsync(System.Collections.Generic.IEnumerable&lt;string&gt;, System.Threading.CancellationToken)') | Writes the provided list of mod filename's to the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile').<br/>e.g. example.mod<br/> |
