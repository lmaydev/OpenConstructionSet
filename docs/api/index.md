#### [OpenConstructionSet](index 'index')
### Namespaces
<a name='OpenConstructionSet'></a>
## OpenConstructionSet Namespace

| Classes | |
| :--- | :--- |
| [CollectionExtensions](FWc82w3EK+Efojdw03oX_w 'OpenConstructionSet.CollectionExtensions') | A collection of extensions for collections.<br/> |
| [ModelExtensions](d4l5JwZnO8DdkML7qnh_1g 'OpenConstructionSet.ModelExtensions') | Collection of methods for working with models.<br/> |
| [OcsConstants](O2L+5TDEXLJlnEZi6p3X+A 'OpenConstructionSet.OcsConstants') | Useful constants for working with the OCS.<br/> |
| [OcsService](vk7pKCZDraxUCiJOEKS3Rg 'OpenConstructionSet.OcsService') | The main service for the OpenConstructionSet.<br/>Provides discovery and some saving/loading functions.<br/> |

| Interfaces | |
| :--- | :--- |
| [IOcsService](pMeR1KBG0zWkoR01rh3e5A 'OpenConstructionSet.IOcsService') | The main service for the OpenConstructionSet.<br/>Provides discovery and some saving/loading functions.<br/> |
  
<a name='OpenConstructionSet_Data'></a>
## OpenConstructionSet.Data Namespace

| Classes | |
| :--- | :--- |
| [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') | Multiple mod files can be loaded into a context as base or active items.<br/>Allows the editing and saving of the active mod.<br/> |
| [OcsDataContextBuilder](jaTbJrj9nKbQhW7+tZRZPg 'OpenConstructionSet.Data.OcsDataContextBuilder') | Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') instances.<br/> |

| Interfaces | |
| :--- | :--- |
| [IOcsDataContextBuilder](wggJ0NkCl5tSu595OCPJxA 'OpenConstructionSet.Data.IOcsDataContextBuilder') | Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q 'OpenConstructionSet.Data.OcsDataContext') instances.<br/> |
  
<a name='OpenConstructionSet_IO'></a>
## OpenConstructionSet.IO Namespace

| Classes | |
| :--- | :--- |
| [LocatedFolders](jgv6_uiXfDVLa_l1InGCGA 'OpenConstructionSet.IO.LocatedFolders') | Represents the results of searching for a game folder.<br/> |
| [OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q 'OpenConstructionSet.IO.OcsIOHelper') | A collection of helper functions for dealing with the game's files.<br/> |
| [OcsReader](T57tcFO5x0tbza6wZBV1Ww 'OpenConstructionSet.IO.OcsReader') | Reader for the game's data files.<br/>Can read from a `Stream` or a byte buffer.<br/> |
| [OcsWriter](ZpKxsyHEFPikx37jMDDXsg 'OpenConstructionSet.IO.OcsWriter') | Writer for the game's data files.<br/> |
  
<a name='OpenConstructionSet_IO_Discovery'></a>
## OpenConstructionSet.IO.Discovery Namespace

| Classes | |
| :--- | :--- |
| [GogFolderLocator](5SutPr2lrfLoH95lQlVPRg 'OpenConstructionSet.IO.Discovery.GogFolderLocator') | Gog implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator') |
| [LocalFolderLocator](rPXbOqKGJHUGKeNPKtAAmA 'OpenConstructionSet.IO.Discovery.LocalFolderLocator') | Implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator') that looks for the folders in the working directory.<br/> |
| [ModNameResolver](xvEgYqo1OTNhvugSHWg4lg 'OpenConstructionSet.IO.Discovery.ModNameResolver') | Used to resolve a mod name (e.g. example.mod) to it's full path.<br/> |
| [SteamFolderLocator](BDvQhQsErjN5ilWJbjNpng 'OpenConstructionSet.IO.Discovery.SteamFolderLocator') | Gog implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator') |

