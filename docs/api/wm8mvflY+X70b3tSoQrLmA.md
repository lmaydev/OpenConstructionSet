#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations')
## ModFolder Class
Represents a folder containing mods.  
```csharp
public class ModFolder :
OpenConstructionSet.Installations.IModFolder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModFolder  

Implements [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')  

| Constructors | |
| :--- | :--- |
| [ModFolder(string, ModFolderType)](f_vGCXlNIvCxnFfvCpB5BA.md 'OpenConstructionSet.Installations.ModFolder.ModFolder(string, OpenConstructionSet.Installations.ModFolderType)') | Creates a new [ModFolder](wm8mvflY+X70b3tSoQrLmA.md 'OpenConstructionSet.Installations.ModFolder') instance from the provided values.<br/> |

| Properties | |
| :--- | :--- |
| [Path](oJrVk3tyoz9MYsNXWGdlkw.md 'OpenConstructionSet.Installations.ModFolder.Path') | The [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder')'s path.<br/> |
| [Type](V92U0hOiN2vMqOoMAgHItw.md 'OpenConstructionSet.Installations.ModFolder.Type') | The [ModFolderType](tvFG7Y02ARYAIWnj1lFIPw.md 'OpenConstructionSet.Installations.ModFolderType') for this [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |

| Methods | |
| :--- | :--- |
| [GetModPath(string, uint)](vqZLq8qwNVrHXY3c88VL0A.md 'OpenConstructionSet.Installations.ModFolder.GetModPath(string, uint)') | Gets the full path of the provided mod name or filename.<br/>e.g. example.mod or example<br/> |
| [GetMods()](a1eq02_dArNOaJnaEXz3wg.md 'OpenConstructionSet.Installations.ModFolder.GetMods()') | Search the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder') for mods.<br/> |
| [ToString()](au0uCn8hg1u5RwfEaJgzBA.md 'OpenConstructionSet.Installations.ModFolder.ToString()') | Returns a string that represents the current object. |
| [TryFind(string, IModFile)](HYoQSCazATFG5hqxTJ1dWg.md 'OpenConstructionSet.Installations.ModFolder.TryFind(string, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |
| [TryFind(string, uint, IModFile)](nSQTJ8loF8+TEhgTyw4F6g.md 'OpenConstructionSet.Installations.ModFolder.TryFind(string, uint, OpenConstructionSet.Mods.IModFile)') | Attempts to find the named mod in the [IModFolder](wh7_cj0PEb2QTfOlBPaoIQ.md 'OpenConstructionSet.Installations.IModFolder').<br/> |
