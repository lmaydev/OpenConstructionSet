#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.IO](index.md#OpenConstructionSet_IO 'OpenConstructionSet.IO')
## OcsWriter Class
Writer for the game's data files.  
```csharp
public sealed class OcsWriter :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsWriter  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [OcsWriter(Stream)](jIyrpvX8W6_zOJ7SP4+oqQ.md 'OpenConstructionSet.IO.OcsWriter.OcsWriter(System.IO.Stream)') | Initialize a new writer working against the given stream.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](3INognOZLPyo_YcM+qFx1Q.md 'OpenConstructionSet.IO.OcsWriter.Dispose()') | Dispose the underlying stream.<br/> |
| [Write&lt;T&gt;(IEnumerable&lt;T&gt;)](FpAs07YyMVGu_hcYZV66bg.md 'OpenConstructionSet.IO.OcsWriter.Write&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Write a collection of objects to the stream.<br/>T will be runtime bound to one of the Write methods. Passing an unsupported type will result in errors.<br/> |
| [Write(bool)](sQltuRKs72Ct1UbaGn5lJQ.md 'OpenConstructionSet.IO.OcsWriter.Write(bool)') | Write a bool to the stream.<br/> |
| [Write(float)](FSO1L3TEwrqcbcmH1TPLQA.md 'OpenConstructionSet.IO.OcsWriter.Write(float)') | Write a float to the stream.<br/> |
| [Write(int)](LNKtJ3KgsxQfzb8cZ0HlPw.md 'OpenConstructionSet.IO.OcsWriter.Write(int)') | Write an int to the stream.<br/> |
| [Write(FileValue)](AefwuyNk8xNTKhmOTTxt7g.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.FileValue)') | Write a `FileValue` object to the stream.<br/> |
| [Write(Header)](5UkMGrKgsN+a43BQKEqnyw.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Header)') | Write a `Header` object to the stream.<br/> |
| [Write(Instance)](WzrSabmFyilTVf93UxkSnQ.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Instance)') | Write an `Instance` to the stream.<br/> |
| [Write(Item)](AnyG6bVS9dkCxEm9aDX1Jw.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Item)') | Write an `Item` to the stream.<br/> |
| [Write(Reference)](3vpC1wn+nL9NLmDaCX3l4w.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Reference)') | Write a `Reference` to the stream.<br/> |
| [Write(Vector3)](tX+Gu7wqujXue_ie5NdbhQ.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Vector3)') | Write a `Vector3` object to the stream.<br/> |
| [Write(Vector4, bool)](iWVeA0qxKbdxVRzn+wrBNg.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Models.Vector4, bool)') | Write a `Vector4` object to the stream.<br/> |
| [Write(string)](tFtj8d0KegTpG2chXL7o6Q.md 'OpenConstructionSet.IO.OcsWriter.Write(string)') | Write a string to the stream.<br/> |
