#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet](index#OpenConstructionSet 'OpenConstructionSet').[TryPatternExtensions](8+MvwvK7uGNIiBHKRIh29A 'OpenConstructionSet.TryPatternExtensions')
## TryPatternExtensions.TryReadLoadOrder(IOcsService, string, string[]) Method
Attempts to read the load order file. This file is contained in the game's data folder.  
```csharp
public static bool TryReadLoadOrder(this OpenConstructionSet.IOcsService service, string folder, out string[] enabledMods);
```
#### Parameters
<a name='OpenConstructionSet_TryPatternExtensions_TryReadLoadOrder(OpenConstructionSet_IOcsService_string_string__)_service'></a>
`service` [IOcsService](pMeR1KBG0zWkoR01rh3e5A 'OpenConstructionSet.IOcsService')  
The service to call the method on.
  
<a name='OpenConstructionSet_TryPatternExtensions_TryReadLoadOrder(OpenConstructionSet_IOcsService_string_string__)_folder'></a>
`folder` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Data folder to find the file in.
  
<a name='OpenConstructionSet_TryPatternExtensions_TryReadLoadOrder(OpenConstructionSet_IOcsService_string_string__)_enabledMods'></a>
`enabledMods` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
If successful will contain the collection of mod names from the load order.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the load order can be read.
