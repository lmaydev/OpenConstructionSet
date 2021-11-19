#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models').[DataFile](q_8MggXJ9Yoajs1dvqB03g.md 'OpenConstructionSet.Models.DataFile')
## DataFile.DataFile(DataFileType, Header?, int, List&lt;Item&gt;) Constructor
Represents a game data file.  
```csharp
public DataFile(OpenConstructionSet.Models.DataFileType Type, OpenConstructionSet.Models.Header? Header, int LastId, System.Collections.Generic.List<OpenConstructionSet.Models.Item> Items);
```
#### Parameters
<a name='OpenConstructionSet_Models_DataFile_DataFile(OpenConstructionSet_Models_DataFileType_OpenConstructionSet_Models_Header__int_System_Collections_Generic_List_OpenConstructionSet_Models_Item_)_Type'></a>
`Type` [DataFileType](+cY_9FxBbmCwckj8l7pVog.md 'OpenConstructionSet.Models.DataFileType')  
The value describing the type of the file. See [DataFileType](+cY_9FxBbmCwckj8l7pVog.md 'OpenConstructionSet.Models.DataFileType').
  
<a name='OpenConstructionSet_Models_DataFile_DataFile(OpenConstructionSet_Models_DataFileType_OpenConstructionSet_Models_Header__int_System_Collections_Generic_List_OpenConstructionSet_Models_Item_)_Header'></a>
`Header` [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')  
If the file is a mod (Type 16) this contains the meta data for it. This will be `null` for other data files.
  
<a name='OpenConstructionSet_Models_DataFile_DataFile(OpenConstructionSet_Models_DataFileType_OpenConstructionSet_Models_Header__int_System_Collections_Generic_List_OpenConstructionSet_Models_Item_)_LastId'></a>
`LastId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The last id number used when creating new items.
  
<a name='OpenConstructionSet_Models_DataFile_DataFile(OpenConstructionSet_Models_DataFileType_OpenConstructionSet_Models_Header__int_System_Collections_Generic_List_OpenConstructionSet_Models_Item_)_Items'></a>
`Items` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
Collection of data items contained with in the file. These represent all entities in kenshi.
  
