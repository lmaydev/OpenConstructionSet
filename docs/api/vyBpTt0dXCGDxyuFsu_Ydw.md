#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods').[IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')
## IModFile.WriteInfoAsync(ModInfoData, CancellationToken) Method
Writes the provided info to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')'s .info file.  
```csharp
System.Threading.Tasks.Task WriteInfoAsync(OpenConstructionSet.Mods.ModInfoData info, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='OpenConstructionSet_Mods_IModFile_WriteInfoAsync(OpenConstructionSet_Mods_ModInfoData_System_Threading_CancellationToken)_info'></a>
`info` [ModInfoData](ZdFSsCp5Yk427RM+q39Nmw.md 'OpenConstructionSet.Mods.ModInfoData')  
The [ModInfoData](ZdFSsCp5Yk427RM+q39Nmw.md 'OpenConstructionSet.Mods.ModInfoData') to write to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').
  
<a name='OpenConstructionSet_Mods_IModFile_WriteInfoAsync(OpenConstructionSet_Mods_ModInfoData_System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
Token used to cancel the operation.
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
An awaitable `Task`.
