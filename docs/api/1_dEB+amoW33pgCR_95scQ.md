#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## IInstallationService Interface
Service used to locate [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s.  
```csharp
public interface IInstallationService
```

Derived  
&#8627; [InstallationService](2UPErl_vhvyYlM7GMO5htA.md 'OpenConstructionSet.InstallationService')  

| Properties | |
| :--- | :--- |
| [SupportedLocators](5SAW26z59inehV8M75uUOQ.md 'OpenConstructionSet.IInstallationService.SupportedLocators') | Id of all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverAllInstallationsAsync()](eh2CuM0XAWBQO+V_c0WZ3A.md 'OpenConstructionSet.IInstallationService.DiscoverAllInstallationsAsync()') | Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns any [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s that are found.<br/> |
| [DiscoverInstallationAsync()](Ww4n4Oc3DCopw_cqMJvVog.md 'OpenConstructionSet.IInstallationService.DiscoverInstallationAsync()') | Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns the first [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation') that is found.<br/> |
| [DiscoverInstallationAsync(string)](5YxRJbbiy7RO9fd1r+2hFA.md 'OpenConstructionSet.IInstallationService.DiscoverInstallationAsync(string)') | Runs the [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator') with a matching Id and returns the result.<br/> |
