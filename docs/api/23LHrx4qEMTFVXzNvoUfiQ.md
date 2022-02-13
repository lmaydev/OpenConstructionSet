#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[CollectionExtensions](FWc82w3EK+Efojdw03oX_w.md 'OpenConstructionSet.CollectionExtensions')
## CollectionExtensions.OfType&lt;TItem&gt;(IEnumerable&lt;TItem&gt;, ItemType) Method
Filters a collection of [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem')s by their type.  
```csharp
public static System.Collections.Generic.IEnumerable<TItem> OfType<TItem>(this System.Collections.Generic.IEnumerable<TItem> collection, OpenConstructionSet.Data.ItemType itemType)
    where TItem : OpenConstructionSet.Data.IItem;
```
#### Type parameters
<a name='OpenConstructionSet_CollectionExtensions_OfType_TItem_(System_Collections_Generic_IEnumerable_TItem__OpenConstructionSet_Data_ItemType)_TItem'></a>
`TItem`  
The concreate type of the [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem')s in the collection.
  
#### Parameters
<a name='OpenConstructionSet_CollectionExtensions_OfType_TItem_(System_Collections_Generic_IEnumerable_TItem__OpenConstructionSet_Data_ItemType)_collection'></a>
`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](23LHrx4qEMTFVXzNvoUfiQ.md#OpenConstructionSet_CollectionExtensions_OfType_TItem_(System_Collections_Generic_IEnumerable_TItem__OpenConstructionSet_Data_ItemType)_TItem 'OpenConstructionSet.CollectionExtensions.OfType&lt;TItem&gt;(System.Collections.Generic.IEnumerable&lt;TItem&gt;, OpenConstructionSet.Data.ItemType).TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The collection to filter.
  
<a name='OpenConstructionSet_CollectionExtensions_OfType_TItem_(System_Collections_Generic_IEnumerable_TItem__OpenConstructionSet_Data_ItemType)_itemType'></a>
`itemType` [ItemType](XuU7ysPytTqbguniJ5wn1A.md 'OpenConstructionSet.Data.ItemType')  
The type to filter by.
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](23LHrx4qEMTFVXzNvoUfiQ.md#OpenConstructionSet_CollectionExtensions_OfType_TItem_(System_Collections_Generic_IEnumerable_TItem__OpenConstructionSet_Data_ItemType)_TItem 'OpenConstructionSet.CollectionExtensions.OfType&lt;TItem&gt;(System.Collections.Generic.IEnumerable&lt;TItem&gt;, OpenConstructionSet.Data.ItemType).TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
All [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem')s in `collection` of the matching [ItemType](XuU7ysPytTqbguniJ5wn1A.md 'OpenConstructionSet.Data.ItemType').
