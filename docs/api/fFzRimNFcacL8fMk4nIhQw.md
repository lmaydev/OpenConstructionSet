#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations').[IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')
## IInstallation.WriteEnabledModsAsync(IEnumerable&lt;string&gt;, CancellationToken) Method
Writes the provided list of mod filename's to the [EnabledModsFile](cHQDTkKqN02r9SvcmdOsGQ.md 'OpenConstructionSet.Installations.IInstallation.EnabledModsFile').  
e.g. example.mod  
```csharp
System.Threading.Tasks.Task WriteEnabledModsAsync(System.Collections.Generic.IEnumerable<string> enabledMods, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters
<a name='OpenConstructionSet_Installations_IInstallation_WriteEnabledModsAsync(System_Collections_Generic_IEnumerable_string__System_Threading_CancellationToken)_enabledMods'></a>
`enabledMods` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Collection of m od filenames e.g. example.mod
  
<a name='OpenConstructionSet_Installations_IInstallation_WriteEnabledModsAsync(System_Collections_Generic_IEnumerable_string__System_Threading_CancellationToken)_cancellationToken'></a>
`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')  
Token used to cancel the operation.
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
An awaitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').
