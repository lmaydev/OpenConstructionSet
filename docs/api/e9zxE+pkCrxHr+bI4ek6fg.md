#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO](index#OpenConstructionSet_IO 'OpenConstructionSet.IO').[OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q 'OpenConstructionSet.IO.OcsIOHelper')
## OcsIOHelper.ReadMod(OcsReader) Method
Reads the full mod file referenced by the reader.  
```csharp
public static (OpenConstructionSet.Models.Header header,int lastId,System.Collections.Generic.Dictionary<string,OpenConstructionSet.Models.Item> items) ReadMod(this OpenConstructionSet.IO.OcsReader reader);
```
#### Parameters
<a name='OpenConstructionSet_IO_OcsIOHelper_ReadMod(OpenConstructionSet_IO_OcsReader)_reader'></a>
`reader` [OcsReader](T57tcFO5x0tbza6wZBV1Ww 'OpenConstructionSet.IO.OcsReader')  
Used to read the mod file.
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[Header](bjExWrZuBlRDCiIUljjMrA 'OpenConstructionSet.Models.Header')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
The header, last id and items from the mod.
#### Exceptions
[System.IO.InvalidDataException](https://docs.microsoft.com/en-us/dotnet/api/System.IO.InvalidDataException 'System.IO.InvalidDataException')  
Not a mod file