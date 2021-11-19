#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models')
## Item Class
Represents an item from a data file.  
```csharp
public sealed class Item :
System.IEquatable<OpenConstructionSet.Models.Item>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Item  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  

| Constructors | |
| :--- | :--- |
| [Item(DataItem, ItemChanges)](PRVpow4HYpR7fWrnmtAKzw.md 'OpenConstructionSet.Models.Item.Item(OpenConstructionSet.Models.DataItem, OpenConstructionSet.Models.ItemChanges)') | Create an `Item` from the given `DataItem`.<br/> |
| [Item(Item)](hyKr+mGNi_kH3vnkmS10Jw.md 'OpenConstructionSet.Models.Item.Item(OpenConstructionSet.Models.Item)') | Copy constructor.<br/> |
| [Item(ItemType, int, string, string, ItemChanges)](OIcCu0yup9Gm4Gt5P0IgXw.md 'OpenConstructionSet.Models.Item.Item(OpenConstructionSet.Models.ItemType, int, string, string, OpenConstructionSet.Models.ItemChanges)') | Represents an item from a data file.<br/> |
| [Item(ItemType, int, string, string, ItemChanges, Dictionary&lt;string,object&gt;, List&lt;ReferenceCategory&gt;, List&lt;Instance&gt;)](_5dAPo1srDN_iMylg0QIjg.md 'OpenConstructionSet.Models.Item.Item(OpenConstructionSet.Models.ItemType, int, string, string, OpenConstructionSet.Models.ItemChanges, System.Collections.Generic.Dictionary&lt;string,object&gt;, System.Collections.Generic.List&lt;OpenConstructionSet.Models.ReferenceCategory&gt;, System.Collections.Generic.List&lt;OpenConstructionSet.Models.Instance&gt;)') | Represents an item from a data file.<br/> |

| Methods | |
| :--- | :--- |
| [ApplyChanges(Item)](zDEySaLlE_yHiLc1+qE+eg.md 'OpenConstructionSet.Models.Item.ApplyChanges(OpenConstructionSet.Models.Item)') | Apply the changes from `item` to this `Item`.<br/> |
| [TryGetChanges(Item, Item, Item)](DyH1pkGpyNxyHOzgd4I74Q.md 'OpenConstructionSet.Models.Item.TryGetChanges(OpenConstructionSet.Models.Item, OpenConstructionSet.Models.Item, OpenConstructionSet.Models.Item)') | Attempts to get an `Item` representing the changes between this and the provided `baseItem`.<br/> |
