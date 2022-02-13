#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context').[ModContext](bg5IPPU_c0JbekfhoR9TnQ.md 'OpenConstructionSet.Mods.Context.ModContext')
## ModContext.ModContext(Dictionary&lt;string,ModItem&gt;, IEnumerable&lt;ModItem&gt;, IInstallation, string, int, Header?, ModInfoData?) Constructor
Creates a new [ModContext](bg5IPPU_c0JbekfhoR9TnQ.md 'OpenConstructionSet.Mods.Context.ModContext') from the provided data.  
```csharp
public ModContext(System.Collections.Generic.Dictionary<string,OpenConstructionSet.Mods.ModItem> baseItems, System.Collections.Generic.IEnumerable<OpenConstructionSet.Mods.ModItem> activeItems, OpenConstructionSet.Installations.IInstallation installation, string modName, int lastId, OpenConstructionSet.Data.Header? header=null, OpenConstructionSet.Mods.ModInfoData? info=null);
```
#### Parameters
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_baseItems'></a>
`baseItems` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
Collection of item's loaded as base data. Used to compare for changes when saving.
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_activeItems'></a>
`activeItems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Collection of item's loaded as active data. Used for editing the mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_installation'></a>
`installation` [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')  
The installation to use when saving.
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the mod when saving.
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_lastId'></a>
`lastId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The last ID used when generating an [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId').
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_header'></a>
`header` [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header')  
The header to use for the mod.
  
<a name='OpenConstructionSet_Mods_Context_ModContext_ModContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Mods_ModItem__System_Collections_Generic_IEnumerable_OpenConstructionSet_Mods_ModItem__OpenConstructionSet_Installations_IInstallation_string_int_OpenConstructionSet_Data_Header__OpenConstructionSet_Mods_ModInfoData_)_info'></a>
`info` [ModInfoData](ZdFSsCp5Yk427RM+q39Nmw.md 'OpenConstructionSet.Mods.ModInfoData')  
Optional data for the mod's .info file.
  
