#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet](index#OpenConstructionSet 'OpenConstructionSet').[TryPatternExtensions](8+MvwvK7uGNIiBHKRIh29A 'OpenConstructionSet.TryPatternExtensions')
## TryPatternExtensions.TryReadHeader(IOcsService, string, Header) Method
Attempts to read the header of the provided file.  
```csharp
public static bool TryReadHeader(this OpenConstructionSet.IOcsService service, string path, out OpenConstructionSet.Models.Header header);
```
#### Parameters
<a name='OpenConstructionSet_TryPatternExtensions_TryReadHeader(OpenConstructionSet_IOcsService_string_OpenConstructionSet_Models_Header)_service'></a>
`service` [IOcsService](pMeR1KBG0zWkoR01rh3e5A 'OpenConstructionSet.IOcsService')  
The service to call the method on.
  
<a name='OpenConstructionSet_TryPatternExtensions_TryReadHeader(OpenConstructionSet_IOcsService_string_OpenConstructionSet_Models_Header)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The path of the mod file.
  
<a name='OpenConstructionSet_TryPatternExtensions_TryReadHeader(OpenConstructionSet_IOcsService_string_OpenConstructionSet_Models_Header)_header'></a>
`header` [Header](bjExWrZuBlRDCiIUljjMrA 'OpenConstructionSet.Models.Header')  
Will contain the read header if successful.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if header can be read.
