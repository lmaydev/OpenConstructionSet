#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## ModFile Class
Represents a mod file.  
Provides methods for reading and writing the various asociated files and data.  
```csharp
public class ModFile :
OpenConstructionSet.Mods.IModFile
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModFile  

Implements [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')  

| Constructors | |
| :--- | :--- |
| [ModFile(string)](ZSXC_RaqF6QK3jXp_ALQBw.md 'OpenConstructionSet.Mods.ModFile.ModFile(string)') | Creates a new [ModFile](EYQou2987Z4OauOJGKsGRw.md 'OpenConstructionSet.Mods.ModFile') instance from the provided path.<br/> |

| Properties | |
| :--- | :--- |
| [Filename](2XW54Y8oBG2OmaSb6yEM4Q.md 'OpenConstructionSet.Mods.ModFile.Filename') | The filename of the mod file.<br/>e.g. example.mod<br/> |
| [Name](kJ0rnXtOx1e9dlkPJr3dVg.md 'OpenConstructionSet.Mods.ModFile.Name') | The name of the mod file.<br/>e.g. example<br/> |
| [Path](JRJGNBQUV4zbLAe0k4RwfA.md 'OpenConstructionSet.Mods.ModFile.Path') | The path of the mod file.<br/>e.g. \path\to\the\mod\example.mod<br/> |

| Methods | |
| :--- | :--- |
| [ReadDataAsync(CancellationToken)](uT5hgG1JK1z0TOAj5yPAvw.md 'OpenConstructionSet.Mods.ModFile.ReadDataAsync(System.Threading.CancellationToken)') | Reads the data of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [ReadHeaderAsync(CancellationToken)](Fe6Jmch_1ZAAXsEIxdqyYQ.md 'OpenConstructionSet.Mods.ModFile.ReadHeaderAsync(System.Threading.CancellationToken)') | Reads the [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header') of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [ReadInfoAsync(CancellationToken)](DNODgOz6y4dGZOSA+oM7bw.md 'OpenConstructionSet.Mods.ModFile.ReadInfoAsync(System.Threading.CancellationToken)') | Reads the .info file of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [ToString()](+vcnXMREkMtIbzJQskQH4w.md 'OpenConstructionSet.Mods.ModFile.ToString()') | Returns a string that represents the current object. |
| [WriteDataAsync(ModFileData, CancellationToken)](hQhr21hPPb95e3WiOjxdKA.md 'OpenConstructionSet.Mods.ModFile.WriteDataAsync(OpenConstructionSet.Mods.ModFileData, System.Threading.CancellationToken)') | Writes the provided data to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [WriteHeaderAsync(Header, CancellationToken)](RiQ3O5ILiETlRbJ9KcYYVA.md 'OpenConstructionSet.Mods.ModFile.WriteHeaderAsync(OpenConstructionSet.Data.Header, System.Threading.CancellationToken)') | Writes the provided header to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [WriteInfoAsync(ModInfoData, CancellationToken)](uE6gtC7DjZzrY5Tp7IMnlA.md 'OpenConstructionSet.Mods.ModFile.WriteInfoAsync(OpenConstructionSet.Mods.ModInfoData, System.Threading.CancellationToken)') | Writes the provided info to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')'s .info file.<br/> |
