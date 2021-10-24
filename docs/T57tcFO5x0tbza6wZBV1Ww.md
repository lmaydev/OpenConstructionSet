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
| [OcsReader(byte[])](BM5F78ybreKzdhZ5rB0S0A.md 'OpenConstructionSet.IO.OcsReader.OcsReader(byte[])') | Initialise a new `OcsReader` to work against the provided buffer.<br/> |
| [OcsReader(Stream)](qfGA8OmnyZOmWlXQTFgMGQ.md 'OpenConstructionSet.IO.OcsReader.OcsReader(System.IO.Stream)') | Initialise a new `OcsReader` to work against the provided `Stream`.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](Ub7JpOwU2sdpDGCp_1j9XA.md 'OpenConstructionSet.IO.OcsReader.Dispose()') | Dispose the underlying stream if provided.<br/> |
| [ReadBool()](vNxEV7HFSWtK+hKPpz7eTw.md 'OpenConstructionSet.IO.OcsReader.ReadBool()') | Read a bool from the data.<br/> |
| [ReadFloat()](ciyLximbu+H2IB0gOgJTXA.md 'OpenConstructionSet.IO.OcsReader.ReadFloat()') | Read a float from the data.<br/> |
| [ReadHeader()](LPjtAynPp_aGvq+1KIhJKw.md 'OpenConstructionSet.IO.OcsReader.ReadHeader()') | Read a `Header` object from the data.<br/> |
| [ReadInstance()](hQec3+sOyMqbPnC21cI5Og.md 'OpenConstructionSet.IO.OcsReader.ReadInstance()') | Read an `Instance` from the data.<br/> |
| [ReadInt()](Y4FZWZcwV+JXgPmcatuFKA.md 'OpenConstructionSet.IO.OcsReader.ReadInt()') | Read an int from the data.<br/> |
| [ReadItem()](R6psZ2mXoqLrb_OUnvEKWQ.md 'OpenConstructionSet.IO.OcsReader.ReadItem()') | Read an `Item` from the data.<br/>This includes the `Item`'s values, instances and references.<br/> |
| [ReadItems()](V1Gr2oNsMnHvuRbWDmibzQ.md 'OpenConstructionSet.IO.OcsReader.ReadItems()') | Read a collection of `Item`s from the data.<br/> |
| [ReadReference()](hC9HBEDTBrnN2QHsvbHnyQ.md 'OpenConstructionSet.IO.OcsReader.ReadReference()') | Read a `Reference` from the data.<br/> |
| [ReadReferenceValues()](AtOGe_mvtA0NUeUtD8DGFQ.md 'OpenConstructionSet.IO.OcsReader.ReadReferenceValues()') | Read a `ReferenceValues` object from the data.<br/> |
| [ReadString()](nemnE4YEXaghkbPfYU4t_w.md 'OpenConstructionSet.IO.OcsReader.ReadString()') | Read a string from the data.<br/> |
| [ReadStringList()](r3VU2EORXYdz9PXCY5t3Rw.md 'OpenConstructionSet.IO.OcsReader.ReadStringList()') | Read a comma separated list from the data.<br/> |
| [ReadStrings()](R6ahIC6GU7IWtpUUG7i_8Q.md 'OpenConstructionSet.IO.OcsReader.ReadStrings()') | Reads a collection of strings from the data.<br/> |
| [ReadVector3()](MeZsl3bJlPKMpCOVeU+IVQ.md 'OpenConstructionSet.IO.OcsReader.ReadVector3()') | Read a `Vector3` object from the data.<br/> |
| [ReadVector4(bool)](Co57KgCL605GZBSXCdFLLg.md 'OpenConstructionSet.IO.OcsReader.ReadVector4(bool)') | Read a `Vector4` object from the data.<br/> |
