#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.TryReadInfo(IOcsIOService, string, ModInfo) Method
Attempts to read the specified mod info file.  
```csharp
public static bool TryReadInfo(this OpenConstructionSet.IOcsIOService service, string path, out OpenConstructionSet.Models.ModInfo info);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadInfo(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_ModInfo)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadInfo(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_ModInfo)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path of the mod info file.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadInfo(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_ModInfo)_info'></a>
`info` [ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo')  
Will contain a `ModInfo` if successful.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the mod info file can be read.
