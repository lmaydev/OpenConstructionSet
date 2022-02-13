#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## ModReferenceCategory Class
Represents a [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory') from the game's data. Stores a collection of  
related references.  
```csharp
public class ModReferenceCategory :
OpenConstructionSet.Data.IReferenceCategory,
LMay.Collections.IKeyedItem<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModReferenceCategory  

Implements [IReferenceCategory](eyfZfdez5ewNEuTa_LLIEQ.md 'OpenConstructionSet.Data.IReferenceCategory'), [LMay.Collections.IKeyedItem&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')  

| Constructors | |
| :--- | :--- |
| [ModReferenceCategory(IReferenceCategory)](DzpWnEn3OsgUNCEb6gwDKw.md 'OpenConstructionSet.Mods.ModReferenceCategory.ModReferenceCategory(OpenConstructionSet.Data.IReferenceCategory)') | Creates a new [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory') from another.<br/> |
| [ModReferenceCategory(string)](Z6MQMD7QZ5GdnJqrSA7lbQ.md 'OpenConstructionSet.Mods.ModReferenceCategory.ModReferenceCategory(string)') | Creates a new [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory') with the given name.<br/> |
| [ModReferenceCategory(string, IEnumerable&lt;IReference&gt;)](8m3e6O1X7CQ475A60m3OwQ.md 'OpenConstructionSet.Mods.ModReferenceCategory.ModReferenceCategory(string, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IReference&gt;)') | Creates a new [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory') with the given name and contained [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') s. The [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') s will be recreated using the copy constructor.<br/> |

| Properties | |
| :--- | :--- |
| [Name](E1hdpMoTpzgZjVtrsIgcyA.md 'OpenConstructionSet.Mods.ModReferenceCategory.Name') | The name of the [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory').<br/> |
| [References](PvBTQQ2o7hNjwJ1gEdqB+Q.md 'OpenConstructionSet.Mods.ModReferenceCategory.References') | A collection of references stored by this [ModReferenceCategory](fD20sxqQhMY5F9hDkDL_LA.md 'OpenConstructionSet.Mods.ModReferenceCategory') |

| Methods | |
| :--- | :--- |
| [DeepClone()](4SflKY1je0dAcz5GG2YZNA.md 'OpenConstructionSet.Mods.ModReferenceCategory.DeepClone()') | Performs a deep clone of this object.<br/> |
| [Equals(object?)](x2MdumDT1diMDMm4rXDy0A.md 'OpenConstructionSet.Mods.ModReferenceCategory.Equals(object?)') | Determines whether the specified object is equal to the current object. |
| [GetHashCode()](Tl8H8jSbFU6GqG47pkCvjw.md 'OpenConstructionSet.Mods.ModReferenceCategory.GetHashCode()') | Serves as the default hash function. |
| [ToString()](zIb54xe6t4bw2RhfU5eAbA.md 'OpenConstructionSet.Mods.ModReferenceCategory.ToString()') | Returns a string that represents the current object. |
