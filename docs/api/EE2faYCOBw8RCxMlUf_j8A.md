#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## ReferenceCategory Class
Represents a reference category from the game's data.  
Stores a collection of related references.  
```csharp
public class ReferenceCategory :
OpenConstructionSet.Data.IReferenceCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReferenceCategory  

Implements [IReferenceCategory](eyfZfdez5ewNEuTa_LLIEQ.md 'OpenConstructionSet.Data.IReferenceCategory')  

| Constructors | |
| :--- | :--- |
| [ReferenceCategory(IReferenceCategory)](ly3IJAAyTt_UB5z_WHWn1g.md 'OpenConstructionSet.Data.ReferenceCategory.ReferenceCategory(OpenConstructionSet.Data.IReferenceCategory)') | Creates a new [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') from another.<br/> |
| [ReferenceCategory(string)](gEMYlGZwEgDehUBjishdZA.md 'OpenConstructionSet.Data.ReferenceCategory.ReferenceCategory(string)') | Creates a new [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') with the given name.<br/> |
| [ReferenceCategory(string, int)](AXrvKqgXV9ahRV4fVvy6vw.md 'OpenConstructionSet.Data.ReferenceCategory.ReferenceCategory(string, int)') | Creates a new [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') with the given name and contained [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s.<br/> |
| [ReferenceCategory(string, IEnumerable&lt;IReference&gt;)](I8_gPAkjNLttmnD5FaHFAQ.md 'OpenConstructionSet.Data.ReferenceCategory.ReferenceCategory(string, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IReference&gt;)') | Creates a new [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') with the given name and contained [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s.<br/>The [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s will be recreated using the copy constructor.<br/> |
| [ReferenceCategory(string, IEnumerable&lt;Reference&gt;)](D25V5KzhaDlzigl6TRW2Sw.md 'OpenConstructionSet.Data.ReferenceCategory.ReferenceCategory(string, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.Reference&gt;)') | Creates a new [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') with the given name and contained [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s.<br/>The [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference')s will be recreated using the copy constructor.<br/> |

| Properties | |
| :--- | :--- |
| [Name](eYQ2oTwtl99dwZk7NknDVQ.md 'OpenConstructionSet.Data.ReferenceCategory.Name') | The name of the [IReferenceCategory](eyfZfdez5ewNEuTa_LLIEQ.md 'OpenConstructionSet.Data.IReferenceCategory').<br/> |
| [References](PRJgbub0dIk5vUM4BOmTLg.md 'OpenConstructionSet.Data.ReferenceCategory.References') | A collection of references stored by this [IReferenceCategory](eyfZfdez5ewNEuTa_LLIEQ.md 'OpenConstructionSet.Data.IReferenceCategory') |

| Methods | |
| :--- | :--- |
| [Equals(object?)](i_X0Sl5Cy_jokWzzSiZWPg.md 'OpenConstructionSet.Data.ReferenceCategory.Equals(object?)') | Determines whether the specified object is equal to the current object. |
| [GetHashCode()](Ns9WVdndz0bBuqj+z_qpMw.md 'OpenConstructionSet.Data.ReferenceCategory.GetHashCode()') | Serves as the default hash function. |
| [ToString()](GbDiKTBD6O2BYtMkMeEqvQ.md 'OpenConstructionSet.Data.ReferenceCategory.ToString()') | Returns a string that represents the current object. |

| Explicit Interface Implementations | |
| :--- | :--- |
| [OpenConstructionSet.Data.IReferenceCategory.References](y6+6By3qg8jh0BdZUFH53w.md 'OpenConstructionSet.Data.ReferenceCategory.OpenConstructionSet.Data.IReferenceCategory.References') | A collection of references stored by this [IReferenceCategory](eyfZfdez5ewNEuTa_LLIEQ.md 'OpenConstructionSet.Data.IReferenceCategory') |
