#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.ReadHeader(IOcsIOService, string) Method
Attempts to read the header of the provided file.  
```csharp
public static OpenConstructionSet.Models.Header? ReadHeader(this OpenConstructionSet.IOcsIOService service, string file);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadHeader(OpenConstructionSet_IOcsIOService_string)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
Service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadHeader(OpenConstructionSet_IOcsIOService_string)_file'></a>
`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The file to read.
  
#### Returns
[Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')  
The file's header if readable; otherwise, `null`.