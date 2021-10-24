#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet').[OcsService](vk7pKCZDraxUCiJOEKS3Rg.md 'OpenConstructionSet.OcsService')
## OcsService.ReadLoadOrder(string) Method
Attempts to read the load order file. This file is contained in the game's data folder.  
```csharp
public string[]? ReadLoadOrder(string folder);
```
#### Parameters
<a name='OpenConstructionSet_OcsService_ReadLoadOrder(string)_folder'></a>
`folder` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Data folder to find the file in.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The collection of mod names from the load order. If the file cannot be found an empty array is returned.

Implements [ReadLoadOrder(string)](NLgmxV3zuslgVQakvQXuCQ.md 'OpenConstructionSet.IOcsService.ReadLoadOrder(string)')  
