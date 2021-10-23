#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO](index#OpenConstructionSet_IO 'OpenConstructionSet.IO').[OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q 'OpenConstructionSet.IO.OcsIOHelper')
## OcsIOHelper.ReadSave(OcsReader) Method
Reads the save file referenced by the reader.  
```csharp
public static (int lastId,System.Collections.Generic.List<OpenConstructionSet.Models.Item> items) ReadSave(this OpenConstructionSet.IO.OcsReader reader);
```
#### Parameters
<a name='OpenConstructionSet_IO_OcsIOHelper_ReadSave(OpenConstructionSet_IO_OcsReader)_reader'></a>
`reader` [OcsReader](T57tcFO5x0tbza6wZBV1Ww 'OpenConstructionSet.IO.OcsReader')  
Used to read the save file.
  
#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
The last id and items from the save file.
#### Exceptions
[System.IO.InvalidDataException](https://docs.microsoft.com/en-us/dotnet/api/System.IO.InvalidDataException 'System.IO.InvalidDataException')  
Not a save file
