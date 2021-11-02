#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions')
## OcsIOServiceExtensions.TryReadEnabledMods(IOcsIOService, string, List&lt;string&gt;) Method
Attempts to read the enabled mods and load order from file in the given directory. This should the be the game's data folder.  
```csharp
public static bool TryReadEnabledMods(this OpenConstructionSet.IOcsIOService service, string folder, out System.Collections.Generic.List<string> enabledMods);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadEnabledMods(OpenConstructionSet_IOcsIOService_string_System_Collections_Generic_List_string_)_service'></a>
`service` [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  
The service to wrap.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadEnabledMods(OpenConstructionSet_IOcsIOService_string_System_Collections_Generic_List_string_)_folder'></a>
`folder` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Data folder to find the file in.
  
<a name='OpenConstructionSet_OcsIOServiceExtensions_TryReadEnabledMods(OpenConstructionSet_IOcsIOService_string_System_Collections_Generic_List_string_)_enabledMods'></a>
`enabledMods` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
If successful will contain the collection of mod names from the load order.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the load order can be read.
