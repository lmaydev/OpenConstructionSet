#### [OpenConstructionSet](index.md 'index')
### Namespaces
<a name='OpenConstructionSet'></a>
## OpenConstructionSet Namespace

| Classes | |
| :--- | :--- |
| [CollectionExtensions](FWc82w3EK+Efojdw03oX_w.md 'OpenConstructionSet.CollectionExtensions') | A collection of extensions for collections.<br/> |
| [ModelExtensions](d4l5JwZnO8DdkML7qnh_1g.md 'OpenConstructionSet.ModelExtensions') | Collection of methods for working with models.<br/> |
| [OcsConstants](O2L+5TDEXLJlnEZi6p3X+A.md 'OpenConstructionSet.OcsConstants') | Useful constants for working with the OCS.<br/> |
| [OcsDataContextBuilder](U44ADOjq83qr6ihsRA01VQ.md 'OpenConstructionSet.OcsDataContextBuilder') | Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') instances.<br/> |
| [OcsService](vk7pKCZDraxUCiJOEKS3Rg.md 'OpenConstructionSet.OcsService') | The main service for the OpenConstructionSet.<br/>Provides discovery and some saving/loading functions.<br/> |
| [TryPatternExtensions](8+MvwvK7uGNIiBHKRIh29A.md 'OpenConstructionSet.TryPatternExtensions') | Provides Try/Out patterns to existing interface methods.<br/> |

| Interfaces | |
| :--- | :--- |
| [IOcsDataContextBuilder](r4RI8NnQPrFwlGRexUtVqQ.md 'OpenConstructionSet.IOcsDataContextBuilder') | Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') instances.<br/> |
| [IOcsService](pMeR1KBG0zWkoR01rh3e5A.md 'OpenConstructionSet.IOcsService') | The main service for the OpenConstructionSet.<br/>Provides discovery and some saving/loading functions.<br/> |
  
<a name='OpenConstructionSet_Collections'></a>
## OpenConstructionSet.Collections Namespace

| Classes | |
| :--- | :--- |
| [InstanceCollection](j8W5ea9+YYuv04AThMEs_w.md 'OpenConstructionSet.Collections.InstanceCollection') | A collection of [Instance](NhOPiCtebmQnk5Ll2Sv0og.md 'OpenConstructionSet.Models.Instance')s unique by their Id.<br/> |
| [OcsCollection&lt;T&gt;](CpJitxHTJ7jJqLOu30sQbg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;') | Custom collection that prevents items with duplicate identifiers being added.<br/> |
| [ReferenceCategoryCollection](Z_8mczU4ty2AYSnLk19kjA.md 'OpenConstructionSet.Collections.ReferenceCategoryCollection') | Collection of [ReferenceCategory](FGzdlKUriLoI15zgK9th4g.md 'OpenConstructionSet.Models.ReferenceCategory') objects unique by their Name.<br/> |
| [ReferenceCollection](A_iVrzvkVjBWCRYQ141Zbw.md 'OpenConstructionSet.Collections.ReferenceCollection') | A collection of [Reference](keNdBWwXoST05c_g6wF_4w.md 'OpenConstructionSet.Models.Reference')s unique by their TargetId.<br/> |
  
<a name='OpenConstructionSet_Data'></a>
## OpenConstructionSet.Data Namespace

| Classes | |
| :--- | :--- |
| [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') | Multiple mod files can be loaded into a context as base or active items.<br/>Allows the editing and saving of the active mod.<br/> |
  
<a name='OpenConstructionSet_IO'></a>
## OpenConstructionSet.IO Namespace

| Classes | |
| :--- | :--- |
| [LocatedFolders](jgv6_uiXfDVLa_l1InGCGA.md 'OpenConstructionSet.IO.LocatedFolders') | Represents the results of searching for a game folder.<br/> |
| [OcsIOHelper](JZTSUWDp1bIPbzqkTvZY3Q.md 'OpenConstructionSet.IO.OcsIOHelper') | A collection of helper functions for dealing with the game's files.<br/> |
| [OcsReader](T57tcFO5x0tbza6wZBV1Ww.md 'OpenConstructionSet.IO.OcsReader') | Reader for the game's data files.<br/>Can read from a `Stream` or a byte buffer.<br/> |
| [OcsWriter](ZpKxsyHEFPikx37jMDDXsg.md 'OpenConstructionSet.IO.OcsWriter') | Writer for the game's data files.<br/> |
  
<a name='OpenConstructionSet_IO_Discovery'></a>
## OpenConstructionSet.IO.Discovery Namespace

| Classes | |
| :--- | :--- |
| [GogFolderLocator](5SutPr2lrfLoH95lQlVPRg.md 'OpenConstructionSet.IO.Discovery.GogFolderLocator') | Gog implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ.md 'OpenConstructionSet.IO.Discovery.IInstallationLocator') |
| [LocalFolderLocator](rPXbOqKGJHUGKeNPKtAAmA.md 'OpenConstructionSet.IO.Discovery.LocalFolderLocator') | Implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ.md 'OpenConstructionSet.IO.Discovery.IInstallationLocator') that looks for the folders in the working directory.<br/> |
| [ModNameResolver](xvEgYqo1OTNhvugSHWg4lg.md 'OpenConstructionSet.IO.Discovery.ModNameResolver') | Used to resolve a mod name (e.g. example.mod) to it's full path.<br/> |
| [SteamFolderLocator](BDvQhQsErjN5ilWJbjNpng.md 'OpenConstructionSet.IO.Discovery.SteamFolderLocator') | Gog implementation of a [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ.md 'OpenConstructionSet.IO.Discovery.IInstallationLocator') |

