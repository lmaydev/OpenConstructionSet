#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations').[ModFolder](wm8mvflY+X70b3tSoQrLmA.md 'OpenConstructionSet.Installations.ModFolder')
## ModFolder.TryFind(string, uint, IModFile) Method
Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').  
```csharp
public bool TryFind(string modName, uint id, out OpenConstructionSet.Mods.IModFile file);
```
#### Parameters
<a name='OpenConstructionSet_Installations_ModFolder_TryFind(string_uint_OpenConstructionSet_Mods_IModFile)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Name of the mod to find e.g. example or example.mod
  
<a name='OpenConstructionSet_Installations_ModFolder_TryFind(string_uint_OpenConstructionSet_Mods_IModFile)_id'></a>
`id` [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')  
The ID from the mod's .info file. Only required for content folders.
  
<a name='OpenConstructionSet_Installations_ModFolder_TryFind(string_uint_OpenConstructionSet_Mods_IModFile)_file'></a>
`file` [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')  
Will contain the located [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile') if found.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the mod could be found; otherwise, `false`.

Implements [TryFind(string, uint, IModFile)](SMVPMJpmpT0YURSkwDec2A.md 'OpenConstructionSet.Installations.IModFolder.TryFind(string, uint, OpenConstructionSet.Mods.IModFile)')  
