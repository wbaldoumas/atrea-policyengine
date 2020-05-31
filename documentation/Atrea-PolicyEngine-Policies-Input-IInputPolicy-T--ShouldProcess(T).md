#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Input](./Atrea-PolicyEngine-Policies-Input.md 'Atrea.PolicyEngine.Policies.Input').[IInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;')
## IInputPolicy&lt;T&gt;.ShouldProcess(T) Method
Determine whether the item should be processed by the policy engine.  
```csharp
Atrea.PolicyEngine.Policies.Input.InputPolicyResult ShouldProcess(T item);
```
#### Parameters
<a name='Atrea-PolicyEngine-Policies-Input-IInputPolicy-T--ShouldProcess(T)-item'></a>
`item` [T](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T-.md#Atrea-PolicyEngine-Policies-Input-IInputPolicy-T--T 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;.T')  
The item to check.  
  
#### Returns
[InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult')  
An [InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult') which indicates whether the item should be processed or not.  
