#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## IDataFile Interface
Representation of a data file.  
Provides methods for reading and writing to the file.  
```csharp
public interface IDataFile
```

Derived  
&#8627; [DataFile](2SNjQ1htR48x9zEOcQT0EQ.md 'OpenConstructionSet.Data.DataFile')  
&#8627; [IPlatoonFile](FAIZt04bt6APcINqPxKNlA.md 'OpenConstructionSet.Saves.IPlatoonFile')  
&#8627; [IZoneFile](scW+_5cvCUTTTF2WAFvWuw.md 'OpenConstructionSet.Saves.IZoneFile')  
&#8627; [PlatoonFile](Lg7LZywU3qobnopUu_q81w.md 'OpenConstructionSet.Saves.PlatoonFile')  
&#8627; [ZoneFile](QvuJ8TdQtNzS74FSwSKivA.md 'OpenConstructionSet.Saves.ZoneFile')  

| Properties | |
| :--- | :--- |
| [Filename](jsNHvAzTbtl0ftWxO9QI9A.md 'OpenConstructionSet.Data.IDataFile.Filename') | The filename of the data file e.g. example.ext<br/> |
| [Name](vdv_K1W1RUMHBO4LBa5jSg.md 'OpenConstructionSet.Data.IDataFile.Name') | The name of the data file e.g. example<br/> |
| [Path](MgA2soYCx2OWcdjqY9k8Sw.md 'OpenConstructionSet.Data.IDataFile.Path') | The path of the data file e.g. \path\to\file\example.ext<br/> |

| Methods | |
| :--- | :--- |
| [ReadDataAsync(CancellationToken)](_+jABG9Dg232AeOuLRVr_Q.md 'OpenConstructionSet.Data.IDataFile.ReadDataAsync(System.Threading.CancellationToken)') | Reads the data from the file.<br/> |
| [WriteDataAsync(DataFileData, CancellationToken)](9Jf_z43vw4dxlR0+f9S_bg.md 'OpenConstructionSet.Data.IDataFile.WriteDataAsync(OpenConstructionSet.Data.DataFileData, System.Threading.CancellationToken)') | Writes the provided data to the file.<br/> |
