#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Input](./Atrea-PolicyEngine-Policies-Input.md 'Atrea.PolicyEngine.Policies.Input')
## InputPolicyResult Enum
A result of an [IInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;'), to be used by the [IPolicyEngine&lt;T&gt;](./Atrea-PolicyEngine-IPolicyEngine-T-.md 'Atrea.PolicyEngine.IPolicyEngine&lt;T&gt;')  
and [IAsyncPolicyEngine&lt;T&gt;](./Atrea-PolicyEngine-IAsyncPolicyEngine-T-.md 'Atrea.PolicyEngine.IAsyncPolicyEngine&lt;T&gt;').  
```csharp
public enum InputPolicyResult
```
### Fields
<a name='Atrea-PolicyEngine-Policies-Input-InputPolicyResult-Accept'></a>
`Accept` 0  
Accept the item as input and skip remaining input policies.  
  
<a name='Atrea-PolicyEngine-Policies-Input-InputPolicyResult-Reject'></a>
`Reject` 1  
Reject the item as input - skip remaining input policies, processors, and output policies.  
  
<a name='Atrea-PolicyEngine-Policies-Input-InputPolicyResult-Continue'></a>
`Continue` 2  
Accept the item for this given [IInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IInputPolicy&lt;T&gt;') and continue evaluating remaining  
input policies, or being processing if this is the result of the last input policy run.  
  
