#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods').[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')
## ModItem.TryGetChanges(ModItem, Item) Method
Attempts to get an [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') representing the changes between this and the provided `baseItem`.  
```csharp
public bool TryGetChanges(OpenConstructionSet.Mods.ModItem baseItem, out OpenConstructionSet.Data.Item changes);
```
#### Parameters
<a name='OpenConstructionSet_Mods_ModItem_TryGetChanges(OpenConstructionSet_Mods_ModItem_OpenConstructionSet_Data_Item)_baseItem'></a>
`baseItem` [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')  
Base item to compare to.
  
<a name='OpenConstructionSet_Mods_ModItem_TryGetChanges(OpenConstructionSet_Mods_ModItem_OpenConstructionSet_Data_Item)_changes'></a>
`changes` [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')  
If successful will contain the changes.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if there are changes; otherwise, `false`.
