#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO](index.md#OpenConstructionSet_IO 'OpenConstructionSet.IO')
## OcsReader Class
Reader for the game's data files.  
Can read from a `Stream` or a byte buffer.  
```csharp
public sealed class OcsReader :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsReader  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [OcsReader(byte[])](BM5F78ybreKzdhZ5rB0S0A.md 'OpenConstructionSet.IO.OcsReader.OcsReader(byte[])') | Initialize a new [OcsReader](T57tcFO5x0tbza6wZBV1Ww.md 'OpenConstructionSet.IO.OcsReader') to work against the provided buffer.<br/> |
| [OcsReader(Stream)](qfGA8OmnyZOmWlXQTFgMGQ.md 'OpenConstructionSet.IO.OcsReader.OcsReader(System.IO.Stream)') | Initialize a new [OcsReader](T57tcFO5x0tbza6wZBV1Ww.md 'OpenConstructionSet.IO.OcsReader') to work against the provided `Stream`.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](Ub7JpOwU2sdpDGCp_1j9XA.md 'OpenConstructionSet.IO.OcsReader.Dispose()') | Dispose the underlying Stream if provided.<br/> |
| [ReadBool()](vNxEV7HFSWtK+hKPpz7eTw.md 'OpenConstructionSet.IO.OcsReader.ReadBool()') | Read a `bool` from the data.<br/> |
| [ReadFloat()](ciyLximbu+H2IB0gOgJTXA.md 'OpenConstructionSet.IO.OcsReader.ReadFloat()') | Read a `float` from the data.<br/> |
| [ReadHeader()](LPjtAynPp_aGvq+1KIhJKw.md 'OpenConstructionSet.IO.OcsReader.ReadHeader()') | Read a [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header') object from the data.<br/> |
| [ReadInstance()](hQec3+sOyMqbPnC21cI5Og.md 'OpenConstructionSet.IO.OcsReader.ReadInstance()') | Read an [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance') from the data.<br/> |
| [ReadInt()](Y4FZWZcwV+JXgPmcatuFKA.md 'OpenConstructionSet.IO.OcsReader.ReadInt()') | Read an `int` from the data.<br/> |
| [ReadItem()](R6psZ2mXoqLrb_OUnvEKWQ.md 'OpenConstructionSet.IO.OcsReader.ReadItem()') | Read an [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') from the data.<br/>This includes the [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')'s values, instances and references.<br/> |
| [ReadItems()](V1Gr2oNsMnHvuRbWDmibzQ.md 'OpenConstructionSet.IO.OcsReader.ReadItems()') | Read a collection of [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')s from the data.<br/> |
| [ReadReference()](hC9HBEDTBrnN2QHsvbHnyQ.md 'OpenConstructionSet.IO.OcsReader.ReadReference()') | Read a [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') from the data.<br/> |
| [ReadString()](nemnE4YEXaghkbPfYU4t_w.md 'OpenConstructionSet.IO.OcsReader.ReadString()') | Read a `string` from the data.<br/> |
| [ReadStringList()](r3VU2EORXYdz9PXCY5t3Rw.md 'OpenConstructionSet.IO.OcsReader.ReadStringList()') | Read a comma separated list of `string`s from the data.<br/> |
| [ReadStrings()](R6ahIC6GU7IWtpUUG7i_8Q.md 'OpenConstructionSet.IO.OcsReader.ReadStrings()') | Reads a collection of `string`s from the data.<br/> |
| [ReadVector3()](MeZsl3bJlPKMpCOVeU+IVQ.md 'OpenConstructionSet.IO.OcsReader.ReadVector3()') | Read a [Vector3](MD18vFNSqWpKLqjpcCopBw.md 'OpenConstructionSet.Data.Vector3') object from the data.<br/> |
| [ReadVector4(bool)](Co57KgCL605GZBSXCdFLLg.md 'OpenConstructionSet.IO.OcsReader.ReadVector4(bool)') | Read a [Vector4](jzKTjk4swm94jQ1SgGBzAQ.md 'OpenConstructionSet.Data.Vector4') object from the data.<br/> |
