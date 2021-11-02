#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet](index.md#OpenConstructionSet 'OpenConstructionSet')
## IOcsIOService Interface
Service used to read and write game files.  
```csharp
public interface IOcsIOService
```

Derived  
&#8627; [OcsIOService](UgUMQOJatpjEs0nJNw+3_w.md 'OpenConstructionSet.OcsIOService')  

| Methods | |
| :--- | :--- |
| [ReadDataFile(OcsReader)](baJdehAKTzZEi_MB6cxUxw.md 'OpenConstructionSet.IOcsIOService.ReadDataFile(OpenConstructionSet.IO.OcsReader)') | Read save or mod file (Type 14 or 15)<br/> |
| [ReadEnabledMods(string)](Op_W1+e1t6gqIKweSVcrLQ.md 'OpenConstructionSet.IOcsIOService.ReadEnabledMods(string)') | Attempts to read the enabled mods and load order from the specified file.<br/> |
| [ReadHeader(OcsReader)](lq7Xr7bv99XCIkjaeVcekQ.md 'OpenConstructionSet.IOcsIOService.ReadHeader(OpenConstructionSet.IO.OcsReader)') | Read the header from the reader.<br/> |
| [ReadInfo(Stream)](kCsNBzPe0Oey9t7Al3Zzow.md 'OpenConstructionSet.IOcsIOService.ReadInfo(System.IO.Stream)') | Read info file data from the given stream.<br/> |
| [SaveEnabledMods(Installation)](XUd5vIYPxMr7bUZae_t0pg.md 'OpenConstructionSet.IOcsIOService.SaveEnabledMods(OpenConstructionSet.Models.Installation)') | Save the enabled mods and load order for this installation to file.<br/> |
| [Write(OcsWriter, DataFile)](mWs5rJaesLdImdCpJIlg9Q.md 'OpenConstructionSet.IOcsIOService.Write(OpenConstructionSet.IO.OcsWriter, OpenConstructionSet.Models.DataFile)') | Write the `DataFile` to the given writer.<br/> |
| [Write(string, IEnumerable&lt;string&gt;)](xGYwv_QWwjUEaUla4qqHVw.md 'OpenConstructionSet.IOcsIOService.Write(string, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Save a collection of mod names to the load order file. This file is contained in the game's data folder.<br/> |
| [Write(Stream, ModInfo)](H+dw18CWbclxr3q+fS0drg.md 'OpenConstructionSet.IOcsIOService.Write(System.IO.Stream, OpenConstructionSet.Models.ModInfo)') | Write the info data to the stream. <br/> |
