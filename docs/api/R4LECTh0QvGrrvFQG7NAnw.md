#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations').[IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')
## IInstallation.ReadEnabledModsAsync(CancellationToken) Method
Reads the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile') to get the currently enabled mod's filenames and their load order.  
e.g. example.mod  
```csharp
System.Threading.Tasks.Task<string[]> ReadEnabledModsAsync(System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='OpenConstructionSet_Installations_IInstallation_ReadEnabledModsAsync(System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
Token used to cancel the operation.
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A collection of mod filenames for the currently enabled mods in load order.
