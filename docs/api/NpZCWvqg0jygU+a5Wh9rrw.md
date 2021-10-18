#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Data](index#OpenConstructionSet_Data 'OpenConstructionSet.Data').[OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext')
## OcsDataContext.NewItem(ItemType, string) Method
Generates a new ID and creates an item with it.  
LastId will be increased.  
```csharp
public OpenConstructionSet.Models.Item NewItem(OpenConstructionSet.Models.ItemType type, string name);
```
#### Parameters
<a name='OpenConstructionSet_Data_OcsDataContext_NewItem(OpenConstructionSet_Models_ItemType_string)_type'></a>
`type` [ItemType](QKunUA3okX9+HGcnTOur3g 'OpenConstructionSet.Models.ItemType')  
The type of item to create.
  
<a name='OpenConstructionSet_Data_OcsDataContext_NewItem(OpenConstructionSet_Models_ItemType_string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the new item.
  
#### Returns
[Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item')  
