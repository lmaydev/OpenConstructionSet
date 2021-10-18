#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet](index#OpenConstructionSet 'OpenConstructionSet')
## IOcsService Interface
The main service for the OpenConstructionSet.  
Provides discovery and some saving/loading functions.  
```csharp
public interface IOcsService
```

Derived  
&#8627; [OcsService](vk7pKCZDraxUCiJOEKS3Rg 'OpenConstructionSet.OcsService')  

| Properties | |
| :--- | :--- |
| [SupportedFolderLocators](UwA4kNxpffxGa_aYJV_qzA 'OpenConstructionSet.IOcsService.SupportedFolderLocators') | The supported locator IDs.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverMod(string)](OIP9h6dwrOVFdPQ9VMsvLg 'OpenConstructionSet.IOcsService.DiscoverMod(string)') | Discover the provided file reading it's header and info.<br/> |
| [DiscoverModFolder(string)](k9cakNIC9E38AHeCZzayxw 'OpenConstructionSet.IOcsService.DiscoverModFolder(string)') | Discover the provided folder and it's contained mods.<br/> |
| [FindAllInstallations()](CSd0KkG23rZ8mZ8TezRJWQ 'OpenConstructionSet.IOcsService.FindAllInstallations()') | Search using all installation locators and return any positive results.<br/> |
| [FindInstallation()](21fF2IFoqfkA+8mYXwIIQA 'OpenConstructionSet.IOcsService.FindInstallation()') | Search using all installation locators and return the first positive results.<br/> |
| [FindInstallation(string)](HyboNlhQKJ4wPvxjo0UuUA 'OpenConstructionSet.IOcsService.FindInstallation(string)') | Use the provided locator to find the installation details.<br/> |
| [ReadHeader(string)](x8ZI81100G_xKK+2uJVciA 'OpenConstructionSet.IOcsService.ReadHeader(string)') | Attempts to read the header of the provided file.<br/> |
| [ReadLoadOrder(string)](NLgmxV3zuslgVQakvQXuCQ 'OpenConstructionSet.IOcsService.ReadLoadOrder(string)') | Attempts to read the load order file. This file is contained in the game's data folder.<br/> |
| [SaveLoadOrder(string, IEnumerable&lt;string&gt;)](BCnTj49m8nVi10bAisjxdQ 'OpenConstructionSet.IOcsService.SaveLoadOrder(string, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Save a collection of mod names to the load order file. This file is contained in the game's data folder.<br/> |
