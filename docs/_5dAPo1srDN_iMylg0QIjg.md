#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models').[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')
## Item.Item(ItemType, int, string, string, ItemChanges, Dictionary&lt;string,object&gt;, List&lt;ReferenceCategory&gt;, List&lt;Instance&gt;) Constructor
Represents an item from a data file.  
```csharp
public Item(OpenConstructionSet.Models.ItemType Type, int Id, string Name, string StringId, OpenConstructionSet.Models.ItemChanges Changes, System.Collections.Generic.Dictionary<string,object> Values, System.Collections.Generic.List<OpenConstructionSet.Models.ReferenceCategory> ReferenceCategories, System.Collections.Generic.List<OpenConstructionSet.Models.Instance> Instances);
```
#### Parameters
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Type'></a>
`Type` [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType')  
The type of the item.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Id'></a>
`Id` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Unique identifier for in game data.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Name'></a>
`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Name of the item.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_StringId'></a>
`StringId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Unique string identifier.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Changes'></a>
`Changes` [ItemChanges](_oC5WqPLP5mn+3ivU_9TVQ.md 'OpenConstructionSet.Models.ItemChanges')  
What changes were applied to this data item.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Values'></a>
`Values` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
A dictionary of stored values.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_ReferenceCategories'></a>
`ReferenceCategories` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ReferenceCategory](FGzdlKUriLoI15zgK9th4g.md 'OpenConstructionSet.Models.ReferenceCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A collection of categories that contain the item's references.
  
<a name='OpenConstructionSet_Models_Item_Item(OpenConstructionSet_Models_ItemType_int_string_string_OpenConstructionSet_Models_ItemChanges_System_Collections_Generic_Dictionary_string_object__System_Collections_Generic_List_OpenConstructionSet_Models_ReferenceCategory__System_Collections_Generic_List_OpenConstructionSet_Models_Instance_)_Instances'></a>
`Instances` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Instance](NhOPiCtebmQnk5Ll2Sv0og.md 'OpenConstructionSet.Models.Instance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A collection of instances.
  
