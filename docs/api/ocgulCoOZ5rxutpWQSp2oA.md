#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO.Discovery](index#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery')
## IModNameResolver Interface
Used to resolve a mod name (e.g. example.mod) to it's full path.  
```csharp
public interface IModNameResolver
```

Derived  
&#8627; [ModNameResolver](xvEgYqo1OTNhvugSHWg4lg 'OpenConstructionSet.IO.Discovery.ModNameResolver')  

| Methods | |
| :--- | :--- |
| [Resolve(IEnumerable&lt;ModFolder&gt;, string)](8jj_U4AmfqZutCSIyVmG_w 'OpenConstructionSet.IO.Discovery.IModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, string)') | Search the given folders for the specified mod.<br/> |
| [Resolve(IEnumerable&lt;ModFolder&gt;, IEnumerable&lt;string&gt;, bool)](71xdm_SNO2pLQ4mobedkoQ 'OpenConstructionSet.IO.Discovery.IModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, System.Collections.Generic.IEnumerable&lt;string&gt;, bool)') | Resolve all provided mods using the given folders.<br/> |
