#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsIOServiceExtensions Class
Collection of wrapper function for the IO service.  
Implemented as extension methods because they wrap a single method and this way they don't have to be added to the interface.  
```csharp
public static class OcsIOServiceExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsIOServiceExtensions  

| Methods | |
| :--- | :--- |
| [ReadDataFile(IOcsIOService, string)](VkFn1MLS9a96aXpb2Wfvtw.md 'OpenConstructionSet.OcsIOServiceExtensions.ReadDataFile(OpenConstructionSet.IOcsIOService, string)') | Attempts to read the specified data file.<br/> |
| [ReadHeader(IOcsIOService, string)](MduinmYDumshJRNmfYk9Rw.md 'OpenConstructionSet.OcsIOServiceExtensions.ReadHeader(OpenConstructionSet.IOcsIOService, string)') | Attempts to read the header of the provided file.<br/> |
| [ReadInfo(IOcsIOService, string)](Td9bz9qVYfPdSgIbJZuOhw.md 'OpenConstructionSet.OcsIOServiceExtensions.ReadInfo(OpenConstructionSet.IOcsIOService, string)') | Attempts to read the provided mod info file.<br/> |
| [TryReadDataFile(IOcsIOService, string, DataFile)](dV_gO__2Iy0KB0r41zpuvA.md 'OpenConstructionSet.OcsIOServiceExtensions.TryReadDataFile(OpenConstructionSet.IOcsIOService, string, OpenConstructionSet.Models.DataFile)') | Attempts to read the specified data file.<br/> |
| [TryReadEnabledMods(IOcsIOService, string, List&lt;string&gt;)](mYl+sILpryhoweVY_laBxw.md 'OpenConstructionSet.OcsIOServiceExtensions.TryReadEnabledMods(OpenConstructionSet.IOcsIOService, string, System.Collections.Generic.List&lt;string&gt;)') | Attempts to read the enabled mods and load order from file in the given directory. This should the be the game's data folder.<br/> |
| [TryReadHeader(IOcsIOService, string, Header)](m6obDSbAKABJKsVUenMklQ.md 'OpenConstructionSet.OcsIOServiceExtensions.TryReadHeader(OpenConstructionSet.IOcsIOService, string, OpenConstructionSet.Models.Header)') | Attempts to read the header of the provided file.<br/> |
| [TryReadInfo(IOcsIOService, string, ModInfo)](humpiIiUATLUk+Y47ZCeNQ.md 'OpenConstructionSet.OcsIOServiceExtensions.TryReadInfo(OpenConstructionSet.IOcsIOService, string, OpenConstructionSet.Models.ModInfo)') | Attempts to read the specified mod info file.<br/> |
| [Write(IOcsIOService, string, DataFile)](jgjkQQ1YLhJv7ZkAZE1dpw.md 'OpenConstructionSet.OcsIOServiceExtensions.Write(OpenConstructionSet.IOcsIOService, string, OpenConstructionSet.Models.DataFile)') | Write the `DataFile` to the specified file.<br/> |
| [Write(IOcsIOService, string, ModInfo)](z6ivbKp2u2gATKKy0PzXUg.md 'OpenConstructionSet.OcsIOServiceExtensions.Write(OpenConstructionSet.IOcsIOService, string, OpenConstructionSet.Models.ModInfo)') | Write the mod info file data to the specified file.<br/> |
