#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Input](./Atrea-PolicyEngine-Policies-Input.md 'Atrea.PolicyEngine.Policies.Input').[IAsyncInputPolicy&lt;T&gt;](./Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T-.md 'Atrea.PolicyEngine.Policies.Input.IAsyncInputPolicy&lt;T&gt;')
## IAsyncInputPolicy&lt;T&gt;.ShouldProcessAsync(T) Method
Asynchronously determine whether the item should be processed by the policy engine.  
```csharp
System.Threading.Tasks.Task<Atrea.PolicyEngine.Policies.Input.InputPolicyResult> ShouldProcessAsync(T item);
```
#### Parameters
<a name='Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T--ShouldProcessAsync(T)-item'></a>
`item` [T](./Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T-.md#Atrea-PolicyEngine-Policies-Input-IAsyncInputPolicy-T--T 'Atrea.PolicyEngine.Policies.Input.IAsyncInputPolicy&lt;T&gt;.T')  
The item to check.  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') to await, whose result is an [InputPolicyResult](./Atrea-PolicyEngine-Policies-Input-InputPolicyResult.md 'Atrea.PolicyEngine.Policies.Input.InputPolicyResult').  
