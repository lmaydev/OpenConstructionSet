#### [OpenConstructionSet](index 'index')
### [OpenConstructionSet.Data](index#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## OcsDataContext Class
Multiple mod files can be loaded into a context as base or active items.  
Allows the editing and saving of the active mod.  
```csharp
public class OcsDataContext
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsDataContext  

| Constructors | |
| :--- | :--- |
| [OcsDataContext(Dictionary&lt;string,Item&gt;, Dictionary&lt;string,Item&gt;, string, int, Header?, ModInfo?)](alvlzdOdrEFYc5gmy3h73A 'OpenConstructionSet.Data.OcsDataContext.OcsDataContext(System.Collections.Generic.Dictionary&lt;string,OpenConstructionSet.Models.Item&gt;, System.Collections.Generic.Dictionary&lt;string,OpenConstructionSet.Models.Item&gt;, string, int, OpenConstructionSet.Models.Header?, OpenConstructionSet.Models.ModInfo?)') | Creates a new OcsDataContext instance.<br/> |

| Properties | |
| :--- | :--- |
| [Header](cs31abMtihCIylBnRlqk3A 'OpenConstructionSet.Data.OcsDataContext.Header') | The header that will be stored in the mod file.<br/> |
| [Info](NBzpGyjvoPfqxltNqFhJOw 'OpenConstructionSet.Data.OcsDataContext.Info') | The data for the mod's .info file.<br/> |
| [Items](dU5IXK7bgrpmJjMMQJ+XKg 'OpenConstructionSet.Data.OcsDataContext.Items') | Collection of active items.<br/> |
| [LastId](bFL6w8mc3tTFqEsaUqpyAg 'OpenConstructionSet.Data.OcsDataContext.LastId') | Tracks the last ID used for an Item.<br/> |
| [ModName](0fSkPqGxBNY_raN39NojBA 'OpenConstructionSet.Data.OcsDataContext.ModName') | The name of the mod.<br/> |

| Methods | |
| :--- | :--- |
| [NewItem(ItemType, string)](NpZCWvqg0jygU+a5Wh9rrw 'OpenConstructionSet.Data.OcsDataContext.NewItem(OpenConstructionSet.Models.ItemType, string)') | Generates a new ID and creates an item with it.<br/>LastId will be increased.<br/> |
| [Save(ModFolder)](wqTfqQq3m7rqK4jAfdpK7Q 'OpenConstructionSet.Data.OcsDataContext.Save(OpenConstructionSet.Models.ModFolder)') | Saves the active mod into the given folder.<br/> |
| [Save(string)](bkDY9n3GvNbVMIgSS99A9Q 'OpenConstructionSet.Data.OcsDataContext.Save(string)') | Saves the active mod to the given path.<br/> |
