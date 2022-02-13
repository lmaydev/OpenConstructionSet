#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods](index.md#OpenConstructionSet_Mods 'OpenConstructionSet.Mods')
## ModInstance Class
Represents an instance from the game's data.  
```csharp
public class ModInstance :
OpenConstructionSet.Data.IInstance,
LMay.Collections.IKeyedItem<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModInstance  

Implements [IInstance](iPF4C0hGFCtE+fnDX2Ag5w.md 'OpenConstructionSet.Data.IInstance'), [LMay.Collections.IKeyedItem&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.IKeyedItem-1 'LMay.Collections.IKeyedItem`1')  

| Constructors | |
| :--- | :--- |
| [ModInstance(IInstance)](DQygDYbmxAW20FIYwWfNZA.md 'OpenConstructionSet.Mods.ModInstance.ModInstance(OpenConstructionSet.Data.IInstance)') | Creates a new [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance') from another.<br/> |
| [ModInstance(string, string, Vector3, Vector4, IEnumerable&lt;string&gt;)](ErEHbP62uQxhkpYYmJcz0Q.md 'OpenConstructionSet.Mods.ModInstance.ModInstance(string, string, OpenConstructionSet.Data.Vector3, OpenConstructionSet.Data.Vector4, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Creates a new [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance') from the provided data.<br/> |

| Properties | |
| :--- | :--- |
| [Id](mg_4oRKdOSRfjxfAm6pNsQ.md 'OpenConstructionSet.Mods.ModInstance.Id') | The [IInstance](iPF4C0hGFCtE+fnDX2Ag5w.md 'OpenConstructionSet.Data.IInstance')'s unique identifier.<br/> |
| [Position](lbnQu0A8h5Ca_uoVti5UBA.md 'OpenConstructionSet.Mods.ModInstance.Position') | The [IInstance](iPF4C0hGFCtE+fnDX2Ag5w.md 'OpenConstructionSet.Data.IInstance')'s position.<br/> |
| [Rotation](AWbFfbUI60v9LEbZVs13WA.md 'OpenConstructionSet.Mods.ModInstance.Rotation') | The [IInstance](iPF4C0hGFCtE+fnDX2Ag5w.md 'OpenConstructionSet.Data.IInstance')'s rotation.<br/> |
| [States](NE54OJ0GHPqWIm37mO2pWg.md 'OpenConstructionSet.Mods.ModInstance.States') | A collection of states for the [IInstance](iPF4C0hGFCtE+fnDX2Ag5w.md 'OpenConstructionSet.Data.IInstance').<br/> |
| [Target](9rPe9Zivo0VISHByYTJ7ow.md 'OpenConstructionSet.Mods.ModInstance.Target') | The target of this [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance').<br/>Attempts to retrieve the [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance') from the parent [IModContext](V6ll8xRvyNbd6Fd1yGQMHQ.md 'OpenConstructionSet.Mods.Context.IModContext').<br/> |
| [TargetId](Y_yYF0h62Z26w0x7glo1DA.md 'OpenConstructionSet.Mods.ModInstance.TargetId') | The [StringId](C7NXJeVk4qI07BbFStgaIg.md 'OpenConstructionSet.Data.IItem.StringId') of the targeted [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem').<br/> |

| Methods | |
| :--- | :--- |
| [AsDeleted()](csXai04TuFaY5Caa9l9NPw.md 'OpenConstructionSet.Mods.ModInstance.AsDeleted()') | Returns an [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance') that represents this marked as deleted.<br/> |
| [DeepClone()](Cc2A8Jp4Izk3ejDCCprC1w.md 'OpenConstructionSet.Mods.ModInstance.DeepClone()') | Performs a deep clone of this object.<br/> |
| [Equals(object?)](ZblpRhjZqERAcbueZUHlVQ.md 'OpenConstructionSet.Mods.ModInstance.Equals(object?)') | Determines whether the specified object is equal to the current object. |
| [GetHashCode()](u45WNnGp+kmVKASoM0+Wkw.md 'OpenConstructionSet.Mods.ModInstance.GetHashCode()') | Serves as the default hash function. |
| [IsDeleted()](c8M2K_posk17IaQPlBdinQ.md 'OpenConstructionSet.Mods.ModInstance.IsDeleted()') | Determines if this [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance') is marked as deleted.<br/> |

| Operators | |
| :--- | :--- |
| [operator ==(ModInstance?, ModInstance?)](JhVoEOdWhtpqXiqBBeMKBQ.md 'OpenConstructionSet.Mods.ModInstance.op_Equality(OpenConstructionSet.Mods.ModInstance?, OpenConstructionSet.Mods.ModInstance?)') | Determines if the two [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance')s are equal.<br/> |
| [operator !=(ModInstance?, ModInstance?)](je5rjfkpdKRL4Ae0gmmwDQ.md 'OpenConstructionSet.Mods.ModInstance.op_Inequality(OpenConstructionSet.Mods.ModInstance?, OpenConstructionSet.Mods.ModInstance?)') | Determines if the two [ModInstance](JIzdqVYB5Fwi0oO9xcHLVw.md 'OpenConstructionSet.Mods.ModInstance')s are not equal.<br/> |
