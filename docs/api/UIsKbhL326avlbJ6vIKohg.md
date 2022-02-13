#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[InstallationService](2UPErl_vhvyYlM7GMO5htA.md 'OpenConstructionSet.InstallationService')
## InstallationService.DiscoverInstallationAsync() Method
Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns the first [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation') that is found.  
```csharp
public System.Threading.Tasks.Task<OpenConstructionSet.Installations.IInstallation?> DiscoverInstallationAsync();
```
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The first [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation') that was found; otherwise, `null`

Implements [DiscoverInstallationAsync()](Ww4n4Oc3DCopw_cqMJvVog.md 'OpenConstructionSet.IInstallationService.DiscoverInstallationAsync()')  
