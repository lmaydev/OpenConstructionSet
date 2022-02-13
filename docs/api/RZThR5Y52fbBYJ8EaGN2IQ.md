#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## ModItem Class
Represents an instance from the game's data.  
All data in the game is represented by these.  
```csharp
public class ModItem :
OpenConstructionSet.Data.IItem,
LMay.Collections.IKeyedItem<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModItem  

Implements [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem'), [LMay.Collections.IKeyedItem&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')  

| Constructors | |
| :--- | :--- |
| [ModItem(IItem)](5pv1P4no+vqi9LjJd_tz2g.md 'OpenConstructionSet.Mods.ModItem.ModItem(OpenConstructionSet.Data.IItem)') | Creates a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') from another.<br/> |
| [ModItem(ItemType, string, string)](4CnWFXzVfY5leMEBeR3RfA.md 'OpenConstructionSet.Mods.ModItem.ModItem(OpenConstructionSet.Data.ItemType, string, string)') | Creates a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') from the provided data.<br/> |
| [ModItem(ItemType, string, string, IDictionary&lt;string,object&gt;, IEnumerable&lt;IReferenceCategory&gt;, IEnumerable&lt;IInstance&gt;)](DrJHJGkVvGAw9ZZDOodhXw.md 'OpenConstructionSet.Mods.ModItem.ModItem(OpenConstructionSet.Data.ItemType, string, string, System.Collections.Generic.IDictionary&lt;string,object&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IReferenceCategory&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IInstance&gt;)') | Creates a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') from the provided data.<br/> |

| Properties | |
| :--- | :--- |
| [Instances](GYuV8tFrnZ8cQLyxM+41cA.md 'OpenConstructionSet.Mods.ModItem.Instances') | Collection of [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance') s stored by this [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem').<br/> |
| [Name](DjbfYFRXA0WIaH+ruTpOaw.md 'OpenConstructionSet.Mods.ModItem.Name') | The name of this item.<br/> |
| [ReferenceCategories](UJHOMJConmGsec5dd3q3Sw.md 'OpenConstructionSet.Mods.ModItem.ReferenceCategories') | Collection of [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') instances stored by this [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem').<br/> |
| [StringId](nk5QZL8R5CMF+WEGh6_dVw.md 'OpenConstructionSet.Mods.ModItem.StringId') | The unique string identifier for this item.<br/> |
| [Type](u3rk7dzkM7TX2IUR_miaNQ.md 'OpenConstructionSet.Mods.ModItem.Type') | The type of item this represents.<br/> |
| [Values](8cxKPCtiUl+blVtk7B2tzw.md 'OpenConstructionSet.Mods.ModItem.Values') | Dictionary of values stored by this [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem').<br/> |

| Methods | |
| :--- | :--- |
| [AsDeleted()](VpdhcxGtvzVSLTsBhDx5rQ.md 'OpenConstructionSet.Mods.ModItem.AsDeleted()') | Returns an [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') that represents this marked as deleted.<br/> |
| [DeepClone()](ErrmgjWE2ESpEgX+TV_9nw.md 'OpenConstructionSet.Mods.ModItem.DeepClone()') | Performs a deep clone of this object.<br/> |
| [IsDeleted()](U7wwmYERl3xd+r14FaBDEg.md 'OpenConstructionSet.Mods.ModItem.IsDeleted()') | Determines if this [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') is marked as deleted.<br/> |
| [TryGetChanges(ModItem, Item)](GCZWeibpwQWTH5ubBUKrfQ.md 'OpenConstructionSet.Mods.ModItem.TryGetChanges(OpenConstructionSet.Mods.ModItem, OpenConstructionSet.Data.Item)') | Attempts to get an [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') representing the changes between this and the provided `baseItem`.<br/> |
