#### [OpenConstructionSet](index.md 'index')
### Namespaces
<a name='OpenConstructionSet'></a>
## OpenConstructionSet Namespace

| Classes | |
| :--- | :--- |
| [CollectionExtensions](FWc82w3EK+Efojdw03oX_w.md 'OpenConstructionSet.CollectionExtensions') | A collection of extensions for collections.<br/> |
| [ModelExtensions](d4l5JwZnO8DdkML7qnh_1g.md 'OpenConstructionSet.ModelExtensions') | Collection of methods for working with models.<br/> |
| [OcsConstants](O2L+5TDEXLJlnEZi6p3X+A.md 'OpenConstructionSet.OcsConstants') | Useful constants for working with the OCS.<br/> |
| [OcsDataContextBuilder](U44ADOjq83qr6ihsRA01VQ.md 'OpenConstructionSet.OcsDataContextBuilder') | Used to build game data and [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext')s.<br/> |
| [OcsDiscoveryService](xLh4AKenI1O4SsbfQkmoNQ.md 'OpenConstructionSet.OcsDiscoveryService') | The main service for the OpenConstructionSet.<br/>Provides discovery and some saving/loading functions.<br/> |
| [OcsIOService](UgUMQOJatpjEs0nJNw+3_w.md 'OpenConstructionSet.OcsIOService') | Service used to read and write game files.<br/> |
| [OcsIOServiceExtensions](FY7778xXgzBiQPFsfpgjQA.md 'OpenConstructionSet.OcsIOServiceExtensions') | Collection of wrapper function for the IO service.<br/>Implemented as extension methods because they wrap a single method and this way they don't have to be added to the interface.<br/> |

| Interfaces | |
| :--- | :--- |
| [IOcsDataBuilder](9ZN26e3kraTy7mxkYWEwlw.md 'OpenConstructionSet.IOcsDataBuilder') | Used to build game data consisting of multiple mod files.<br/> |
| [IOcsDataContextBuilder](r4RI8NnQPrFwlGRexUtVqQ.md 'OpenConstructionSet.IOcsDataContextBuilder') | Used to build [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') instances.<br/> |
| [IOcsDiscoveryService](hskRmqlOmrzLMdtKHQBPTA.md 'OpenConstructionSet.IOcsDiscoveryService') | Provides discovery methods for the games various directory structures and files.<br/> |
| [IOcsIOService](No0G5igUcUOm46RZK2qdqg.md 'OpenConstructionSet.IOcsIOService') | Service used to read and write game files.<br/> |
  
<a name='OpenConstructionSet_Collections'></a>
## OpenConstructionSet.Collections Namespace

| Classes | |
| :--- | :--- |
| [OcsList&lt;T&gt;](77BqslMvsRSH2CwSkDQQpg.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;') | String keyed list of data models.<br/> |
  
<a name='OpenConstructionSet_Data'></a>
## OpenConstructionSet.Data Namespace

| Classes | |
| :--- | :--- |
| [OcsDataContexOptions](olGSI6EYCJs8+kFR8qw+hw.md 'OpenConstructionSet.Data.OcsDataContexOptions') | Contains the required options to build an [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext').<br/> |
| [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext') | Multiple mod files can be loaded into a context as base or active items.<br/>Allows the editing and saving of the active mod.<br/> |
| [OcsDataOptions](dKJjgqs+isNwkwRmFoRW1A.md 'OpenConstructionSet.Data.OcsDataOptions') | Contains the required options to build a collection of game data for reference.<br/> |
| [OcsSaveContexOptions](HPin6P0txB1XEEHR7cNrxA.md 'OpenConstructionSet.Data.OcsSaveContexOptions') | Contains the required options to build an [OcsDataContext](3CnFB+gVLALvXc7mqWGM8Q.md 'OpenConstructionSet.Data.OcsDataContext').<br/> |
  
<a name='OpenConstructionSet_IO'></a>
## OpenConstructionSet.IO Namespace

| Classes | |
| :--- | :--- |
| [LocatedFolders](jgv6_uiXfDVLa_l1InGCGA.md 'OpenConstructionSet.IO.LocatedFolders') | Represents the results of searching for a game folder.<br/> |
| [OcsPathHelper](EL7fRrYo+340ITl9XyXeOQ.md 'OpenConstructionSet.IO.OcsPathHelper') | A collection of helper functions for dealing with the game's files.<br/> |
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
| [DataInstance](Q639LdTdLKV33AGqgr4Bkw.md 'OpenConstructionSet.Models.DataInstance') | Editable representation of an Instance from a data file.<br/> |
| [DataItem](NedciBI8UIBYqbpYqrEXSw.md 'OpenConstructionSet.Models.DataItem') | Editable representation of a item from a data file.<br/> |
| [DataReference](kxxVrykzAP83GMYoWuvnQA.md 'OpenConstructionSet.Models.DataReference') | Editable representation of a reference from a data file.<br/> |
| [DataReferenceCategory](Q3bgwvSqRWv7sT4x1Fv8Zw.md 'OpenConstructionSet.Models.DataReferenceCategory') | Editable representation of a reference category from a data file.<br/> |
| [DataVector3](V6n3XG_CfF2EM8PIpjDPDA.md 'OpenConstructionSet.Models.DataVector3') | Editable representation of a Vector3.<br/> |
| [DataVector4](uE+cMOC4LnTCagV6gqV70A.md 'OpenConstructionSet.Models.DataVector4') | Represents an editable Vector4.<br/> |
| [Header](bjExWrZuBlRDCiIUljjMrA.md 'OpenConstructionSet.Models.Header') | Representation of a mod file's header.<br/> |
| [Installation](d9dvAYmZXntxn1p8iGWqPw.md 'OpenConstructionSet.Models.Installation') | POCO representing an installation of the game.<br/> |
| [Item](Z9pYmp3jhG_PhNCQ0nlOeg.md 'OpenConstructionSet.Models.Item') | Represents an item from a data file.<br/> |
| [ModFile](yIT20v2GHuAcdx4EIfntcw.md 'OpenConstructionSet.Models.ModFile') | Represents a mod file.<br/> |
| [ModFolder](0h0FW6YI9iSflrhSD7PySw.md 'OpenConstructionSet.Models.ModFolder') | Representation of a mod folder.<br/>Provides methods for discovery and working with the contained mods.<br/> |
| [ModInfo](h0vCAhsmAC6iWOaLYw25cg.md 'OpenConstructionSet.Models.ModInfo') | POCO class representing a mod's info file.<br/> |
| [ReferenceCategory](FGzdlKUriLoI15zgK9th4g.md 'OpenConstructionSet.Models.ReferenceCategory') | A collection of references grouped by a category name.<br/> |
| [Save](lSeaf7mywqVjOzlI14k6Ow.md 'OpenConstructionSet.Models.Save') | Represents a single save directory structure.<br/> |
| [SaveFolder](V_zortZPS59vW0ZEiqO+Gg.md 'OpenConstructionSet.Models.SaveFolder') | Represents the game's save folder.<br/> |

| Structs | |
| :--- | :--- |
| [FileValue](xqcMg7X3TDoX+y5NsSzu9Q.md 'OpenConstructionSet.Models.FileValue') | Represents a path value from a data file.<br/> |
| [Instance](NhOPiCtebmQnk5Ll2Sv0og.md 'OpenConstructionSet.Models.Instance') | Represents an instance from a game data file.<br/> |
| [Reference](keNdBWwXoST05c_g6wF_4w.md 'OpenConstructionSet.Models.Reference') | Represents a reference from a game data files.<br/> |
| [Vector3](KCFzybM8YwCd4Tco51d3aw.md 'OpenConstructionSet.Models.Vector3') | Represents a position from the game data files.<br/> |
| [Vector4](zA17UDSwA7W6ghyYo5XyCQ.md 'OpenConstructionSet.Models.Vector4') | Represents a Rotation from the game data files.<br/> |

| Interfaces | |
| :--- | :--- |
| [IDataModel](zkoogszxgZdDGzPBOOAcpg.md 'OpenConstructionSet.Models.IDataModel') | A data model to be consumed by the [OcsList&lt;T&gt;](77BqslMvsRSH2CwSkDQQpg.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;') class.<br/> |

| Enums | |
| :--- | :--- |
| [DataFileType](+cY_9FxBbmCwckj8l7pVog.md 'OpenConstructionSet.Models.DataFileType') | Type identifier for data files.<br/> |
| [ItemChanges](_oC5WqPLP5mn+3ivU_9TVQ.md 'OpenConstructionSet.Models.ItemChanges') | Change types for items.<br/> |
| [ItemType](QKunUA3okX9+HGcnTOur3g.md 'OpenConstructionSet.Models.ItemType') | Type identifier for Items.<br/> |
| [ModLoadType](A5j7r8wm6GxqIgX_lVyVRQ.md 'OpenConstructionSet.Models.ModLoadType') | Used to specify how a mod should be loaded into a  |
  
