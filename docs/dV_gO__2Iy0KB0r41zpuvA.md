#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.TryReadDataFile(IOcsIOService, string, DataFile) Method
Attempts to read the specified data file.  
```csharp
public static bool TryReadDataFile(this OpenConstructionSet.IOcsIOService service, string path, out OpenConstructionSet.Models.DataFile data);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadDataFile(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_DataFile)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadDataFile(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_DataFile)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path of the data file.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadDataFile(OpenConstructionSet_IOcsIOService_string_OpenConstructionSet_Models_DataFile)_data'></a>
`data` [DataFile](q_8MggXJ9Yoajs1dvqB03g.md 'OpenConstructionSet.Models.DataFile')  
Will contain a `DataFile` read from the file if successful.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the data file can be read.
