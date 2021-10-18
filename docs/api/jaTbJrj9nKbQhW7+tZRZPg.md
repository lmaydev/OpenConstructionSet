#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Data](index#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## OcsDataContextBuilder Class
Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') instances.  
```csharp
public class OcsDataContextBuilder :
OpenConstructionSet.Data.IOcsDataContextBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDataContextBuilder  

Implements [IOcsDataContextBuilder](wggJ0NkCl5tSu595OCPJxA 'OpenConstructionSet.Data.IOcsDataContextBuilder')  

| Constructors | |
| :--- | :--- |
| [OcsDataContextBuilder(IModNameResolver)](b7jWJ2iQqeDM9skgwU935Q 'OpenConstructionSet.Data.OcsDataContextBuilder.OcsDataContextBuilder(OpenConstructionSet.IO.Discovery.IModNameResolver)') | Creates a new OcsDataContextBuilder instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](y1nFPrh03XLIs_5hZvFf7A 'OpenConstructionSet.Data.OcsDataContextBuilder.Default') | Lazy initiated singlton for when DI is not being used<br/> |

| Methods | |
| :--- | :--- |
| [Build(string, bool, IEnumerable&lt;ModFolder&gt;?, IEnumerable&lt;string&gt;?, IEnumerable&lt;string&gt;?, Header?, ModInfo?, ModLoadType)](hACM7QW4mrhgy46Nc8gdPQ 'OpenConstructionSet.Data.OcsDataContextBuilder.Build(string, bool, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.ModFolder&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, System.Collections.Generic.IEnumerable&lt;string&gt;?, OpenConstructionSet.Models.Header?, OpenConstructionSet.Models.ModInfo?, OpenConstructionSet.Models.ModLoadType)') | Builds a [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') from the provided options<br/> |
