#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsService Class
The main service for the OpenConstructionSet.  
Provides discovery and some saving/loading functions.  
```csharp
public class OcsService :
OpenConstructionSet.IOcsService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsService  

Implements [IOcsService](pMeR1KBG0zWkoR01rh3e5A.md 'OpenConstructionSet.IOcsService')  

| Constructors | |
| :--- | :--- |
| [OcsService(IEnumerable&lt;IInstallationLocator&gt;)](gMH_ap7byrAI445lsC3tEw.md 'OpenConstructionSet.OcsService.OcsService(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.IO.Discovery.IInstallationLocator&gt;)') | Creates a new `OcsService` instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](WoJL0QxFavF7Hgl0aBIKiw.md 'OpenConstructionSet.OcsService.Default') | Lazy initiated singlton for when DI is not being used<br/> |
| [SupportedFolderLocators](CclrmW1bn9pvIUNlPrG7Jg.md 'OpenConstructionSet.OcsService.SupportedFolderLocators') | The supported locator IDs.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverMod(string)](cKIJkTHACfb08quShbdmNw.md 'OpenConstructionSet.OcsService.DiscoverMod(string)') | Discovery the provided mod file reading it's header and info.<br/> |
| [DiscoverModFolder(string)](gPgSH2l7xB0Gr11yUAt5dg.md 'OpenConstructionSet.OcsService.DiscoverModFolder(string)') | Discover the provided folder and it's contained mods.<br/> |
| [DiscoverSave(string)](QFkTzFWIqi7Mw5yzE2H_rA.md 'OpenConstructionSet.OcsService.DiscoverSave(string)') | Discover the files in the given individual save folder<br/> |
| [DiscoverSaveFolder(string)](FMCQFoCrz5LumProw8SaCQ.md 'OpenConstructionSet.OcsService.DiscoverSaveFolder(string)') | Discover the provided save folder and contained saves.<br/> |
| [FindAllInstallations()](M9FpGNR9PaCf0+RjQZEldA.md 'OpenConstructionSet.OcsService.FindAllInstallations()') | Search using all installation locators and return any positive results.<br/> |
| [FindInstallation()](uOYd8eXDlYbO3JINPVF2aw.md 'OpenConstructionSet.OcsService.FindInstallation()') | Search using all installation locators and return the first positive results.<br/> |
| [FindInstallation(string)](rL9qOVDK+W1lff+qogaU9Q.md 'OpenConstructionSet.OcsService.FindInstallation(string)') | Use the provided locator to find the installation details.<br/> |
| [ReadHeader(string)](GuW4GXX94dq0fB5Q4qiWtw.md 'OpenConstructionSet.OcsService.ReadHeader(string)') | Attempts to read the header of the provided file.<br/> |
| [ReadLoadOrder(string)](Idg_nOiWNH00b+4VRSqwTw.md 'OpenConstructionSet.OcsService.ReadLoadOrder(string)') | Attempts to read the load order file. This file is contained in the game's data folder.<br/> |
| [SaveLoadOrder(string, IEnumerable&lt;string&gt;)](lidI5cI8yQJij_Iqj3lmwQ.md 'OpenConstructionSet.OcsService.SaveLoadOrder(string, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Save a collection of mod names to the load order file. This file is contained in the game's data folder.<br/> |
