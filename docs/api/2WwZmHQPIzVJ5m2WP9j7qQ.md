#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO](index.md#OpenConstructionSet_IO 'OpenConstructionSet.IO').[OcsPathHelper](EL7fRrYo+340ITl9XyXeOQ.md 'OpenConstructionSet.IO.OcsPathHelper')
## OcsPathHelper.AddModExtension(string) Method
Adds .mod to a mod name if no extension is present.  
e.g. example becomes example.mod while example.data will be unchanged  
```csharp
internal static string AddModExtension(this string modName);
```
#### Parameters
<a name='OpenConstructionSet_IO_OcsPathHelper_AddModExtension(string)_modName'></a>
`modName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name, filename or path of a mod.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The given mod name with a .mod extension if there was no extension originally.  
Otherwise simply returns the given mod name.  
