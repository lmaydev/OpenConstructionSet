#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## IModFile Interface
Represents a mod file.  
Provides methods for reading and writing the various asociated files and data.  
```csharp
public interface IModFile
```

Derived  
&#8627; [ModFile](EYQou2987Z4OauOJGKsGRw.md 'OpenConstructionSet.Mods.ModFile')  

| Properties | |
| :--- | :--- |
| [Filename](Pk9CxhDxccpyZ79xEwV0gA.md 'OpenConstructionSet.Mods.IModFile.Filename') | The filename of the mod file.<br/>e.g. example.mod<br/> |
| [Name](60YJzanExAZJkuVVOMsxjg.md 'OpenConstructionSet.Mods.IModFile.Name') | The name of the mod file.<br/>e.g. example<br/> |
| [Path](KVxTACrtWjCUUjYkxh62xA.md 'OpenConstructionSet.Mods.IModFile.Path') | The path of the mod file.<br/>e.g. \path\to\the\mod\example.mod<br/> |

| Methods | |
| :--- | :--- |
| [ReadDataAsync(CancellationToken)](l2Kl440NXBXQoiOWSoKX7g.md 'OpenConstructionSet.Mods.IModFile.ReadDataAsync(System.Threading.CancellationToken)') | Reads the data of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [ReadHeaderAsync(CancellationToken)](LxK37Dnx5eFX5k3RA2AlIg.md 'OpenConstructionSet.Mods.IModFile.ReadHeaderAsync(System.Threading.CancellationToken)') | Reads the [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header') of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [ReadInfoAsync(CancellationToken)](2XppwQSwGVrbWCHkFfXrjA.md 'OpenConstructionSet.Mods.IModFile.ReadInfoAsync(System.Threading.CancellationToken)') | Reads the .info file of this [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [WriteDataAsync(ModFileData, CancellationToken)](W0D0QCc5px8erdD1TLhCKA.md 'OpenConstructionSet.Mods.IModFile.WriteDataAsync(OpenConstructionSet.Mods.ModFileData, System.Threading.CancellationToken)') | Writes the provided data to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [WriteHeaderAsync(Header, CancellationToken)](LcPfuQlJlu2FL+Bu6zzEXA.md 'OpenConstructionSet.Mods.IModFile.WriteHeaderAsync(OpenConstructionSet.Data.Header, System.Threading.CancellationToken)') | Writes the provided header to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile').<br/> |
| [WriteInfoAsync(ModInfoData, CancellationToken)](vyBpTt0dXCGDxyuFsu_Ydw.md 'OpenConstructionSet.Mods.IModFile.WriteInfoAsync(OpenConstructionSet.Mods.ModInfoData, System.Threading.CancellationToken)') | Writes the provided info to the [IModFile](IKbYBL+aXAnVnb4gGogjfQ.md 'OpenConstructionSet.Mods.IModFile')'s .info file.<br/> |
