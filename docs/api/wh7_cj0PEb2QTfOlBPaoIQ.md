#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations')
## IModFolder Interface
Represents a folder containing mods.  
```csharp
public interface IModFolder
```

Derived  
&#8627; [ModFolder](wm8mvflY+X70b3tSoQrLmA.md 'OpenConstructionSet.Installations.ModFolder')  

| Properties | |
| :--- | :--- |
| [Path](5sqOj8KBuZnekevk2REF7Q.md 'OpenConstructionSet.Installations.IModFolder.Path') | The [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')'s path.<br/> |
| [Type](6WRO5pzF7u9R54cxbj5BxQ.md 'OpenConstructionSet.Installations.IModFolder.Type') | The [ModFolderType](tvFG7Y02ARYAIWnj1lFIPw.md 'OpenConstructionSet.Installations.ModFolderType') for this [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |

| Methods | |
| :--- | :--- |
| [GetModPath(string, uint)](KALrHNNtNfMDTFQmFj37Vw.md 'OpenConstructionSet.Installations.IModFolder.GetModPath(string, uint)') | Gets the full path of the provided mod name or filename.<br/>e.g. example.mod or example<br/> |
| [GetMods()](vWW9vcwQg52_IJ8YTMdtvA.md 'OpenConstructionSet.Installations.IModFolder.GetMods()') | Search the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for mods.<br/> |
| [TryFind(string, IModFile)](Lys15ylxqogs5pWuAVjGOw.md 'OpenConstructionSet.Installations.IModFolder.TryFind(string, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |
| [TryFind(string, uint, IModFile)](SMVPMJpmpT0YURSkwDec2A.md 'OpenConstructionSet.Installations.IModFolder.TryFind(string, uint, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |
