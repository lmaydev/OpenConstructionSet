#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery')
## LocalFolderLocator Class
Implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator') that looks for the folders in the working directory.  
```csharp
public class LocalFolderLocator :
OpenConstructionSet.IO.Discovery.IInstallationLocator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LocalFolderLocator  

Implements [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator')  

| Properties | |
| :--- | :--- |
| [Default](7fCyafFE4AOj_EYilY304g 'OpenConstructionSet.IO.Discovery.LocalFolderLocator.Default') | Lazy initiated singlton for when DI is not being used<br/> |
| [Id](Tv3mcoHT33E64PPIlq8i5g 'OpenConstructionSet.IO.Discovery.LocalFolderLocator.Id') | The unique identifier for this locator.<br/> |

| Methods | |
| :--- | :--- |
| [TryFind(LocatedFolders)](6HV7aSjQqa1XlK43PKrwhw 'OpenConstructionSet.IO.Discovery.LocalFolderLocator.TryFind(OpenConstructionSet.IO.LocatedFolders)') | Attempt to find an installation.<br/> |
