#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine.Policies.Output](./Atrea-PolicyEngine-Policies-Output.md 'Atrea.PolicyEngine.Policies.Output')
## IAsyncOutputPolicy&lt;T&gt; Interface
An async output policy, which can asynchronously apply post-processing to an item processed by  
the policy engine, perform cleanup actions, etc.  
```csharp
public interface IAsyncOutputPolicy<in T>
```
#### Type parameters
<a name='Atrea-PolicyEngine-Policies-Output-IAsyncOutputPolicy-T--T'></a>
`T`  
The type of the item to apply post-processing to.  
  
### Methods
- [ApplyAsync(T)](./Atrea-PolicyEngine-Policies-Output-IAsyncOutputPolicy-T--ApplyAsync(T).md 'Atrea.PolicyEngine.Policies.Output.IAsyncOutputPolicy&lt;T&gt;.ApplyAsync(T)')
