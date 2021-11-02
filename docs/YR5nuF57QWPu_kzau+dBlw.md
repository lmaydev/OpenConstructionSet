#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsIOService](UgUMQOJatpjEs0nJNw+3_w.md 'OpenConstructionSet.OcsIOService')
## OcsIOService.ReadEnabledMods(string) Method
Attempts to read the enabled mods and load order from the specified file.  
```csharp
public System.Collections.Generic.List<string>? ReadEnabledMods(string file);
```
#### Parameters
<a name='OpenConstructionSet_OcsIOService_ReadEnabledMods(string)_file'></a>
`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The file containing the enabled mods and load order.
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A collection of enabled mod names in load order. If the file cannot be found `null` is returned.

Implements [ReadEnabledMods(string)](Op_W1+e1t6gqIKweSVcrLQ.md 'OpenConstructionSet.IOcsIOService.ReadEnabledMods(string)')  
