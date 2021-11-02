#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.TryReadHeader(IOcsIOService, string, Header) Method
Attempts to read the header of the provided file.  
```csharp
public static bool TryReadHeader(this OpenConstructionSet.IOcsIOService service, string path, out OpenConstructionSet.Models.Header header);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadHeader(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_Header)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadHeader(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_Header)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path of the mod file.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadHeader(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_Header)_header'></a>
`header` [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')  
Will contain the read header if successful.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if header can be read.
