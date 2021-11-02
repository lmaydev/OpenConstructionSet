#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## OcsDataContext Class
Multiple mod files can be loaded into a context as base or active items.  
Allows the editing and saving of the active mod.  
```csharp
public class OcsDataContext
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDataContext  

| Constructors | |
| :--- | :--- |
| [OcsDataContext(IOcsIOService, Installation, Dictionary&lt;string,Item&gt;, Dictionary&lt;string,Item&gt;, string, int, Header?, ModInfo?)](AJdgI9OKnZe2P_T1Dzu3RA.md 'OpenConstructionSet.Data.OcsDataContext.OcsDataContext(OpenConstructionSet.IOcsIOService, OpenConstructionSet.Models.Installation, System.Collections.Generic.Dictionary&lt;string,OpenConstructionSet.Models.Item&gt;, System.Collections.Generic.Dictionary&lt;string,OpenConstructionSet.Models.Item&gt;, string, int, OpenConstructionSet.Models.Header?, OpenConstructionSet.Models.ModInfo?)') | Creates a new OcsDataContext instance.<br/> |

| Properties | |
| :--- | :--- |
| [Header](cs31abMtihCIylBnRlqk3A.md 'OpenConstructionSet.Data.OcsDataContext.Header') | The header that will be stored in the mod file.<br/> |
| [Info](NBzpGyjvoPfqxltNqFhJOw.md 'OpenConstructionSet.Data.OcsDataContext.Info') | The data for the mod's .info file.<br/> |
| [Items](dU5IXK7bgrpmJjMMQJ+XKg.md 'OpenConstructionSet.Data.OcsDataContext.Items') | Collection of active items.<br/> |
| [LastId](bFL6w8mc3tTFqEsaUqpyAg.md 'OpenConstructionSet.Data.OcsDataContext.LastId') | Tracks the last ID used for an Item.<br/> |
| [ModName](0fSkPqGxBNY_raN39NojBA.md 'OpenConstructionSet.Data.OcsDataContext.ModName') | The name of the mod.<br/> |

| Methods | |
| :--- | :--- |
| [NewItem(ItemType, string)](NpZCWvqg0jygU+a5Wh9rrw.md 'OpenConstructionSet.Data.OcsDataContext.NewItem(OpenConstructionSet.Models.ItemType, string)') | Generates a new ID and creates an item with it.<br/>LastId will be increased.<br/> |
| [Save()](9ZBtIoDqJRSA4pdeNHfJig.md 'OpenConstructionSet.Data.OcsDataContext.Save()') | Saves the active mod into the installation's mod folder.<br/> |
| [Save(ModFolder)](wqTfqQq3m7rqK4jAfdpK7Q.md 'OpenConstructionSet.Data.OcsDataContext.Save(OpenConstructionSet.Models.ModFolder)') | Saves the active mod into the given folder.<br/> |
| [Save(string)](bkDY9n3GvNbVMIgSS99A9Q.md 'OpenConstructionSet.Data.OcsDataContext.Save(string)') | Saves the active mod to the given path.<br/> |
