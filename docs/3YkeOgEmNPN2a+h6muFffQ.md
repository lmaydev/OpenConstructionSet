#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data').[IOcsDataContextBuilder](wggJ0NkCl5tSu595OCPJxA.md 'OpenConstructionSet.Data.IOcsDataContextBuilder')
## IOcsDataContextBuilder.Build(string, bool, IEnumerable&lt;ModFolder&gt;?, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfo?, ModLoadType, ModLoadType) Method
Build a `OcsDataContext` from the provided information.  
```csharp
OpenConstructionSet.Data.OcsDataContext Build(string name, bool throwIfMissing=true, System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.ModFolder>? folders=null, System.Collections.Generic.IEnumerable<string>? baseMods=null, System.Collections.Generic.IEnumerable<string>? activeMods=null, OpenConstructionSet.Models.Header? header=null, OpenConstructionSet.Models.ModInfo? info=null, OpenConstructionSet.Models.ModLoadType loadGameFiles=OpenConstructionSet.Models.ModLoadType.None, OpenConstructionSet.Models.ModLoadType loadEnabledMods=OpenConstructionSet.Models.ModLoadType.None);
```
#### Parameters
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the new mod. e.g. example.mod
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_throwIfMissing'></a>
`throwIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` missing mods will cause exceptions to be thrown.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_folders'></a>
`folders` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModFolder](0h0FW6YI9iSflrhSD7PySw.md 'OpenConstructionSet.Models.ModFolder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of folders to use when resolving mod names to their path.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_baseMods'></a>
`baseMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mod names or paths to be loaded as base data.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_activeMods'></a>
`activeMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mod names or paths to loaded as active data.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_header'></a>
`header` [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')  
The header to use for the mod.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_info'></a>
`info` [ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo')  
The info to use for this mod.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_loadGameFiles'></a>
`loadGameFiles` [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ.md 'OpenConstructionSet.Models.ModLoadType')  
If not `ModLoadType`.None will load the game's base data files as specified.
  
<a name='OpenConstructionSet_Data_IOcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType_OpenConstructionSet_Models_ModLoadType)_loadEnabledMods'></a>
`loadEnabledMods` [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ.md 'OpenConstructionSet.Models.ModLoadType')  
If not `ModLoadType`.None will load the game's enabled mod files as specified.
  
#### Returns
[OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext')  
A [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext')
