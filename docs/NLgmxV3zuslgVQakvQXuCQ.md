#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[IOcsService](pMeR1KBG0zWkoR01rh3e5A.md 'OpenConstructionSet.IOcsService')
## IOcsService.ReadLoadOrder(string) Method
Attempts to read the load order file. This file is contained in the game's data folder.  
```csharp
string[]? ReadLoadOrder(string folder);
```
#### Parameters
<a name='OpenConstructionSet_IOcsService_ReadLoadOrder(string)_folder'></a>
`folder` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Data folder to find the file in.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The collection of mod names from the load order. If the file cannot be found `null` is returned.
