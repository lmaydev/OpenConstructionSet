#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[CollectionExtensions](FWc82w3EK+Efojdw03oX_w.md 'OpenConstructionSet.CollectionExtensions')
## CollectionExtensions.OfType(IDictionary&lt;string,DataItem&gt;, ItemType) Method
Returns all [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')s of the given [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType') from the collection.  
```csharp
public static System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string,OpenConstructionSet.Models.DataItem>> OfType(this System.Collections.Generic.IDictionary<string,OpenConstructionSet.Models.DataItem> dictionary, OpenConstructionSet.Models.ItemType type);
```
#### Parameters
<a name='OpenConstructionSet_CollectionExtensions_OfType(System_Collections_Generic_IDictionary_string_OpenConstructionSet_Models_DataItem__OpenConstructionSet_Models_ItemType)_dictionary'></a>
`dictionary` [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[DataItem](NedciBI8UIBYqbpYqrEXSw.md 'OpenConstructionSet.Models.DataItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')  
A dictionary of items to filter.
  
<a name='OpenConstructionSet_CollectionExtensions_OfType(System_Collections_Generic_IDictionary_string_OpenConstructionSet_Models_DataItem__OpenConstructionSet_Models_ItemType)_type'></a>
`type` [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType')  
The type of item to return.
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[DataItem](NedciBI8UIBYqbpYqrEXSw.md 'OpenConstructionSet.Models.DataItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
All items from the collection with the given type.
