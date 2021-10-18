#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.IO](index#OpenConstructionSet_IO 'OpenConstructionSet.IO')
## OcsIOHelper Class
A collection of helper functions for dealing with the game's files.  
```csharp
public static class OcsIOHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsIOHelper  

| Methods | |
| :--- | :--- |
| [CorrectModFolder(ModFile)](45ns+Q9U8jvNplJKxZEB8Q 'OpenConstructionSet.IO.OcsIOHelper.CorrectModFolder(OpenConstructionSet.Models.ModFile)') | Determines if the mod is in a standard folder structure. <br/> |
| [GetInfoPath(string)](uI2pxX0pLYXufElLQ0cW6A 'OpenConstructionSet.IO.OcsIOHelper.GetInfoPath(string)') | Gets the path of the info file for the given mod file.<br/> |
| [GetModPath(ModFolder, string)](4uitjlKofApGjjoUerPTdw 'OpenConstructionSet.IO.OcsIOHelper.GetModPath(OpenConstructionSet.Models.ModFolder, string)') | Returns the full path of a mod from its' name.<br/>If the mod has been discovered it's path will be used.<br/>If not the path will be created using the folder and mod.<br/> |
| [GetModPath(string, string)](f+sS4VijUZm2kWsQBzWMow 'OpenConstructionSet.IO.OcsIOHelper.GetModPath(string, string)') | Get the full path for the named mod in the given folder.<br/> |
| [ReadHeader(OcsReader)](TQkzQ3fXBIvcySPJLlnEXw 'OpenConstructionSet.IO.OcsIOHelper.ReadHeader(OpenConstructionSet.IO.OcsReader)') | Attempts to read the header of the given mod file.<br/> |
| [ReadInfo(Stream)](_Y0wDj1uoe356+GxXVrTTA 'OpenConstructionSet.IO.OcsIOHelper.ReadInfo(System.IO.Stream)') | Read the mod info from the given stream.<br/> |
| [ReadMod(OcsReader)](e9zxE+pkCrxHr+bI4ek6fg 'OpenConstructionSet.IO.OcsIOHelper.ReadMod(OpenConstructionSet.IO.OcsReader)') | Reads the full mod file referenced by the reader.<br/> |
| [ReadSave(OcsReader)](xyuwoD6FaCz2CpyEXtg4xg 'OpenConstructionSet.IO.OcsIOHelper.ReadSave(OpenConstructionSet.IO.OcsReader)') | Reads the save file referenced by the reader.<br/> |
| [WriteInfo(ModInfo, Stream)](F2aMU9oHubnNrj9q5GSd_A 'OpenConstructionSet.IO.OcsIOHelper.WriteInfo(OpenConstructionSet.Models.ModInfo, System.IO.Stream)') | Write the mod info to the stream.<br/> |
| [WriteMod(OcsWriter, Header?, int, IEnumerable&lt;Item&gt;)](RR6JNR32d9+MQM4+7HPODg 'OpenConstructionSet.IO.OcsIOHelper.WriteMod(OpenConstructionSet.IO.OcsWriter, OpenConstructionSet.Models.Header?, int, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.Item&gt;)') | Write the mod to the given writer.<br/> |
| [WriteSave(OcsWriter, int, IEnumerable&lt;Item&gt;)](IHSGoidplaYFCwT020xPoQ 'OpenConstructionSet.IO.OcsIOHelper.WriteSave(OpenConstructionSet.IO.OcsWriter, int, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Models.Item&gt;)') | Write the save file to the given writer.<br/> |
