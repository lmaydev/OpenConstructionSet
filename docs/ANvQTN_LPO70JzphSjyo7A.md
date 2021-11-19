#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models').[DataItem](NedciBI8UIBYqbpYqrEXSw.md 'OpenConstructionSet.Models.DataItem')
## DataItem.TryGetChanges(Item, Item) Method
Attempts to get an `Item` representing the changes between this and the provided `baseItem`.  
```csharp
public bool TryGetChanges(OpenConstructionSet.Models.Item baseItem, out OpenConstructionSet.Models.Item changes);
```
#### Parameters
<a name='OpenConstructionSet_Models_DataItem_TryGetChanges(OpenConstructionSet_Models_Item_OpenConstructionSet_Models_Item)_baseItem'></a>
`baseItem` [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')  
Base item to compare to.
  
<a name='OpenConstructionSet_Models_DataItem_TryGetChanges(OpenConstructionSet_Models_Item_OpenConstructionSet_Models_Item)_changes'></a>
`changes` [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')  
If successful will contain the changes.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if there are changes; otherwise, `false`.
