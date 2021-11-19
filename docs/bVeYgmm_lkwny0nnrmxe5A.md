#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[ModelExtensions](d4l5JwZnO8DdkML7qnh_1g.md 'OpenConstructionSet.ModelExtensions')
## ModelExtensions.AddOrUpdate(Dictionary&lt;string,Item&gt;, Item) Method
If `item`'s `StringId` does not exists in `items` it is added. Otherwise the existing item is updated with the data from `item`
```csharp
public static void AddOrUpdate(this System.Collections.Generic.Dictionary<string,OpenConstructionSet.Models.Item> items, OpenConstructionSet.Models.Item item);
```
#### Parameters
<a name='OpenConstructionSet_ModelExtensions_AddOrUpdate(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__OpenConstructionSet_Models_Item)_items'></a>
`items` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
The collection of items to work against.
  
<a name='OpenConstructionSet_ModelExtensions_AddOrUpdate(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__OpenConstructionSet_Models_Item)_item'></a>
`item` [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')  
The item to add or use to update the existing item.
  
