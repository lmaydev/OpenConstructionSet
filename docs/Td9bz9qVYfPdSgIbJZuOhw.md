#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.ReadInfo(IOcsIOService, string) Method
Attempts to read the provided mod info file.  
```csharp
public static OpenConstructionSet.Models.ModInfo? ReadInfo(this OpenConstructionSet.IOcsIOService service, string file);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadInfo(OpenConstructionSet_IOcsIOService_string)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadInfo(OpenConstructionSet_IOcsIOService_string)_file'></a>
`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The file to read.
  
#### Returns
[ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo')  
A `ModInfo` read from the file if readable; otherwise, `null`
