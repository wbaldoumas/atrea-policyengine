#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Input](./Atrea-PolicyEngine-Policies-Input.md 'Atrea.PolicyEngine.Policies.Input')
## IAsyncInputPolicy&lt;T&gt; Interface
An async input policy, which can take in an item and return an [InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult') to indicate  
whether the item should be processed or not by the policy engine.  
```csharp
public interface IAsyncInputPolicy<in T>
```
#### Type parameters
<a name='Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T--T'></a>
`T`  
The type of the item to be checked by the [IAsyncInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IAsyncInputPolicy&lt;T&gt;').  
  
### Methods
- [ShouldProcessAsync(T)](./Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T--ShouldProcessAsync(T).md 'Atrea.PolicyEngine.Policies.Input.IAsyncInputPolicy&lt;T&gt;.ShouldProcessAsync(T)')
