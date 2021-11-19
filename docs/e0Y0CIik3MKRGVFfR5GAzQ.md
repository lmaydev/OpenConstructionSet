#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data').[OcsSaveContexOptions](HPin6P0txB1XEEHR7cNrxA.md 'OpenConstructionSet.Data.OcsSaveContexOptions')
## OcsSaveContexOptions.OcsSaveContexOptions(string, bool, Installation?, string?, IEnumerable&lt;string&gt;?, Header?, ModInfo?, bool, bool) Constructor
Contains the required options to build an [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext').  
```csharp
public OcsSaveContexOptions(string Name, bool ThrowIfMissing=true, OpenConstructionSet.Models.Installation? Installation=null, string? InstallationName=null, System.Collections.Generic.IEnumerable<string>? Mods=null, OpenConstructionSet.Models.Header? Header=null, OpenConstructionSet.Models.ModInfo? Info=null, bool LoadGameFiles=false, bool LoadEnabledMods=false);
```
#### Parameters
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_Name'></a>
`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(Required) The name of the save.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_ThrowIfMissing'></a>
`ThrowIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` missing mod files will generate exceptions. Otherwise they will be ignored.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_Installation'></a>
`Installation` [Installation](d9dvAYmZXntxn1p8iGWqPw.md 'OpenConstructionSet.Models.Installation')  
An `Installation` object to use when searching for a mods full path and later by the `OcsDataContext`. If no installation object or name is provided discovery will be attempted.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_InstallationName'></a>
`InstallationName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the installation to use when searching for a mods full path. If no installation object or name is provided discovery will be attempted.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_Mods'></a>
`Mods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mod names, file names or paths to load as base data. The base data will be loaded before applying the active mods on top.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_Header'></a>
`Header` [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')  
Contains the meta data shown in the launcher (i.e. author, version, dependencies, etc)
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_Info'></a>
`Info` [ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo')  
Contains additional information about the mod. This takes the form of the .info file that is used for Steam Workshop et al.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_LoadGameFiles'></a>
`LoadGameFiles` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If set to `ModLoadType.Active` or `ModLoadType.Base` the game's data files will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.
  
<a name='OpenConstructionSet_Data_OcsSaveContexOptions_OcsSaveContexOptions(string_bool_OpenConstructionSet_Models_Installation__string__System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__bool_bool)_LoadEnabledMods'></a>
`LoadEnabledMods` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If set to `ModLoadType.Active` or `ModLoadType.Base` the game's enabled mods will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.
  
