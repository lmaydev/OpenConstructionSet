#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO.Discovery](index.md#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery').[ModNameResolver](xvEgYqo1OTNhvugSHWg4lg.md 'OpenConstructionSet.IO.Discovery.ModNameResolver')
## ModNameResolver.Resolve(IEnumerable&lt;ModFolder&gt;, string) Method
Search the given folders for the specified mod.  
```csharp
public OpenConstructionSet.Models.ModFile? Resolve(System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.ModFolder> modFolders, string mod);
```
#### Parameters
<a name='OpenConstructionSet_IO_Discovery_ModNameResolver_Resolve(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder__string)_modFolders'></a>
`modFolders` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModFolder](0h0FW6YI9iSflrhSD7PySw.md 'OpenConstructionSet.Models.ModFolder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
  
<a name='OpenConstructionSet_IO_Discovery_ModNameResolver_Resolve(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_ModFolder__string)_mod'></a>
`mod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Name of the mod to search for. e.g. example.mod
  
#### Returns
[ModFile](yIT20v2GHuAcdx4EIfntcw.md 'OpenConstructionSet.Models.ModFile')  
A `ModFile` if the name could be resolved; otherwise, `null`

Implements [Resolve(IEnumerable<ModFolder>, string)](8jj_U4AmfqZutCSIyVmG_w.md 'OpenConstructionSet.IO.Discovery.IModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, string)')  
