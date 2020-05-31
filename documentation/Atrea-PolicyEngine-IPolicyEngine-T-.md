#### [Atrea.PolicyEngine](./index.md 'index')
### [Atrea.PolicyEngine](./Atrea-PolicyEngine.md 'Atrea.PolicyEngine')
## IPolicyEngine&lt;T&gt; Interface
A policy engine which will check if an item should be processed with its input policies,  
process the item using its processors, then apply any post-processing to the item using its  
output policies.  

See [PolicyEngineBuilder&lt;T&gt;](./Atrea-PolicyEngine-Builders-PolicyEngineBuilder-T-.md 'Atrea.PolicyEngine.Builders.PolicyEngineBuilder&lt;T&gt;') for configuration of this policy engine.  
```csharp
public interface IPolicyEngine<in T> :
IProcessor<T>
```
Implements [Atrea.PolicyEngine.Processors.IProcessor&lt;](./Atrea-PolicyEngine-Processors-IProcessor-T-.md 'Atrea.PolicyEngine.Processors.IProcessor&lt;T&gt;')[T](#Atrea-PolicyEngine-IPolicyEngine-T--T 'Atrea.PolicyEngine.IPolicyEngine&lt;T&gt;.T')[&gt;](./Atrea-PolicyEngine-Processors-IProcessor-T-.md 'Atrea.PolicyEngine.Processors.IProcessor&lt;T&gt;')  
#### Type parameters
<a name='Atrea-PolicyEngine-IPolicyEngine-T--T'></a>
`T`  
The type of the item to be processed.  
  
