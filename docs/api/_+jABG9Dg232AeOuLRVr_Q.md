#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data').[IDataFile](VZv2DiJZ12cg0pjmXrsJmg.md 'OpenConstructionSet.Data.IDataFile')
## IDataFile.ReadDataAsync(CancellationToken) Method
Reads the data from the file.  
```csharp
System.Threading.Tasks.Task<OpenConstructionSet.Data.DataFileData> ReadDataAsync(System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='OpenConstructionSet_Data_IDataFile_ReadDataAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
Token used to cancel the operation.
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[DataFileData](OOJzQcvtRG1VtShZsI0XKg.md 'OpenConstructionSet.Data.DataFileData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The data stored in the file.
