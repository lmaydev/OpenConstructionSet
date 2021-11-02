#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## OcsIOService Class
Service used to read and write game files.  
```csharp
public class OcsIOService :
OpenConstructionSet.IOcsIOService
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsIOService  

Implements [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService')  

| Properties | |
| :--- | :--- |
| [Default](32cK2rBWJ41TWLPD+paHfg.md 'OpenConstructionSet.OcsIOService.Default') | Lazy initiated singleton for when DI is not being used<br/> |

| Methods | |
| :--- | :--- |
| [ReadDataFile(OcsReader)](XWEAktFFfC1nSYA5pdT+yg.md 'OpenConstructionSet.OcsIOService.ReadDataFile(OpenConstructionSet.IO.OcsReader)') | Read save or mod file (Type 14 or 15)<br/> |
| [ReadEnabledMods(string)](YR5nuF57QWPu_kzau+dBlw.md 'OpenConstructionSet.OcsIOService.ReadEnabledMods(string)') | Attempts to read the enabled mods and load order from the specified file.<br/> |
| [ReadHeader(OcsReader)](1OMwCoUp9L+8Xhe5Ks8nyQ.md 'OpenConstructionSet.OcsIOService.ReadHeader(OpenConstructionSet.IO.OcsReader)') | Read the header from the reader.<br/> |
| [ReadInfo(Stream)](3rXRuxU06nuM6vyOnFigHQ.md 'OpenConstructionSet.OcsIOService.ReadInfo(System.IO.Stream)') | Read info file data from the given stream.<br/> |
| [SaveEnabledMods(Installation)](MQtQDEWcb8ifTOQ9TgKk5w.md 'OpenConstructionSet.OcsIOService.SaveEnabledMods(OpenConstructionSet.Models.Installation)') | Save the enabled mods and load order for this installation to file.<br/> |
| [Write(OcsWriter, DataFile)](GChI3B+qTANE+_RWqs47_g.md 'OpenConstructionSet.OcsIOService.Write(OpenConstructionSet.IO.OcsWriter, OpenConstructionSet.Models.DataFile)') | Write the `DataFile` to the given writer.<br/> |
| [Write(string, IEnumerable&lt;string&gt;)](4W5oEAfO2nQX4WpLSg7QCQ.md 'OpenConstructionSet.OcsIOService.Write(string, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Save a collection of mod names to the load order file. This file is contained in the game's data folder.<br/> |
| [Write(Stream, ModInfo)](NSivAFkwySqKe6UUtZcdRw.md 'OpenConstructionSet.OcsIOService.Write(System.IO.Stream, OpenConstructionSet.Models.ModInfo)') | Write the info data to the stream. <br/> |
