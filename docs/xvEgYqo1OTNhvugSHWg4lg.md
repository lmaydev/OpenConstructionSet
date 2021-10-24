#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO.Discovery](index.md#OpenConstructionSet_IO_Discovery 'OpenConstructionSet.IO.Discovery')
## ModNameResolver Class
Used to resolve a mod name (e.g. example.mod) to it's full path.  
```csharp
public class ModNameResolver :
OpenConstructionSet.IO.Discovery.IModNameResolver
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModNameResolver  

Implements [IModNameResolver](ocgulCoOZ5rxutpWQSp2oA.md 'OpenConstructionSet.IO.Discovery.IModNameResolver')  

| Constructors | |
| :--- | :--- |
| [ModNameResolver(IOcsService)](uHy0UjVZedsYr2g9vk6yZA.md 'OpenConstructionSet.IO.Discovery.ModNameResolver.ModNameResolver(OpenConstructionSet.IOcsService)') | Creates a new ModNameResolver instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](04JpsqNLVDkK2h61BhWNSw.md 'OpenConstructionSet.IO.Discovery.ModNameResolver.Default') | Lazy initiated singleton for when DI is not being used<br/> |

| Methods | |
| :--- | :--- |
| [Resolve(IEnumerable&lt;ModFolder&gt;, string)](Vp7z0w1hNtVv82tKpEC3eA.md 'OpenConstructionSet.IO.Discovery.ModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, string)') | Search the given folders for the specified mod.<br/> |
| [Resolve(IEnumerable&lt;ModFolder&gt;, IEnumerable&lt;string&gt;, bool)](kC8PqEUXA6HnSO7cDZiS3w.md 'OpenConstructionSet.IO.Discovery.ModNameResolver.Resolve(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;, System.Collections.Generic.IEnumerable&lt;string&gt;, bool)') | Resolve all provided mods using the given folders.<br/> |
