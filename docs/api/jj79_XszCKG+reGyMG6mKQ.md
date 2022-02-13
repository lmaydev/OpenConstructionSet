#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## ModReference Class
Represents a reference from the game's data.  
```csharp
public class ModReference :
OpenConstructionSet.Data.IReference,
LMay.Collections.IKeyedItem<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModReference  

Implements [IReference](vKi1zmew+odEqSm8IGr+UQ.md 'OpenConstructionSet.Data.IReference'), [LMay.Collections.IKeyedItem&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')  

| Constructors | |
| :--- | :--- |
| [ModReference(IReference)](jfACyTH3oUSy1qA_xzJbzQ.md 'OpenConstructionSet.Mods.ModReference.ModReference(OpenConstructionSet.Data.IReference)') | Creates a [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') from another.<br/> |
| [ModReference(string, int, int, int)](B_GWFSuV+1RSvs4p9rXR9w.md 'OpenConstructionSet.Mods.ModReference.ModReference(string, int, int, int)') | Creates a new [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') from the provided values.<br/> |

| Properties | |
| :--- | :--- |
| [Target](YXhDzyrtsjqEAg7HTGrHWw.md 'OpenConstructionSet.Mods.ModReference.Target') | The target of this [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference').<br/>Attempts to retrieve the [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') from the parent [IModContext](V6ll8xRvyNbd6Fd1yGQMHQ.md 'OpenConstructionSet.Mods.Context.IModContext').<br/> |
| [TargetId](AWsWtKhQiR_K4S+MHutZng.md 'OpenConstructionSet.Mods.ModReference.TargetId') | The [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') of the target [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem').<br/> |
| [Value0](j9LOWUqW6QvosuesjBkj8w.md 'OpenConstructionSet.Mods.ModReference.Value0') | The first value.<br/> |
| [Value1](9s+FKTwTaDQPUsTbIZsU4w.md 'OpenConstructionSet.Mods.ModReference.Value1') | The second value.<br/> |
| [Value2](iiQXOTw8NJ7IhIP5hgMr_w.md 'OpenConstructionSet.Mods.ModReference.Value2') | The third value.<br/> |

| Methods | |
| :--- | :--- |
| [AsDeleted()](Hr_1F7gSviBjpk9FVs4Uiw.md 'OpenConstructionSet.Mods.ModReference.AsDeleted()') | Returns an [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') that represents this marked as deleted.<br/> |
| [Equals(object?)](95sV3a4gtnoqaSGC6k9H5w.md 'OpenConstructionSet.Mods.ModReference.Equals(object?)') | Determines whether the specified object is equal to the current object. |
| [GetHashCode()](1UqtMUDeXcYXvBM5jE3S+A.md 'OpenConstructionSet.Mods.ModReference.GetHashCode()') | Serves as the default hash function. |
| [IsDeleted()](t_oCBgYbXhbqNsSk10gKCQ.md 'OpenConstructionSet.Mods.ModReference.IsDeleted()') | Determines if this [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') is marked as deleted.<br/> |

| Operators | |
| :--- | :--- |
| [operator ==(ModReference?, ModReference?)](TIk30zWXZEGBCtHkmUrpyA.md 'OpenConstructionSet.Mods.ModReference.op_Equality(OpenConstructionSet.Mods.ModReference?, OpenConstructionSet.Mods.ModReference?)') | Determines if the two [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')s are equal.<br/> |
| [operator !=(ModReference?, ModReference?)](cpdDClL8N+IKlLBdhhMiCA.md 'OpenConstructionSet.Mods.ModReference.op_Inequality(OpenConstructionSet.Mods.ModReference?, OpenConstructionSet.Mods.ModReference?)') | Determines if the two [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')s are not equal.<br/> |
