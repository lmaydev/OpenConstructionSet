#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[InstallationService](2UPErl_vhvyYlM7GMO5htA.md 'OpenConstructionSet.InstallationService')
## InstallationService.DiscoverInstallationAsync(string) Method
Runs the [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator') with a matching Id and returns the result.  
```csharp
public System.Threading.Tasks.Task<OpenConstructionSet.Installations.IInstallation?> DiscoverInstallationAsync(string locatorId);
```
#### Parameters
<a name='OpenConstructionSet_InstallationService_DiscoverInstallationAsync(string)_locatorId'></a>
`locatorId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation') if found; otherwise, `null`

Implements [DiscoverInstallationAsync(string)](5YxRJbbiy7RO9fd1r+2hFA.md 'OpenConstructionSet.IInstallationService.DiscoverInstallationAsync(string)')  
