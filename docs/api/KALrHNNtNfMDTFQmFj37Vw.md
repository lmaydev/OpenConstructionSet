#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations').[IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')
## IModFolder.GetModPath(string, uint) Method
Gets the full path of the provided mod name or filename.  
e.g. example.mod or example  
```csharp
string GetModPath(string modName, uint modId=0u);
```
#### Parameters
<a name='OpenConstructionSet_Installations_IModFolder_GetModPath(string_uint)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The mod's name or filename. e.g. example.mod or example
  
<a name='OpenConstructionSet_Installations_IModFolder_GetModPath(string_uint)_modId'></a>
`modId` [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')  
The Id from the mod's info file. This is only required for [Content](tvFG7Y02ARYAIWnj1lFIPw.md#OpenConstructionSet_Installations_ModFolderType_Content 'OpenConstructionSet.Installations.ModFolderType.Content') folders.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The full path of the provided mod.
