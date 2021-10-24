#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO](index.md#OpenConstructionSet_IO 'OpenConstructionSet.IO').[OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q.md 'OpenConstructionSet.IO.OcsIOHelper')
## OcsIOHelper.ReadMod(OcsReader) Method
Reads the full mod file referenced by the reader.  
```csharp
public static (OpenConstructionSet.Models.Header header,int lastId,System.Collections.Generic.List<OpenConstructionSet.Models.Item> items) ReadMod(this OpenConstructionSet.IO.OcsReader reader);
```
#### Parameters
<a name='OpenConstructionSet_IO_OcsIOHelper_ReadMod(OpenConstructionSet_IO_OcsReader)_reader'></a>
`reader` [OcsReader](T57tcFO5x0tbza6wZBV1Ww.md 'OpenConstructionSet.IO.OcsReader')  
Used to read the mod file.
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
The header, last id and items from the mod.
#### Exceptions
[System.IO.InvalidDataException](https://docs.microsoft.com/en-us/dotnet/api/System.IO.InvalidDataException 'System.IO.InvalidDataException')  
Not a mod file
