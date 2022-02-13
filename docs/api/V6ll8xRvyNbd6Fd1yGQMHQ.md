#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context')
## IModContext Interface
An FCS like context that allows the loading of multiple mod's for editing.  
```csharp
public interface IModContext
```

Derived  
&#8627; [ModContext](bg5IPPU_c0JbekfhoR9TnQ.md 'OpenConstructionSet.Mods.Context.ModContext')  

| Properties | |
| :--- | :--- |
| [Header](9CX+frbD562yWs7oKD1DKA.md 'OpenConstructionSet.Mods.Context.IModContext.Header') | The header to use for this mod.<br/> |
| [Info](QHcQjOHfdyiawmzQgrq3ow.md 'OpenConstructionSet.Mods.Context.IModContext.Info') | The optional data for the mod's .info file.<br/> |
| [Items](WbCOXAmMe6rildrOWCGqDw.md 'OpenConstructionSet.Mods.Context.IModContext.Items') | Editable collection of items.<br/> |
| [LastId](SvWaRCPfhqM6p4mEpZAn4A.md 'OpenConstructionSet.Mods.Context.IModContext.LastId') | The last ID used to generate a new [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') |
| [ModName](8T9FmksiwGIwTdaxosRWrw.md 'OpenConstructionSet.Mods.Context.IModContext.ModName') | The name of the mod to be saved to.<br/> |

| Methods | |
| :--- | :--- |
| [NewItem(ItemType, string)](oASeKfq61fDJizF9I0gmfQ.md 'OpenConstructionSet.Mods.Context.IModContext.NewItem(OpenConstructionSet.Data.ItemType, string)') | Creates a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem').<br/>Generates the [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') and increases [LastId](SvWaRCPfhqM6p4mEpZAn4A.md 'OpenConstructionSet.Mods.Context.IModContext.LastId') value.<br/> |
| [SaveAsync()](QIk4hdz1x4a7KG9tlEAkRg.md 'OpenConstructionSet.Mods.Context.IModContext.SaveAsync()') | Saves to the Mods folder with using [ModName](8T9FmksiwGIwTdaxosRWrw.md 'OpenConstructionSet.Mods.Context.IModContext.ModName') as the name.<br/> |
| [SaveAsync(IModFolder, string)](b7ooyTKQ4YIPb0BQoyoGQg.md 'OpenConstructionSet.Mods.Context.IModContext.SaveAsync(OpenConstructionSet.Installations.IModFolder, string)') | Saves to the given [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') with the given name.<br/> |
| [SaveAsync(string)](+zpki8Owhj_qPn7fFl0F4A.md 'OpenConstructionSet.Mods.Context.IModContext.SaveAsync(string)') | Saves to the given full path.<br/>e.g. \path\to\mod\example.mod<br/> |
