#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## InstallationService Class
Service used to locate [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s.  
```csharp
public class InstallationService :
OpenConstructionSet.IInstallationService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InstallationService  

Implements [IInstallationService](1_dEB+amoW33pgCR_95scQ.md 'OpenConstructionSet.IInstallationService')  

| Constructors | |
| :--- | :--- |
| [InstallationService()](w8jGyxEUNhtcKroYuZvlLA.md 'OpenConstructionSet.InstallationService.InstallationService()') | Creates a new [InstallationService](2UPErl_vhvyYlM7GMO5htA.md 'OpenConstructionSet.InstallationService') using the default [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s.<br/> |
| [InstallationService(IEnumerable&lt;IInstallationLocator&gt;)](DKM1tqynnsGVdmB4l5yTOw.md 'OpenConstructionSet.InstallationService.InstallationService(System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Installations.Locators.IInstallationLocator&gt;)') | Creates a new [InstallationService](2UPErl_vhvyYlM7GMO5htA.md 'OpenConstructionSet.InstallationService') using the provided [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s.<br/> |

| Properties | |
| :--- | :--- |
| [SupportedLocators](iCk2izGEFah2AloD2jh45w.md 'OpenConstructionSet.InstallationService.SupportedLocators') | Id of all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s.<br/> |

| Methods | |
| :--- | :--- |
| [DiscoverAllInstallationsAsync()](VPv1mA7WxodQ63wZ2i2wjQ.md 'OpenConstructionSet.InstallationService.DiscoverAllInstallationsAsync()') | Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns any [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation')s that are found.<br/> |
| [DiscoverInstallationAsync()](UIsKbhL326avlbJ6vIKohg.md 'OpenConstructionSet.InstallationService.DiscoverInstallationAsync()') | Runs all supported [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator')s and returns the first [IInstallation](+q+t_1kaSScZooYXO5QOWw.md 'OpenConstructionSet.Installations.IInstallation') that is found.<br/> |
| [DiscoverInstallationAsync(string)](BykB3PU1egFZQoAo1pb9lQ.md 'OpenConstructionSet.InstallationService.DiscoverInstallationAsync(string)') | Runs the [IInstallationLocator](U3F_sqRL+Af4wVxU9_Eqrw.md 'OpenConstructionSet.Installations.Locators.IInstallationLocator') with a matching Id and returns the result.<br/> |
