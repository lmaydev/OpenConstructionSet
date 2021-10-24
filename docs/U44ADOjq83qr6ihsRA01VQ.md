#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsDataContextBuilder Class
Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') instances.  
```csharp
public class OcsDataContextBuilder :
OpenConstructionSet.Data.IOcsDataContextBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDataContextBuilder  

Implements [IOcsDataContextBuilder](wggJ0NkCl5tSu595OCPJxA.md 'OpenConstructionSet.Data.IOcsDataContextBuilder')  

| Constructors | |
| :--- | :--- |
| [OcsDataContextBuilder(IOcsService, IModNameResolver)](ptSnVmHh5omcxXH1DNF6Hw.md 'OpenConstructionSet.OcsDataContextBuilder.OcsDataContextBuilder(OpenConstructionSet.IOcsService, OpenConstructionSet.IO.Discovery.IModNameResolver)') | Creates a new OcsDataContextBuilder instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](ZOofc9eXLyzJ8GlzWL6tXw.md 'OpenConstructionSet.OcsDataContextBuilder.Default') | Lazy initiated singlton for when DI is not being used<br/> |

| Methods | |
| :--- | :--- |
| [Build(string, bool, IEnumerable&lt;ModFolder&gt;?, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfo?, ModLoadType, ModLoadType)](5zXK0cMpuVjyEQ0WlrU3gQ.md 'OpenConstructionSet.OcsDataContextBuilder.Build(string, bool, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, OpenConstructionSet.Models.Header?, OpenConstructionSet.Models.ModInfo?, OpenConstructionSet.Models.ModLoadType, OpenConstructionSet.Models.ModLoadType)') | Builds a [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') from the provided options<br/> |
