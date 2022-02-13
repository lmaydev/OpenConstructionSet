#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[IInstallationService](1_dEB+amoW33pgCR_95scQ.md 'OpenConstructionSet.IInstallationService')
## IInstallationService.DiscoverAllInstallationsAsync() Method
Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns any [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s that are found.  
```csharp
System.Collections.Generic.IAsyncEnumerable<OpenConstructionSet.Installations.IInstallation> DiscoverAllInstallationsAsync();
```
#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')  
A collection of any [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s that were found.
