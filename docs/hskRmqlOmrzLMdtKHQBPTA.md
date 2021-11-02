#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## IOcsDiscoveryService Interface
Provides discovery methods for the games various directory structures and files.  
```csharp
public interface IOcsDiscoveryService
```

Derived  
&#8627; [OcsDiscoveryService](xLh4AKenI1O4SsbfQkmoNQ.md 'OpenConstructionSet.OcsDiscoveryService')  

| Properties | |
| :--- | :--- |
| [SupportedFolderLocators](AyBuxJIrHbzthazCfNgloQ.md 'OpenConstructionSet.IOcsDiscoveryService.SupportedFolderLocators') | The supported locator IDs.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverAllInstallations()](z0mvm4_93cEJZwNrFOnYog.md 'OpenConstructionSet.IOcsDiscoveryService.DiscoverAllInstallations()') | Search using all installation locators and return any positive results.<br/> |
| [DiscoverInstallation()](njcNtzbGl4Ca0PBu2t7jxA.md 'OpenConstructionSet.IOcsDiscoveryService.DiscoverInstallation()') | Search using all installation locators and return the first positive results.<br/> |
| [DiscoverInstallation(string)](7KmBamZYdUwRE6nHHuy0dA.md 'OpenConstructionSet.IOcsDiscoveryService.DiscoverInstallation(string)') | Use the provided locator to find the installation details.<br/> |
| [DiscoverMod(string)](6bCb6usI8ldimgLjb_2vhw.md 'OpenConstructionSet.IOcsDiscoveryService.DiscoverMod(string)') | Discover the provided file reading it's header and info.<br/> |
| [DiscoverModFolder(string)](38JQyOaIvmZGZrHpS10u7w.md 'OpenConstructionSet.IOcsDiscoveryService.DiscoverModFolder(string)') | Discover the provided folder and it's contained mods.<br/> |
