#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO.Discovery](index.md#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery').[ModNameResolver](xvEgYqo1OTNhvugSHWg4lg.md 'OpenConstructionSet.IO.Discovery.ModNameResolver')
## ModNameResolver.Resolve(IEnumerable&lt;ModFolder&gt;, IEnumerable&lt;string&gt;, bool) Method
Resolve all provided mods using the given folders.  
```csharp
public System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.ModFile> Resolve(System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.ModFolder> folders, System.Collections.Generic.IEnumerable<string> mods, bool throwIfMissing);
```
#### Parameters
<a name='OpenConstructionSet_IO_Discovery_ModNameResolver_Resolve(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder__System_Collections_Generic_IEnumerable_string__bool)_folders'></a>
`folders` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModFolder](0h0FW6YI9iSflrhSD7PySw.md 'OpenConstructionSet.Models.ModFolder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of folders to search.
  
<a name='OpenConstructionSet_IO_Discovery_ModNameResolver_Resolve(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder__System_Collections_Generic_IEnumerable_string__bool)_mods'></a>
`mods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of mod names to search for. e.g. exmaple.mod
  
<a name='OpenConstructionSet_IO_Discovery_ModNameResolver_Resolve(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder__System_Collections_Generic_IEnumerable_string__bool)_throwIfMissing'></a>
`throwIfMissing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true` an exception will be thrown for any missing mods.  
If `false` missing mods will be omitted from the results.  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModFile](yIT20v2GHuAcdx4EIfntcw.md 'OpenConstructionSet.Models.ModFile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of all mods that could be resolved.

Implements [Resolve(IEnumerable<ModFolder>, IEnumerable<string>, bool)](71xdm_SNO2pLQ4mobedkoQ.md 'OpenConstructionSet.IO.Discovery.IModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, System.Collections.Generic.IEnumerable&lt;string&gt;, bool)')  
