#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## DataFile Class
Representation of a data file.  
Provides methods for reading and writing to the file.  
```csharp
public class DataFile :
OpenConstructionSet.Data.IDataFile
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataFile  

Derived  
&#8627; [PlatoonFile](Lg7LZywU3qobnopUu_q81w.md 'OpenConstructionSet.Saves.PlatoonFile')  
&#8627; [ZoneFile](QvuJ8TdQtNzS74FSwSKivA.md 'OpenConstructionSet.Saves.ZoneFile')  

Implements [IDataFile](VZv2DiJZ12cg0pjmXrsJmg.md 'OpenConstructionSet.Data.IDataFile')  

| Constructors | |
| :--- | :--- |
| [DataFile(string)](lH0LB6xtckRcS1QJlyvvkQ.md 'OpenConstructionSet.Data.DataFile.DataFile(string)') | Creates a new [DataFile](2SNjQ1htR48x9zEOcQT0EQ.md 'OpenConstructionSet.Data.DataFile') from the given path.<br/> |

| Properties | |
| :--- | :--- |
| [Filename](fBhIu5MfQeqIjcGSVueGdg.md 'OpenConstructionSet.Data.DataFile.Filename') | The filename of the data file e.g. example.ext<br/> |
| [Name](HWZqVeQtvVKPPtHHKtC_IQ.md 'OpenConstructionSet.Data.DataFile.Name') | The name of the data file e.g. example<br/> |
| [Path](T34qLg3kIUQm3rsUvlrtUA.md 'OpenConstructionSet.Data.DataFile.Path') | The path of the data file e.g. \path\to\file\example.ext<br/> |

| Methods | |
| :--- | :--- |
| [ReadDataAsync(CancellationToken)](kWcl1yGGMU1ru7caH+Clpg.md 'OpenConstructionSet.Data.DataFile.ReadDataAsync(System.Threading.CancellationToken)') | Reads the data from the file.<br/> |
| [WriteDataAsync(DataFileData, CancellationToken)](b_gvVgJrFeJCzfJRQZdfCQ.md 'OpenConstructionSet.Data.DataFile.WriteDataAsync(OpenConstructionSet.Data.DataFileData, System.Threading.CancellationToken)') | Writes the provided data to the file.<br/> |
