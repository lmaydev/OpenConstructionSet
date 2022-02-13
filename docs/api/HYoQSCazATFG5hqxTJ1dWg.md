#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations').[ModFolder](wm8mvflY+X70b3tSoQrLmA.md 'OpenConstructionSet.Installations.ModFolder')
## ModFolder.TryFind(string, IModFile) Method
Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').  
```csharp
public bool TryFind(string modName, out OpenConstructionSet.Mods.IModFile file);
```
#### Parameters
<a name='OpenConstructionSet_Installations_ModFolder_TryFind(string_OpenConstructionSet_Mods_IModFile)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Name of the mod to find e.g. example or example.mod
  
<a name='OpenConstructionSet_Installations_ModFolder_TryFind(string_OpenConstructionSet_Mods_IModFile)_file'></a>
`file` [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')  
Will contain the located [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile') if found.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the mod could be found; otherwise, `false`.

Implements [TryFind(string, IModFile)](Lys15ylxqogs5pWuAVjGOw.md 'OpenConstructionSet.Installations.IModFolder.TryFind(string, OpenConstructionSet.Mods.IModFile)')  
