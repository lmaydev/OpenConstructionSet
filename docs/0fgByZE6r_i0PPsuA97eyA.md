#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data').[OcsDataOptions](dKJjgqs+isNwkwRmFoRW1A.md 'OpenConstructionSet.Data.OcsDataOptions')
## OcsDataOptions.OcsDataOptions(bool, Installation?, string?, IEnumerable&lt;string&gt;?, bool, bool) Constructor
Contains the required options to build a collection of game data for reference.  
```csharp
public OcsDataOptions(bool ThrowIfMissing=true, OpenConstructionSet.Models.Installation? Installation=null, string? InstallationName=null, System.Collections.Generic.IEnumerable<string>? Mods=null, bool LoadGameFiles=false, bool LoadEnabledMods=false);
```
#### Parameters
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_ThrowIfMissing'></a>
`ThrowIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` missing mod files will generate exceptions. Otherwise they will be ignored.
  
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_Installation'></a>
`Installation` [Installation](d9dvAYmZXntxn1p8iGWqPw.md 'OpenConstructionSet.Models.Installation')  
An `Installation` object to use when searching for a mods full path. If no installation object or name is provided discovery will be attempted.
  
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_InstallationName'></a>
`InstallationName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the installation to use when searching for a mods full path. If no installation object or name is provided discovery will be attempted.
  
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_Mods'></a>
`Mods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mod names, file names or paths to load.
  
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_LoadGameFiles'></a>
`LoadGameFiles` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` the game's files will be loaded.
  
<a name='OpenConstructionSet_Data_OcsDataOptions_OcsDataOptions(bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___bool_bool)_LoadEnabledMods'></a>
`LoadEnabledMods` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` the game's enabled mods will be loaded in order.
  
