#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models')
## DataItem Class
Editable representation of a item from a data file.  
```csharp
public class DataItem :
OpenConstructionSet.Models.IDataModel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataItem  

Implements [IDataModel](zkoogszxgZdDGzPBOOAcpg.md 'OpenConstructionSet.Models.IDataModel')  

| Constructors | |
| :--- | :--- |
| [DataItem(Item)](KEIVi7sIOTSlbpDv72TsJQ.md 'OpenConstructionSet.Models.DataItem.DataItem(OpenConstructionSet.Models.Item)') | Creates a new `DataItem` from the provided `Item`.<br/> |
| [DataItem(ItemType, int, string, string)](DpkFt2wyLoi81TYxniuatg.md 'OpenConstructionSet.Models.DataItem.DataItem(OpenConstructionSet.Models.ItemType, int, string, string)') | Creates a new `DataItem` from the given values.<br/> |
| [DataItem(ItemType, int, string, string, IDictionary&lt;string,object&gt;, IEnumerable&lt;DataReferenceCategory&gt;, IEnumerable&lt;DataInstance&gt;)](UkqAXEIpulj4N9cwsi1ebg.md 'OpenConstructionSet.Models.DataItem.DataItem(OpenConstructionSet.Models.ItemType, int, string, string, System.Collections.Generic.IDictionary&lt;string,object&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.DataReferenceCategory&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.DataInstance&gt;)') | Creates a new `DataItem` from the given values.<br/> |

| Properties | |
| :--- | :--- |
| [Id](nXTY4fAwjG+rUeYadLzFpg.md 'OpenConstructionSet.Models.DataItem.Id') | Unique identifier for in game data.<br/> |
| [Instances](TZTSZ4t5zZYMP+6aEAzeTQ.md 'OpenConstructionSet.Models.DataItem.Instances') | A collection of instances.<br/> |
| [Key](Kf14al_rLuuDKpdFk1IzPg.md 'OpenConstructionSet.Models.DataItem.Key') | Unique identifier.<br/> |
| [Name](OE6vZ1R+54euE_56qqRMNQ.md 'OpenConstructionSet.Models.DataItem.Name') | Name of the item.<br/> |
| [ReferenceCategories](IQf9tGMoON9eysVqyVvpng.md 'OpenConstructionSet.Models.DataItem.ReferenceCategories') | A collection of categories that contain the item's references.<br/> |
| [StringId](cg_8N8c7jQGgZyonabjA5g.md 'OpenConstructionSet.Models.DataItem.StringId') | Unique string identifier.<br/> |
| [Type](YTi1oCpkNCAJcW2oCkSjSQ.md 'OpenConstructionSet.Models.DataItem.Type') | The type of the item.<br/> |
| [Values](BPmM_VPsJChuqhOR4uwAUw.md 'OpenConstructionSet.Models.DataItem.Values') | A dictionary of stored values.<br/> |

| Methods | |
| :--- | :--- |
| [ApplyChanges(Item)](DxMGKz1E5GQZnsEPChxKmA.md 'OpenConstructionSet.Models.DataItem.ApplyChanges(OpenConstructionSet.Models.Item)') | Apply the changes from `item` to this `Item`.<br/> |
| [TryGetChanges(Item, Item)](ANvQTN_LPO70JzphSjyo7A.md 'OpenConstructionSet.Models.DataItem.TryGetChanges(OpenConstructionSet.Models.Item, OpenConstructionSet.Models.Item)') | Attempts to get an `Item` representing the changes between this and the provided `baseItem`.<br/> |