| Interfaces | |
| :--- | :--- |
| [IInstallationLocator](bMvjGP8yI9R4AfcWyvP7gQ.md 'OpenConstructionSet.IO.Discovery.IInstallationLocator') | Used to locate game installations from various platforms.<br/> |
| [IModNameResolver](ocgulCoOZ5rxutpWQSp2oA.md 'OpenConstructionSet.IO.Discovery.IModNameResolver') | Used to resolve a mod name (e.g. example.mod) to it's full path.<br/> |
  
<a name='OpenConstructionSet_Models'></a>
## OpenConstructionSet.Models Namespace

| Classes | |
| :--- | :--- |
| [DataFile](q_8MggXJ9Yoajs1dvqB03g.md 'OpenConstructionSet.Models.DataFile') | Represents a game data file.<br/> |
| [FileValue](xqcMg7X3TDoX+y5NsSzu9Q.md 'OpenConstructionSet.Models.FileValue') | Represents a path value from a data file.<br/> |
| [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header') | Representation of a mod file's header.<br/> |
| [Installation](d9dvAYmZXntxn1p8iGWqPw.md 'OpenConstructionSet.Models.Installation') | POCO representing an installation of the game.<br/> |
| [Instance](NhOPiCtebmQnk5Ll2Sv0og.md 'OpenConstructionSet.Models.Instance') | Represents an instance from a game data file.<br/> |
| [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item') | Represent an Item from a game data file.<br/> |
| [ModFile](yIT20v2GHuAcdx4EIfntcw.md 'OpenConstructionSet.Models.ModFile') | Represents a mod file.<br/> |
| [ModFolder](0h0FW6YI9iSflrhSD7PySw.md 'OpenConstructionSet.Models.ModFolder') | Representation of a mod folder.<br/>Provides methods for discovery and working with the contained mods.<br/> |
| [ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo') | POCO class representing a mod's info file.<br/> |
| [Reference](keNdBWwXoST05c_g6wF_4w.md 'OpenConstructionSet.Models.Reference') | Represents a reference from a game data files.<br/> |
| [ReferenceCategory](FGzdlKUriLoI15zgK9th4g.md 'OpenConstructionSet.Models.ReferenceCategory') | A collection of references grouped by a category name.<br/> |
| [ReferenceValues](12EeLen8x83ZM11p+0cSKw.md 'OpenConstructionSet.Models.ReferenceValues') | Represents the values assigned to a [Reference](keNdBWwXoST05c_g6wF_4w.md 'OpenConstructionSet.Models.Reference') in the game data files.<br/> |
| [Save](lSeaf7mywqVjOzlI14k6Ow.md 'OpenConstructionSet.Models.Save') | Represents a single save directory structure.<br/> |
| [SaveFolder](V_zortZPS59vW0ZEiqO+Gg.md 'OpenConstructionSet.Models.SaveFolder') | Represents the game's save folder.<br/> |
| [Vector3](KCFzybM8YwCd4Tco51d3aw.md 'OpenConstructionSet.Models.Vector3') | Represents a position from the game data files.<br/> |
| [Vector4](zA17UDSwA7W6ghyYo5XyCQ.md 'OpenConstructionSet.Models.Vector4') | Represents a Rotation from the game data files.<br/> |

| Enums | |
| :--- | :--- |
| [FileType](TujeFsxyMe5rTsbAWARcfA.md 'OpenConstructionSet.Models.FileType') | Type identifier for data files.<br/> |
| [ItemChanges](_oC5WqPLP5mn+3ivU_9TVQ.md 'OpenConstructionSet.Models.ItemChanges') | Change types for items.<br/> |
| [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType') | Type identifier for Items.<br/> |
| [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ.md 'OpenConstructionSet.Models.ModLoadType') | Used to specifiy how a mod should be loaded into a  |
  
