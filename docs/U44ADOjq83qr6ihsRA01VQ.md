#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsDataContextBuilder Class
Used to build game data and [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext')s.  
```csharp
public class OcsDataContextBuilder :
OpenConstructionSet.IOcsDataContextBuilder,
OpenConstructionSet.IOcsDataBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDataContextBuilder  

Implements [IOcsDataContextBuilder](r4RI8NnQPrFwlGRexUtVqQ.md 'OpenConstructionSet.IOcsDataContextBuilder'), [IOcsDataBuilder](9ZN26e3kraTy7mxkYWEwlw.md 'OpenConstructionSet.IOcsDataBuilder')  

| Constructors | |
| :--- | :--- |
| [OcsDataContextBuilder(IOcsDiscoveryService, IOcsIOService, IModNameResolver)](3xe_PmdjFfa0PxAg9sz8jQ.md 'OpenConstructionSet.OcsDataContextBuilder.OcsDataContextBuilder(OpenConstructionSet.IOcsDiscoveryService, OpenConstructionSet.IOcsIOService, OpenConstructionSet.IO.Discovery.IModNameResolver)') | Creates a new OcsDataContextBuilder instance.<br/> |

| Properties | |
| :--- | :--- |
| [Default](ZOofc9eXLyzJ8GlzWL6tXw.md 'OpenConstructionSet.OcsDataContextBuilder.Default') | Lazy initiated singleton for when DI is not being used<br/> |

| Methods | |
| :--- | :--- |
| [Build(OcsDataContexOptions)](LxyrMTFk2urLcVN4TgFfdA.md 'OpenConstructionSet.OcsDataContextBuilder.Build(OpenConstructionSet.Data.OcsDataContexOptions)') | Build a `OcsDataContext` from the provided options.<br/> |
| [Build(OcsDataOptions)](fGE1msKzvOCVDqkCkKj24A.md 'OpenConstructionSet.OcsDataContextBuilder.Build(OpenConstructionSet.Data.OcsDataOptions)') | Build game data using the provided options.<br/> |
