#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context')
## ModContext Class
An FCS like context that allows the loading of multiple mod's for editing.  
```csharp
public class ModContext :
OpenConstructionSet.Mods.Context.IModContext
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModContext  

Implements [IModContext](V6ll8xRvyNbd6Fd1yGQMHQ.md 'OpenConstructionSet.Mods.Context.IModContext')  

| Constructors | |
| :--- | :--- |
| [ModContext(Dictionary&lt;string,ModItem&gt;, IEnumerable&lt;ModItem&gt;, IInstallation, string, int, Header?, ModInfoData?)](WOV0VCiLJcXpFYsEbrTxxg.md 'OpenConstructionSet.Mods.Context.ModContext.ModContext(System.Collections.Generic.Dictionary&lt;string,OpenConstructionSet.Mods.ModItem&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Mods.ModItem&gt;, OpenConstructionSet.Installations.IInstallation, string, int, OpenConstructionSet.Data.Header?, OpenConstructionSet.Mods.ModInfoData?)') | Creates a new [ModContext](bg5IPPU_c0JbekfhoR9TnQ.md 'OpenConstructionSet.Mods.Context.ModContext') from the provided data.<br/> |

| Properties | |
| :--- | :--- |
| [Header](jeSoXakQTfxlQLDq0dqwWQ.md 'OpenConstructionSet.Mods.Context.ModContext.Header') | The header to use for this mod.<br/> |
| [Info](dSA2RNL3UYpp6vIciD41iw.md 'OpenConstructionSet.Mods.Context.ModContext.Info') | The optional data for the mod's .info file.<br/> |
| [Items](bTTL7qcKJo9H7En3AfEMBA.md 'OpenConstructionSet.Mods.Context.ModContext.Items') | Editable collection of items.<br/> |
| [LastId](MCyqWwrREuqjYXU6nVL9UA.md 'OpenConstructionSet.Mods.Context.ModContext.LastId') | The last ID used to generate a new [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') |
| [ModName](ajITchEv29OQ4Xdouq4pSw.md 'OpenConstructionSet.Mods.Context.ModContext.ModName') | The name of the mod to be saved to.<br/> |

| Methods | |
| :--- | :--- |
| [NewItem(ItemType, string)](u_pS3U198iPTX4e7tJZ8VA.md 'OpenConstructionSet.Mods.Context.ModContext.NewItem(OpenConstructionSet.Data.ItemType, string)') | Creates a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem').<br/>Generates the [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') and increases [LastId](SvWaRCPfhqM6p4mEpZAn4A.md 'OpenConstructionSet.Mods.Context.IModContext.LastId') value.<br/> |
| [SaveAsync()](2iS+56W4N26WmbRfiY9dbg.md 'OpenConstructionSet.Mods.Context.ModContext.SaveAsync()') | Saves to the Mods folder with using [ModName](8T9FmksiwGIwTdaxosRWrw.md 'OpenConstructionSet.Mods.Context.IModContext.ModName') as the name.<br/> |
| [SaveAsync(IModFolder, string)](Y5Zf10ym9FANZNHrTtt88w.md 'OpenConstructionSet.Mods.Context.ModContext.SaveAsync(OpenConstructionSet.Installations.IModFolder, string)') | Saves to the given [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') with the given name.<br/> |
| [SaveAsync(string)](9U5756tLkNjhZfHROPJmmA.md 'OpenConstructionSet.Mods.Context.ModContext.SaveAsync(string)') | Saves to the given full path.<br/>e.g. \path\to\mod\example.mod<br/> |
