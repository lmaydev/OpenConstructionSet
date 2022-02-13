#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Data](index.md#OpenConstructionSet_Data 'OpenConstructionSet.Data')
## Item Class
Represents an item in the games data.  
All entites in the game are represented using these.  
```csharp
public class Item :
OpenConstructionSet.Data.IItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Item  

Implements [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem')  

| Constructors | |
| :--- | :--- |
| [Item(IItem)](BH0VkwLlgduspvNB6SY4Wg.md 'OpenConstructionSet.Data.Item.Item(OpenConstructionSet.Data.IItem)') | Creates a new [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') from an [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem').<br/> |
| [Item(ItemType, int, string, string, ItemChangeType)](d9pCV9chPYvzy8ByNbY1Xw.md 'OpenConstructionSet.Data.Item.Item(OpenConstructionSet.Data.ItemType, int, string, string, OpenConstructionSet.Data.ItemChangeType)') | Creates a new [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') from the provided data.<br/> |
| [Item(ItemType, int, string, string, ItemChangeType, IDictionary&lt;string,object&gt;, IEnumerable&lt;IReferenceCategory&gt;, IEnumerable&lt;IInstance&gt;)](6pgrs20M83OsDduazcVMnA.md 'OpenConstructionSet.Data.Item.Item(OpenConstructionSet.Data.ItemType, int, string, string, OpenConstructionSet.Data.ItemChangeType, System.Collections.Generic.IDictionary&lt;string,object&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IReferenceCategory&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.IInstance&gt;)') | Creates a new [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') from the provided data.<br/> |
| [Item(ItemType, int, string, string, ItemChangeType, IDictionary&lt;string,object&gt;, IEnumerable&lt;ReferenceCategory&gt;, IEnumerable&lt;Instance&gt;)](620bJbWcr4mqnCUQBp6ilA.md 'OpenConstructionSet.Data.Item.Item(OpenConstructionSet.Data.ItemType, int, string, string, OpenConstructionSet.Data.ItemChangeType, System.Collections.Generic.IDictionary&lt;string,object&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.ReferenceCategory&gt;, System.Collections.Generic.IEnumerable&lt;OpenConstructionSet.Data.Instance&gt;)') | Creates a new [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item') from the provided data.<br/> |

| Properties | |
| :--- | :--- |
| [ChangeType](QnvmZbPpSxPaB67OVMPXIg.md 'OpenConstructionSet.Data.Item.ChangeType') | The types of changes that have been applied to this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [Id](W4IRZ7KlqnVuKXXO7LT2QA.md 'OpenConstructionSet.Data.Item.Id') | The Id of this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [Instances](klaAKiGXUdcSm+55gMcvlw.md 'OpenConstructionSet.Data.Item.Instances') | Collection of [Instance](XoCYM4Zu_75pHW5Xla9kmw.md 'OpenConstructionSet.Data.Instance')s stored by this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [Name](Y2nPFfGEX7MYmAFZUWNa4g.md 'OpenConstructionSet.Data.Item.Name') | The name of this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [ReferenceCategories](mU9jnGVs0NHPk34WwJX0yQ.md 'OpenConstructionSet.Data.Item.ReferenceCategories') | Collection of [ReferenceCategory](EE2faYCOBw8RCxMlUf_j8A.md 'OpenConstructionSet.Data.ReferenceCategory') instances stored by this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [StringId](aCBhN3kETnoa3JITJpV0hA.md 'OpenConstructionSet.Data.Item.StringId') | The unique string identifier of this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [Type](pOWG2vZWpsLAqYkAbrcIIA.md 'OpenConstructionSet.Data.Item.Type') | The [ItemType](XuU7ysPytTqbguniJ5wn1A.md 'OpenConstructionSet.Data.ItemType') for this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |
| [Values](wp_oac+5cqKQbMk2S9BHsg.md 'OpenConstructionSet.Data.Item.Values') | Dictionary of values stored by this [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item').<br/> |

| Methods | |
| :--- | :--- |
| [Delete()](qXoi5i27r6cbaN3Z_2rnXw.md 'OpenConstructionSet.Data.Item.Delete()') | Marks this [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') as deleted.<br/> |
| [Equals(object?)](17nmydpkQeM46urNBCPnNw.md 'OpenConstructionSet.Data.Item.Equals(object?)') | Determines whether the specified object is equal to the current object. |
| [GetHashCode()](mdU+z969SZnepm4QRTivkw.md 'OpenConstructionSet.Data.Item.GetHashCode()') | Serves as the default hash function. |
| [IsDeleted()](ukLCic74W_t2zfatp03YIA.md 'OpenConstructionSet.Data.Item.IsDeleted()') | Determines if this [Reference](Q7cLD6PnJBeIdkGmsPwKew.md 'OpenConstructionSet.Data.Reference') is marked as deleted.<br/> |
| [ToString()](IZpc+pUoP0LTuQjJFMVHbw.md 'OpenConstructionSet.Data.Item.ToString()') | Returns a string that represents the current object. |

| Operators | |
| :--- | :--- |
| [operator ==(Item?, Item?)](uLsV0CLUob_KYo7W76AaIQ.md 'OpenConstructionSet.Data.Item.op_Equality(OpenConstructionSet.Data.Item?, OpenConstructionSet.Data.Item?)') | Determines if the two [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')s are equal.<br/> |
| [operator !=(Item?, Item?)](+JTaU8nAZ6KV57kFyKgGxg.md 'OpenConstructionSet.Data.Item.op_Inequality(OpenConstructionSet.Data.Item?, OpenConstructionSet.Data.Item?)') | Determines if the two [Item](n8yymaCCgJR7t826C4USew.md 'OpenConstructionSet.Data.Item')s are not equal.<br/> |
