#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## DataFileData Class
Represents the data of a game data file.  
```csharp
public class DataFileData
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataFileData  

| Constructors | |
| :--- | :--- |
| [DataFileData(DataFileType, Header?, int, IEnumerable&lt;Item&gt;)](t3qBphRgqmKTe_DLy57XEQ.md 'OpenConstructionSet.Data.DataFileData.DataFileData(OpenConstructionSet.Data.DataFileType, OpenConstructionSet.Data.Header?, int, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.Item&gt;)') | Creates a new [DataFileData](OOJzQcvtRG1VtShZsI0XKg.md 'OpenConstructionSet.Data.DataFileData').<br/> |

| Properties | |
| :--- | :--- |
| [Header](jdAjOghP8vq8V+kUg4yyxg.md 'OpenConstructionSet.Data.DataFileData.Header') | The [Header](jdAjOghP8vq8V+kUg4yyxg.md 'OpenConstructionSet.Data.DataFileData.Header') if it is a [Mod](0ojV5yrqYlM2+XN8BqwIvw.md#OpenConstructionSet_Data_DataFileType_Mod 'OpenConstructionSet.Data.DataFileType.Mod') file.<br/>`null` for other data files<br/> |
| [Items](9K3GiU2u1uilCYgESMTlYA.md 'OpenConstructionSet.Data.DataFileData.Items') | Collection of [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')s contained with in the file. These represent all entities in kenshi.<br/> |
| [LastId](A0iHrvUT5H5SNZzSbXJTNQ.md 'OpenConstructionSet.Data.DataFileData.LastId') | The last ID number used when creating new items.<br/> |
| [Type](VrmLK2kIsb+BGSe9IVZW6g.md 'OpenConstructionSet.Data.DataFileData.Type') | The [DataFileType](0ojV5yrqYlM2+XN8BqwIvw.md 'OpenConstructionSet.Data.DataFileType') of the data file.<br/> |
