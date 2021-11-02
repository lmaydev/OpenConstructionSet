#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.ReadDataFile(IOcsIOService, string) Method
Attempts to read the specified data file.  
```csharp
public static OpenConstructionSet.Models.DataFile? ReadDataFile(this OpenConstructionSet.IOcsIOService service, string file);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadDataFile(OpenConstructionSet_IOcsIOService_string)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_ReadDataFile(OpenConstructionSet_IOcsIOService_string)_file'></a>
`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The file to read.
  
#### Returns
[DataFile](q_8MggXJ9Yoajs1dvqB03g.md 'OpenConstructionSet.Models.DataFile')  
A `DataFile` read from the file if readable; otherwise; `null`.
