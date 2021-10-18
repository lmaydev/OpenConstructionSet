#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery').[IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator')
## IInstallationLocator.TryFind(LocatedFolders) Method
Attempt to find an installation.  
```csharp
bool TryFind(out OpenConstructionSet.IO.LocatedFolders folders);
```
#### Parameters
<a name='OpenConstructionSet_IO_Discovery_IInstallationLocator_TryFind(OpenConstructionSet_IO_LocatedFolders)_folders'></a>
`folders` [LocatedFolders](jgv6_uiXfDVLa_l1InGCGA 'OpenConstructionSet.IO.LocatedFolders')  
If successful will be set to the located installation; otherwise, `null`.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an installation was found.
