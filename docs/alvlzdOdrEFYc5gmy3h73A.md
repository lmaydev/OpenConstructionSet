#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Data](index#OpenConstructionSet_Data 'OpenConstructionSet.Data').[OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext')
## OcsDataContext.OcsDataContext(Dictionary&lt;string,Item&gt;, Dictionary&lt;string,Item&gt;, string, int, Header?, ModInfo?) Constructor
Creates a new OcsDataContext instance.  
```csharp
public OcsDataContext(System.Collections.Generic.Dictionary<string,OpenConstructionSet.Models.Item> items, System.Collections.Generic.Dictionary<string,OpenConstructionSet.Models.Item> baseItems, string modName, int lastId, OpenConstructionSet.Models.Header? header=null, OpenConstructionSet.Models.ModInfo? info=null);
```
#### Parameters
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_items'></a>
`items` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
The active data for editing.
  
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_baseItems'></a>
`baseItems` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
The base data.
  
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the mod.
  
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_lastId'></a>
`lastId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The last used ID. This should be the largest from all the mods loaded.
  
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_header'></a>
`header` [Header](bjExWrZuBlRDCiIUljjMrA 'OpenConstructionSet.Models.Header')  
An optional header for the active mod.
  
<a name='OpenConstructionSet_Data_OcsDataContext_OcsDataContext(System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__System_Collections_Generic_Dictionary_string_OpenConstructionSet_Models_Item__string_int_OpenConstructionSet_Models_Header__OpenConstructionSet_Models_ModInfo_)_info'></a>
`info` [ModInfo](h0vCAhsmAC6iWOaLYw25cg 'OpenConstructionSet.Models.ModInfo')  
Optional values the mod's info file.
  
