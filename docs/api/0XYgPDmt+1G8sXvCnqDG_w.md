#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context').[ModItemCollection](bRirTEn6uHiQP5Xo3cnnLA.md 'OpenConstructionSet.Mods.Context.ModItemCollection')
## ModItemCollection.GetChanges(IDictionary&lt;string,ModItem&gt;) Method
Compares this collection with another returning any changes.  
```csharp
public System.Collections.Generic.IEnumerable<OpenConstructionSet.Data.Item> GetChanges(System.Collections.Generic.IDictionary<string,OpenConstructionSet.Mods.ModItem> baseItems);
```
#### Parameters
<a name='OpenConstructionSet_Mods_Context_ModItemCollection_GetChanges(System_Collections_Generic_IDictionary_string_OpenConstructionSet_Mods_ModItem_)_baseItems'></a>
`baseItems` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
Collection to comapre to this one.
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection containing the added or modified [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')s.
