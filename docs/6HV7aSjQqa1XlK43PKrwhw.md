#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery').[LocalFolderLocator](rPXbOqKGJHUGKeNPKtAAmA 'OpenConstructionSet.IO.Discovery.LocalFolderLocator')
## LocalFolderLocator.TryFind(LocatedFolders) Method
Attempt to find an installation.  
```csharp
public bool TryFind(out OpenConstructionSet.IO.LocatedFolders folders);
```
#### Parameters
<a name='OpenConstructionSet_IO_Discovery_LocalFolderLocator_TryFind(OpenConstructionSet_IO_LocatedFolders)_folders'></a>
`folders` [LocatedFolders](jgv6_uiXfDVLa_l1InGCGA 'OpenConstructionSet.IO.LocatedFolders')  
If successful will be set to the located installation; otherwise, `null`.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an installation was found.

Implements [TryFind(LocatedFolders)](FOq4XE64PWeqicqrwqMb5Q 'OpenConstructionSet.IO.Discovery.IInstallationLocator.TryFind(OpenConstructionSet.IO.LocatedFolders)')  
