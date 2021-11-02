#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsDiscoveryService Class
The main service for the OpenConstructionSet.  
Provides discovery and some saving/loading functions.  
```csharp
public class OcsDiscoveryService :
OpenConstructionSet.IOcsDiscoveryService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDiscoveryService  

Implements [IOcsDiscoveryService](hskRmqlOmrzLMdtKHQBPTA.md 'OpenConstructionSet.IOcsDiscoveryService')  

| Constructors | |
| :--- | :--- |
| [OcsDiscoveryService(IOcsIOService, IEnumerable&lt;IInstallationLocator&gt;)](lqEgqvwtfMkg3m12XKQfJA.md 'OpenConstructionSet.OcsDiscoveryService.OcsDiscoveryService(OpenConstructionSet.IOcsIOService, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.IO.Discovery.IInstallationLocator&gt;)') | Creates a new `OcsService` instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](vtKFzH_VNn4IvqwEwN6e2Q.md 'OpenConstructionSet.OcsDiscoveryService.Default') | Lazy initiated singleton for when DI is not being used<br/> |
| [SupportedFolderLocators](eNyWOBlagecbY7GP0UaGkw.md 'OpenConstructionSet.OcsDiscoveryService.SupportedFolderLocators') | The supported locator IDs.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverAllInstallations()](EGEqNnQqBPlw5k4PzXCN_w.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverAllInstallations()') | Search using all installation locators and return any positive results.<br/> |
| [DiscoverInstallation()](zVxkcwPic2WREGbceV9zrQ.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverInstallation()') | Search using all installation locators and return the first positive results.<br/> |
| [DiscoverInstallation(string)](Jn+DpgsDTLZPG54nqsVcLw.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverInstallation(string)') | Use the provided locator to find the installation details.<br/> |
| [DiscoverMod(string)](wy6HrDMPg5SJ+M94ExrkNA.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverMod(string)') | Discovery the provided mod file reading it's header and info.<br/> |
| [DiscoverModFolder(string)](6GdL09pdPPLFmKK2NfD9fg.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverModFolder(string)') | Discover the provided folder and it's contained mods.<br/> |
| [DiscoverSave(string)](LMnont_3sz7y4ViVLPxyfg.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverSave(string)') | Discover the files in the given individual save folder<br/> |
| [DiscoverSaveFolder(string)](6bd9JSjaItEIkNaZPO0_kA.md 'OpenConstructionSet.OcsDiscoveryService.DiscoverSaveFolder(string)') | Discover the provided save folder and contained saves.<br/> |
| [ReadHeader(string)](T2GIp4BTp8md_Qek+P7YeA.md 'OpenConstructionSet.OcsDiscoveryService.ReadHeader(string)') | Attempts to read the header of the provided file.<br/> |
