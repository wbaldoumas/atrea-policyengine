#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Input](./Atrea-PolicyEngine-Policies-Input.md 'Atrea.PolicyEngine.Policies.Input')
## IInputPolicy&lt;T&gt; Interface
An input policy, which can take in an item and return an [InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult') to indicate  
whether the item should be processed or not by the policy engine.  
```csharp
public interface IInputPolicy<in T>
```
#### Type parameters
<a name='Atrea-PolicyEngine-Policies-Input-IInputPolicy-T--T'></a>
`T`  
The type of the item to be checked by the [IInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;').  
  
### Methods
- [ShouldProcess(T)](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T--ShouldProcess(T).md 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;.ShouldProcess(T)')
