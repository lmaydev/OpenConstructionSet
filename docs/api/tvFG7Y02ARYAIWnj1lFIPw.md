#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Installations](index.md#OpenConstructionSet_Installations 'OpenConstructionSet.Installations')
## ModFolderType Enum
Represents the various types of mod folder.  
```csharp
public enum ModFolderType

```
#### Fields
<a name='OpenConstructionSet_Installations_ModFolderType_Content'></a>
`Content` 0  
Currently used for the Steam Workshop folder.  
Files are stored in a sub folder based on the Id of their .info file.  
e.g. [folder]/120595/example.mod  
  
<a name='OpenConstructionSet_Installations_ModFolderType_Data'></a>
`Data` 1  
The data folder of a game installation.  
Contains the base game files.  
Files are stored in the root  
e.g [folder]/example.mod  
  
<a name='OpenConstructionSet_Installations_ModFolderType_Mod'></a>
`Mod` 2  
The mods folder of a game installation.  
Files are stored in a sub folder based on their name.  
e.g. [folder]/example/example.mod  
  
