#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context').[ModContextOptions](0fvPZYrIPfE_d1zRcer52Q.md 'OpenConstructionSet.Mods.Context.ModContextOptions')
## ModContextOptions.ModContextOptions(string, IInstallation, bool, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfoData?, ModLoadType, ModLoadType) Constructor
Creates a new [ModContextOptions](0fvPZYrIPfE_d1zRcer52Q.md 'OpenConstructionSet.Mods.Context.ModContextOptions') from the provided values.  
```csharp
public ModContextOptions(string name, OpenConstructionSet.Installations.IInstallation installation, bool throwIfMissing=false, System.Collections.Generic.IEnumerable<string>? activeMods=null, System.Collections.Generic.IEnumerable<string>? baseMods=null, OpenConstructionSet.Data.Header? header=null, OpenConstructionSet.Mods.ModInfoData? info=null, OpenConstructionSet.Mods.ModLoadType loadEnabledMods=OpenConstructionSet.Mods.ModLoadType.None, OpenConstructionSet.Mods.ModLoadType loadGameFiles=OpenConstructionSet.Mods.ModLoadType.None);
```
#### Parameters
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the active mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_installation'></a>
`installation` [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')  
The installation to work against.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_throwIfMissing'></a>
`throwIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` the process will error when files are missing.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_activeMods'></a>
`activeMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Optional collection of mod names, filenames or paths to load into the active mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_baseMods'></a>
`baseMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Optional collection of mod names, filenames or paths to load as base data.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_header'></a>
`header` [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header')  
Optional header to use for the active mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_info'></a>
`info` [ModInfoData](ZdFSsCp5Yk427RM+q39Nmw.md 'OpenConstructionSet.Mods.ModInfoData')  
Optional .info file data to use for the active mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_loadEnabledMods'></a>
`loadEnabledMods` [ModLoadType](xO6px+9R12hGk3SWOoCfLQ.md 'OpenConstructionSet.Mods.ModLoadType')  
Determines if/how the enabled mods will be loaded.
  
<a name='OpenConstructionSet_Mods_Context_ModContextOptions_ModContextOptions(string_OpenConstructionSet_Installations_IInstallation_bool_System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData__OpenConstructionSet_Mods_ModLoadType_OpenConstructionSet_Mods_ModLoadType)_loadGameFiles'></a>
`loadGameFiles` [ModLoadType](xO6px+9R12hGk3SWOoCfLQ.md 'OpenConstructionSet.Mods.ModLoadType')  
Determines if/how the game's base data files will be loaded.
  
