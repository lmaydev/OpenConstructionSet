#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context').[ModInstanceCollection](0uExS63t3Fj8LbKEgspDWg.md 'OpenConstructionSet.Mods.Context.ModInstanceCollection')
## ModInstanceCollection.GetChanges(ModInstanceCollection) Method
Compares this collection with another returning any changes.  
```csharp
public System.Collections.Generic.IEnumerable<OpenConstructionSet.Data.Instance> GetChanges(OpenConstructionSet.Mods.Context.ModInstanceCollection baseInstances);
```
#### Parameters
<a name='OpenConstructionSet_Mods_Context_ModInstanceCollection_GetChanges(OpenConstructionSet_Mods_Context_ModInstanceCollection)_baseInstances'></a>
`baseInstances` [ModInstanceCollection](0uExS63t3Fj8LbKEgspDWg.md 'OpenConstructionSet.Mods.Context.ModInstanceCollection')  
Collection to comapre to this one.
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection containing the added or modified [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance')s.
