#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[CollectionExtensions](FWc82w3EK+Efojdw03oX_w.md 'OpenConstructionSet.CollectionExtensions')
## CollectionExtensions.OfType(IEnumerable&lt;Item&gt;, ItemType) Method
Returns all [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')s of the given [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType') from the collection.  
```csharp
public static System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.Item> OfType(this System.Collections.Generic.IEnumerable<OpenConstructionSet.Models.Item> collection, OpenConstructionSet.Models.ItemType type);
```
#### Parameters
<a name='OpenConstructionSet_CollectionExtensions_OfType(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_Item__OpenConstructionSet_Models_ItemType)_collection'></a>
`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of items to filter.
  
<a name='OpenConstructionSet_CollectionExtensions_OfType(System_Collections_Generic_IEnumerable_OpenConstructionSet_Models_Item__OpenConstructionSet_Models_ItemType)_type'></a>
`type` [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType')  
The type of item to return.
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
All items from the collection with the given type.
