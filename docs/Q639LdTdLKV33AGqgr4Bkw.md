#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Models](index.md#OpenConstructionSet_Models 'OpenConstructionSet.Models')
## DataInstance Class
Editable representation of an Instance from a data file.  
```csharp
public class DataInstance :
OpenConstructionSet.Models.IDataModel,
System.IEquatable<OpenConstructionSet.Models.Instance>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataInstance  

Implements [IDataModel](zkoogszxgZdDGzPBOOAcpg.md 'OpenConstructionSet.Models.IDataModel'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Instance](NhOPiCtebmQnk5Ll2Sv0og.md 'OpenConstructionSet.Models.Instance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  

| Constructors | |
| :--- | :--- |
| [DataInstance(DataInstance)](Igl2b8lKrmEN+ZIcklTAww.md 'OpenConstructionSet.Models.DataInstance.DataInstance(OpenConstructionSet.Models.DataInstance)') | Copy constructor.<br/> |
| [DataInstance(Instance)](UgeLFlLzY09NziCB2uo6bA.md 'OpenConstructionSet.Models.DataInstance.DataInstance(OpenConstructionSet.Models.Instance)') | Create an editable `DataInstance` from a `Instance`.<br/> |
| [DataInstance(string, string)](tkm7cs7YYVZcvUlcxvXmiw.md 'OpenConstructionSet.Models.DataInstance.DataInstance(string, string)') | Create a `DataInstance` from the provided values.<br/> |
| [DataInstance(string, string, DataVector3, DataVector4, IEnumerable&lt;string&gt;)](43sQu7lNfaHyOuE7Y0Qo_g.md 'OpenConstructionSet.Models.DataInstance.DataInstance(string, string, OpenConstructionSet.Models.DataVector3, OpenConstructionSet.Models.DataVector4, System.Collections.Generic.IEnumerable&lt;string&gt;)') | Create a `DataInstance` from the provided values.<br/> |

| Properties | |
| :--- | :--- |
| [Id](XMB+fK3vbszZpNMHJflB6w.md 'OpenConstructionSet.Models.DataInstance.Id') | The instance's identifier.<br/> |
| [Key](9_AZ4TCsFDA3Mng2ShkMbg.md 'OpenConstructionSet.Models.DataInstance.Key') | Unique Identifier.<br/> |
| [Position](glXT4LQ0k2NhHRyM3a3XiA.md 'OpenConstructionSet.Models.DataInstance.Position') | The position of the instance.<br/> |
| [Rotation](VobR+KEAG1bXlkylwDjWIg.md 'OpenConstructionSet.Models.DataInstance.Rotation') | The rotation of the instance.<br/> |
| [States](BaqJgrVp_s9N4lrHgSxUtQ.md 'OpenConstructionSet.Models.DataInstance.States') | The attached states.<br/> |
| [TargetId](G5c8mdruVpgJ5ciFncqBxg.md 'OpenConstructionSet.Models.DataInstance.TargetId') | The StringId of the target .<br/> |

| Methods | |
| :--- | :--- |
| [Equals(object?)](9_ZoHRUVQol+RY_WOXk8uw.md 'OpenConstructionSet.Models.DataInstance.Equals(object?)') | Determines if the provided object is equal to this.<br/> |
| [Equals(Instance)](WuEJfm0DZ0ZQac6XlsvmKA.md 'OpenConstructionSet.Models.DataInstance.Equals(OpenConstructionSet.Models.Instance)') | Determine if the given `Instance` is equal to this.<br/> |
| [GetHashCode()](X9PumHT5POEjub6N6QNwoQ.md 'OpenConstructionSet.Models.DataInstance.GetHashCode()') | Creates a hash code based on the object's property values.<br/> |

| Operators | |
| :--- | :--- |
| [operator ==(DataInstance?, DataInstance?)](O_AaBVelzceAt8_DZCdPjA.md 'OpenConstructionSet.Models.DataInstance.op_Equality(OpenConstructionSet.Models.DataInstance?, OpenConstructionSet.Models.DataInstance?)') | Determines if two `DataInstance`s are the same.<br/> |
| [operator !=(DataInstance?, DataInstance?)](V5ulwEQYUclPxyHqo_oHkQ.md 'OpenConstructionSet.Models.DataInstance.op_Inequality(OpenConstructionSet.Models.DataInstance?, OpenConstructionSet.Models.DataInstance?)') | Determines if two `DataInstance`s are not the same.<br/> |
