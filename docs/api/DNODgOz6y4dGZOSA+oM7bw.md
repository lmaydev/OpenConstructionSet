#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods').[ModFile](EYQou2987Z4OauOJGKsGRw.md 'OpenConstructionSet.Mods.ModFile')
## ModFile.ReadInfoAsync(CancellationToken) Method
Reads the .info file of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').  
```csharp
public virtual System.Threading.Tasks.Task<OpenConstructionSet.Mods.ModInfoData?> ReadInfoAsync(System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='OpenConstructionSet_Mods_ModFile_ReadInfoAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
Token used to cancel the operation.
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ModInfoData](ZdFSsCp5Yk427RM+q39Nmw.md 'OpenConstructionSet.Mods.ModInfoData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The data contained within the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')'s .info file.

Implements [ReadInfoAsync(CancellationToken)](2XppwQSwGVrbWCHkFfXrjA.md 'OpenConstructionSet.Mods.IModFile.ReadInfoAsync(System.Threading.CancellationToken)')  
