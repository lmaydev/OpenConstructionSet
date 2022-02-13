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
| [OcsWriter(Stream)](jIyrpvX8W6_zOJ7SP4+oqQ.md 'OpenConstructionSet.IO.OcsWriter.OcsWriter(System.IO.Stream)') | Initialize a new writer working against the given `Stream`.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](3INognOZLPyo_YcM+qFx1Q.md 'OpenConstructionSet.IO.OcsWriter.Dispose()') | Dispose the underlying `Stream`.<br/> |
| [Write&lt;T&gt;(IEnumerable&lt;T&gt;)](FpAs07YyMVGu_hcYZV66bg.md 'OpenConstructionSet.IO.OcsWriter.Write&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Write a collection of objects to the `Stream`. T will be runtime bound to one of the<br/>Write methods. Passing an unsupported type will result in errors.<br/> |
| [Write(bool)](sQltuRKs72Ct1UbaGn5lJQ.md 'OpenConstructionSet.IO.OcsWriter.Write(bool)') | Write a `bool` to the `Stream`.<br/> |
| [Write(float)](FSO1L3TEwrqcbcmH1TPLQA.md 'OpenConstructionSet.IO.OcsWriter.Write(float)') | Write a `float` to the `Stream`.<br/> |
| [Write(int)](LNKtJ3KgsxQfzb8cZ0HlPw.md 'OpenConstructionSet.IO.OcsWriter.Write(int)') | Write an `int` to the `Stream`.<br/> |
| [Write(FileValue)](gfmEC_cwEPa+XNL6QM_FjQ.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.FileValue)') | Write a [FileValue](YEby5v5c4H_ER4RaKEGo3g.md 'OpenConstructionSet.Data.FileValue') object to the `Stream`.<br/> |
| [Write(Header)](tcbvlJiN7GQvJVTQQ_THiA.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Header)') | Write a [Header](y6Au0zwIM7btf+C21xR7ow.md 'OpenConstructionSet.Data.Header') object to the `Stream`.<br/> |
| [Write(Instance)](DIFglwW5XvVpzbBnOMtiSw.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Instance)') | Write an [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance') to the `Stream`.<br/> |
| [Write(Item)](+V8fp9qoI7bbz_dDx1crJw.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Item)') | Write an [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') to the `Stream`.<br/> |
| [Write(Reference)](mIvs2Jc1OygW6_myIBVUwA.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Reference)') | Write a [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') to the `Stream`.<br/> |
| [Write(Vector3)](QHyetocZmIwy7UFymhriSw.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Vector3)') | Write a [Vector3](MD18vFNSqWpKLqjpcCopBw.md 'OpenConstructionSet.Data.Vector3') object to the `Stream`.<br/> |
| [Write(Vector4, bool)](tM56W87ARIFINbiKJlUgOg.md 'OpenConstructionSet.IO.OcsWriter.Write(OpenConstructionSet.Data.Vector4, bool)') | Write a [Vector4](jzKTjk4swm94jQ1SgGBzAQ.md 'OpenConstructionSet.Data.Vector4') object to the `Stream`.<br/> |
| [Write(string)](tFtj8d0KegTpG2chXL7o6Q.md 'OpenConstructionSet.IO.OcsWriter.Write(string)') | Write a `string` to the `Stream`.<br/> |
