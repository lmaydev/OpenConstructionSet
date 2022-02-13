#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context').[ModReferenceCollection](f6RRzzsjVUCH3ptIqc2CWw.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection')
## ModReferenceCollection.TryGetChanges(ModReferenceCollection, List&lt;Reference&gt;) Method
Compares this collection with another returning any changes.  
```csharp
public bool TryGetChanges(OpenConstructionSet.Mods.Context.ModReferenceCollection baseReferences, out System.Collections.Generic.List<OpenConstructionSet.Data.Reference> changes);
```
#### Parameters
<a name='OpenConstructionSet_Mods_Context_ModReferenceCollection_TryGetChanges(OpenConstructionSet_Mods_Context_ModReferenceCollection_System_Collections_Generic_List_OpenConstructionSet_Data_Reference_)_baseReferences'></a>
`baseReferences` [ModReferenceCollection](f6RRzzsjVUCH3ptIqc2CWw.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection')  
Collection to comapre to this one.
  
<a name='OpenConstructionSet_Mods_Context_ModReferenceCollection_TryGetChanges(OpenConstructionSet_Mods_Context_ModReferenceCollection_System_Collections_Generic_List_OpenConstructionSet_Data_Reference_)_changes'></a>
`changes` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A collection containing the added or modified [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if there are any changes; otherwise, `false`.
