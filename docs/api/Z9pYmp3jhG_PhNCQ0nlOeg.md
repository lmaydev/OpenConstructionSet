#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Models](index#OpenConstructionSet_Models 'OpenConstructionSet.Models')
## Item Class
Represent an Item from a game data file.  
```csharp
public sealed class Item
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Item  

| Constructors | |
| :--- | :--- |
| [Item(ItemType, int, string, string, ItemChanges)](OIcCu0yup9Gm4Gt5P0IgXw 'OpenConstructionSet.Models.Item.Item(OpenConstructionSet.Models.ItemType, int, string, string, OpenConstructionSet.Models.ItemChanges)') | Initializes a new `Item`.<br/> |

| Properties | |
| :--- | :--- |
| [Changes](0WVaJZMl+Ki5iQHZ5zn8oQ 'OpenConstructionSet.Models.Item.Changes') | Represents the state of changes to this item.<br/> |
| [Id](q0TQPPiG0_yrymoT8Dkk_Q 'OpenConstructionSet.Models.Item.Id') | Still not sure what this does.<br/> |
| [Instances](VqMsRcp2Mh70nGQa0TkLug 'OpenConstructionSet.Models.Item.Instances') | The instances associated with the Item.<br/> |
| [Name](Cr8pxh8OLSz7Vpf4CtXAUg 'OpenConstructionSet.Models.Item.Name') | The name of this Item.<br/> |
| [ReferenceCategories](coy5li5UOIB6ZiknEP3dng 'OpenConstructionSet.Models.Item.ReferenceCategories') | The references associated with the Item.<br/> |
| [StringId](ksJeZX7hjDahBN8_LtGHTw 'OpenConstructionSet.Models.Item.StringId') | The unique id of this Item.<br/> |
| [Type](cRdkJJKG6zJ6ZO_zyGOXOQ 'OpenConstructionSet.Models.Item.Type') | The type of the Item.<br/> |
| [Values](9HCl4mhDRcgJrBaQbBchYw 'OpenConstructionSet.Models.Item.Values') | The values associated with the Item.<br/> |

| Methods | |
| :--- | :--- |
| [Duplicate()](E33Y9z5tIwvO7N2v4FdmAw 'OpenConstructionSet.Models.Item.Duplicate()') | Duplicate's the current Item.<br/> |
| [TryGetChanges(Item, Item)](TTPU_Id0IcDISN2xJx28CA 'OpenConstructionSet.Models.Item.TryGetChanges(OpenConstructionSet.Models.Item, OpenConstructionSet.Models.Item)') | Attempts to get an `Item` representing the changes between this and the provided `baseItem`.<br/> |
| [Update(Item)](GgF7QYPOwMzKHlWJa4PoNw 'OpenConstructionSet.Models.Item.Update(OpenConstructionSet.Models.Item)') | Apply the changes from `item` to this item.<br/> |
