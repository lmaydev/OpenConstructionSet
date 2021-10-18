#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Data](index#OpenConstructionSet_Data 'OpenConstructionSet.Data').[OcsDataContextBuilder](jaTbJrj9nKbQhW7+tZRZPg 'OpenConstructionSet.Data.OcsDataContextBuilder')
## OcsDataContextBuilder.Build(string, bool, IEnumerable&lt;ModFolder&gt;?, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfo?, ModLoadType) Method
Builds a [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') from the provided options  
```csharp
public OpenConstructionSet.Data.OcsDataContext Build(string name, bool throwIfMissing=true, System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.ModFolder>? folders=null, System.Collections.Generic.IEnumerable<string>? baseMods=null, System.Collections.Generic.IEnumerable<string>? activeMods=null, OpenConstructionSet.Models.Header? header=null, OpenConstructionSet.Models.ModInfo? info=null, OpenConstructionSet.Models.ModLoadType loadGameFiles=OpenConstructionSet.Models.ModLoadType.None);
```
#### Parameters
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the mod e.g. example.mod
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_throwIfMissing'></a>
`throwIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` missing mods will cause exceptions to be thrown.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_folders'></a>
`folders` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModFolder](0h0FW6YI9iSflrhSD7PySw 'OpenConstructionSet.Models.ModFolder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of folders used when resolving mod names. If loading game files `folders` can not be `null`.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_baseMods'></a>
`baseMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mods to load as the base data.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_activeMods'></a>
`activeMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mods to load as active. When saving data from these mods will be saved along with any changes.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_header'></a>
`header` [Header](bjExWrZuBlRDCiIUljjMrA 'OpenConstructionSet.Models.Header')  
Header for the new mod.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_info'></a>
`info` [ModInfo](h0vCAhsmAC6iWOaLYw25cg 'OpenConstructionSet.Models.ModInfo')  
Values for the mod's info file.
  
<a name='OpenConstructionSet_Data_OcsDataContextBuilder_Build(string_bool_System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder___System_Collections_Generic_IEnumerable_string___System_Collections_Generic_IEnumerable_string___OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo__OpenConstructionSet_Models_ModLoadType)_loadGameFiles'></a>
`loadGameFiles` [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ 'OpenConstructionSet.Models.ModLoadType')  
If not `None` the base game files will be loaded as specified.
  
#### Returns
[OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext')  
An OcsDataContext built from the provded values.

Implements [Build(string, bool, IEnumerable<ModFolder>?, IEnumerable<string>?, IEnumerable<string>?, Header?, ModInfo?, ModLoadType)](yW75lP5IvCKmD530_HprKQ 'OpenConstructionSet.Data.IOcsDataContextBuilder.Build(string, bool, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, OpenConstructionSet.Models.Header?, OpenConstructionSet.Models.ModInfo?, OpenConstructionSet.Models.ModLoadType)')  
