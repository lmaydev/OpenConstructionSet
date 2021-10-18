#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery')
## IInstallationLocator Interface
Used to locate game installations from various platforms.  
```csharp
public interface IInstallationLocator
```

Derived  
&#8627; [GogFolderLocator](5SutPr2lrfLoH95lQlVPRg 'OpenConstructionSet.IO.Discovery.GogFolderLocator')  
&#8627; [LocalFolderLocator](rPXbOqKGJHUGKeNPKtAAmA 'OpenConstructionSet.IO.Discovery.LocalFolderLocator')  
&#8627; [SteamFolderLocator](BDvQhQsErjN5ilWJbjNpng 'OpenConstructionSet.IO.Discovery.SteamFolderLocator')  

| Properties | |
| :--- | :--- |
| [Id](tlCRx8blnAf9atqMJoLYKw 'OpenConstructionSet.IO.Discovery.IInstallationLocator.Id') | The unique identifier for this locator.<br/> |

| Methods | |
| :--- | :--- |
| [TryFind(LocatedFolders)](FOq4XE64PWeqicqrwqMb5Q 'OpenConstructionSet.IO.Discovery.IInstallationLocator.TryFind(OpenConstructionSet.IO.LocatedFolders)') | Attempt to find an installation.<br/> |