| Interfaces | |
| :--- | :--- |
| [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ 'OpenConstructionSet.IO.Discovery.IInstallationLocator') | Used to locate game installations from various platforms.<br/> |
| [IModNameResolver](ocgulCoOZ5rxutpWQSp2oA 'OpenConstructionSet.IO.Discovery.IModNameResolver') | Used to resolve a mod name (e.g. example.mod) to it's full path.<br/> |
  
<a name='OpenConstructionSet_Models'></a>
## OpenConstructionSet.Models Namespace

| Classes | |
| :--- | :--- |
| [DataFile](q_8MggXJ9Yoajs1dvqB03g 'OpenConstructionSet.Models.DataFile') | Represents a game data file.<br/> |
| [FileValue](xqcMg7X3TDoX+y5NsSzu9Q 'OpenConstructionSet.Models.FileValue') | Represents a path value from a data file.<br/> |
| [Header](bjExWrZuBlRDCiIUljjMrA 'OpenConstructionSet.Models.Header') | Representation of a mod file's header.<br/> |
| [Installation](d9dvAYmZXntxn1p8iGWqPw 'OpenConstructionSet.Models.Installation') | POCO representing an installation of the game.<br/> |
| [Instance](NhOPiCtebmQnk5Ll2Sv0og 'OpenConstructionSet.Models.Instance') | Represents an instance from a game data file.<br/> |
| [Item](Z9pYmp3jhG_PhNCQ0nlOeg 'OpenConstructionSet.Models.Item') | Represent an Item from a game data file.<br/> |
| [ModFile](yIT20v2GHuAcdx4EIfntcw 'OpenConstructionSet.Models.ModFile') | Represents a mod file.<br/> |
| [ModFolder](0h0FW6YI9iSflrhSD7PySw 'OpenConstructionSet.Models.ModFolder') | Representation of a mod folder.<br/>Provides methods for discovery and working with the contained mods.<br/> |
| [ModInfo](h0vCAhsmAC6iWOaLYw25cg 'OpenConstructionSet.Models.ModInfo') | POCO class representing a mod's info file.<br/> |
| [Reference](keNdBWwXoST05c_g6wF_4w 'OpenConstructionSet.Models.Reference') | Represents a reference from a game data files.<br/> |
| [ReferenceValues](12EeLen8x83ZM11p+0cSKw 'OpenConstructionSet.Models.ReferenceValues') | Represents the values assigned to a [Reference](keNdBWwXoST05c_g6wF_4w 'OpenConstructionSet.Models.Reference') in the game data files.<br/> |
| [Save](lSeaf7mywqVjOzlI14k6Ow 'OpenConstructionSet.Models.Save') | Represents a single save directory structure.<br/> |
| [SaveFolder](V_zortZPS59vW0ZEiqO+Gg 'OpenConstructionSet.Models.SaveFolder') | Represents the game's save folder.<br/> |
| [Vector3](KCFzybM8YwCd4Tco51d3aw 'OpenConstructionSet.Models.Vector3') | Represents a position from the game data files.<br/> |
| [Vector4](zA17UDSwA7W6ghyYo5XyCQ 'OpenConstructionSet.Models.Vector4') | Represents a Rotation from the game data files.<br/> |

| Enums | |
| :--- | :--- |
| [FileType](TujeFsxyMe5rTsbAWARcfA 'OpenConstructionSet.Models.FileType') | Type identifier for data files.<br/> |
| [ItemChanges](_oC5WqPLP5mn+3ivU_9TVQ 'OpenConstructionSet.Models.ItemChanges') | Change types for items.<br/> |
| [ItemType](QKunUA3okX9+HGcnTOur3g 'OpenConstructionSet.Models.ItemType') | Type identifier for Items.<br/> |
| [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ 'OpenConstructionSet.Models.ModLoadType') | Used to specifiy how a mod should be loaded into a  |
  
