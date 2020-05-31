#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine](./Atrea-PolicyEngine.md 'Atrea.PolicyEngine')
## IAsyncPolicyEngine&lt;T&gt; Interface
An async policy engine which will check if an item should be processed with its input policies,  
process the item using its processors, then apply any post-processing to the item using its  
output policies. Note that this engine can be configured with non-async and async input policies,  
non-async, async, and parallel processors, and non-async, async, and parallel output policies.  

See [AsyncPolicyEngineBuilder&lt;T&gt;](./Atrea-PolicyEngine-Builders-AsyncPolicyEngineBuilder-T-.md 'Atrea.PolicyEngine.Builders.AsyncPolicyEngineBuilder&lt;T&gt;') for configuration of this async policy engine.  
```csharp
public interface IAsyncPolicyEngine<in T> :
IAsyncProcessor<T>
```
Implements [Atrea.PolicyEngine.Processors.IAsyncProcessor&lt;](./Atrea-PolicyEngine-Processors-IAsyncProcessor-T-.md 'Atrea.PolicyEngine.Processors.IAsyncProcessor&lt;T&gt;')[T](#Atrea-PolicyEngine-IAsyncPolicyEngine-T--T 'Atrea.PolicyEngine.IAsyncPolicyEngine&lt;T&gt;.T')[&gt;](./Atrea-PolicyEngine-Processors-IAsyncProcessor-T-.md 'Atrea.PolicyEngine.Processors.IAsyncProcessor&lt;T&gt;')  
#### Type parameters
<a name='Atrea-PolicyEngine-IAsyncPolicyEngine-T--T'></a>
`T`  
The type of the item to be processed.  
  
