#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO](index#OpenConstructionSet_IO 'OpenConstructionSet.IO').[OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q 'OpenConstructionSet.IO.OcsIOHelper')
## OcsIOHelper.GetModPath(ModFolder, string) Method
Returns the full path of a mod from its' name.  
If the mod has been discovered it's path will be used.  
If not the path will be created using the folder and mod.  
```csharp
public static string GetModPath(OpenConstructionSet.Models.ModFolder folder, string mod);
```
#### Parameters
<a name='OpenConstructionSet_IO_OcsIOHelper_GetModPath(OpenConstructionSet_Models_ModFolder_string)_folder'></a>
`folder` [ModFolder](0h0FW6YI9iSflrhSD7PySw 'OpenConstructionSet.Models.ModFolder')  
The mod folder.
  
<a name='OpenConstructionSet_IO_OcsIOHelper_GetModPath(OpenConstructionSet_Models_ModFolder_string)_mod'></a>
`mod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The file name of the mod. e.g. example.mod
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The full path of a mod file.
